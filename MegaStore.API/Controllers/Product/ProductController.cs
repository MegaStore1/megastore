using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Data.ProductRepo;
using MegaStore.API.Data.Settings.CompanyRepo;
using MegaStore.API.Dtos.Product;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Product.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MegaStore.API.Controllers.Product
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public ProductController(IProductRepository repository, IMapper mapper, ICompanyRepository companyRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }

        [HttpPost("category")]
        public async Task<IActionResult> AddCategory(CategoryForAddDto categoryDto)
        {
            int id = Extensions.GetSessionDetails(this).id;
            int plantId = Extensions.GetSessionDetails(this).plantId;

            var plant = await this.companyRepository.GetPlant(plantId);

            if (null == plant)
                return BadRequest($"Plant with the id {plantId} does not exists");

            var category = await this.repository.CategoryExists(categoryDto.categoryName, plantId);
            if (category)
                return BadRequest($"Category {categoryDto.categoryName} already Exists");


            var categoryToCreate = this.mapper.Map<Category>(categoryDto);
            categoryToCreate.creationUserId = id;
            categoryToCreate.updateUserId = id;
            categoryToCreate.plantId = plantId;

            this.repository.Add<Category>(categoryToCreate);
            await this.repository.SaveAll();
            return NoContent();
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories([FromQuery] UserParams userParams)
        {
            int plantId = Extensions.GetSessionDetails(this).plantId;

            var categories = await this.repository.GetCategories(userParams, plantId);
            var categoriesToReturn = this.mapper.Map<IEnumerable<CategoryForListDto>>(categories);

            Response.AddPagintaion(categories.currentPage, categories.pageSize, categories.totalCount, categories.totalPages);

            return Ok(categoriesToReturn);
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            int plantId = Extensions.GetSessionDetails(this).plantId;

            var category = await this.repository.GetCategory(id, plantId);
            var categoryToReturn = this.mapper.Map<CategoryForDetailsDto>(category);
            return Ok(categoryToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductForAddDto productDto)
        {
            int id = Extensions.GetSessionDetails(this).id;
            int plantId = Extensions.GetSessionDetails(this).plantId;

            var category = await this.repository.GetCategory(productDto.categoryId, plantId);
            if (null == category)
                return BadRequest($"Category with the id {productDto.categoryId} does not exists");

            var product = await this.repository.ProductExists(productDto.productName, plantId);
            if (product)
                return BadRequest($"Product {productDto.productName} already Exists");


            var productToCreate = this.mapper.Map<MegaStore.API.Models.Product.Product.Product>(productDto);
            productToCreate.creationUserId = id;
            productToCreate.updateUserId = id;

            this.repository.Add<MegaStore.API.Models.Product.Product.Product>(productToCreate);
            await this.repository.SaveAll();
            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] UserParams userParams)
        {
            int plantId = Extensions.GetSessionDetails(this).plantId;

            var products = await this.repository.GetProducts(userParams, plantId);
            var productToReturn = this.mapper.Map<IEnumerable<ProductForListDto>>(products);

            Response.AddPagintaion(products.currentPage, products.pageSize, products.totalCount, products.totalPages);

            return Ok(productToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            int plantId = Extensions.GetSessionDetails(this).plantId;

            var product = await this.repository.GetProduct(id, plantId);
            var productToReturn = this.mapper.Map<ProductForDetailsDto>(product);
            return Ok(productToReturn);
        }
    }
}