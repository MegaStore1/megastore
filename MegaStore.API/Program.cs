using System.Net;
using System.Text;
using MegaStore.API.Data;
using MegaStore.API.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using MegaStore.API.Data.Core;
using MegaStore.API.Data.Core.CountryModule;
using MegaStore.API.Data.Core.Shared;
using MegaStore.API.Data.Settings.CompanyRepo;
using MegaStore.API.Data.ProductRepo;
using MegaStore.API.Data.OrderRepo;
using MegaStore.API.Data.CustomerRepo;
using MegaStore.API.Helpers.Mail;
using MegaStore.API.Services.Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
    .AddNewtonsoftJson(opt =>
    {
        opt.SerializerSettings.ReferenceLoopHandling =
            Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Configuration
builder.Services.AddDbContext<DataContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adding CORS
builder.Services.AddCors();

// Add Mapper Service
builder.Services.AddAutoMapper(typeof(Program));

// Configure the services, We are not conserned about the order of services here. 
// Add the repositories
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IMegaStoreRepository, MegaStoreRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IUserRoles, UserRoles>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Add Seeds
builder.Services.AddScoped<Seed>();

// Add Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Mail Settings
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();

// Stripe Infrastructure
builder.Services.AddStripeInfrastructure(builder.Configuration);

// Custom Page Authorizer
builder.Services.AddScoped<PageAuthorizer>();

builder.Services.AddScoped<LogUserActivity>();

var app = builder.Build();

// Get Seeds


// Run Custom Page Authorizer
app.Use(async (context, next) =>
    {
        var customAuthorizer = context.RequestServices.GetRequiredService<PageAuthorizer>();

        if (await customAuthorizer.IsAuthorized(context))
        {
            // User has access to the current API address, proceed with the request
            await next();
        }
        else
        {
            // User doesn't have access, return a 403 Forbidden response
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("You don't have permission to access this resource.");
        }
    });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler(builder =>
    {
        builder.Run(async context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var error = context.Features.Get<IExceptionHandlerFeature>();

            if (error != null)
            {
                context.Response.AddApplicationError(error.Error.Message);
                await context.Response.WriteAsync(error.Error.Message);
            }
        });
    });
}

// Seed.SeedCountries(app);

// app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
