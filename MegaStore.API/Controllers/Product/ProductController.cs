using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Data.ProductRepo;
using MegaStore.API.Data.Settings.CompanyRepo;
using MegaStore.API.Dtos.Product;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Product.Inventory;
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
        public async Task<IActionResult> AddProduct([FromForm] ProductForAddDto productDto)
        {
            int id = Extensions.GetSessionDetails(this).id;
            int plantId = Extensions.GetSessionDetails(this).plantId;

            var category = await this.repository.GetCategory(productDto.categoryId, plantId);
            if (null == category)
                return BadRequest($"Category with the id {productDto.categoryId} does not exists");

            var product = await this.repository.ProductExists(productDto.productName, plantId);
            if (product)
                return BadRequest($"Product {productDto.productName} already Exists");

            productDto.files = new Collection<ProductFileForAddDto>();

            if (productDto.imagesOrVideos != null)
            {
                foreach (FormFile file in productDto.imagesOrVideos)
                {
                    string fileName = await FileManager.Upload(file, "Product/Files");
                    ProductFileForAddDto productFile = new ProductFileForAddDto();
                    productFile.fileName = fileName;
                    productFile.fileLength = file.Length;
                    productFile.contentType = file.ContentDisposition;
                    productFile.fileType = file.ContentType;
                    productFile.creationUserId = id;
                    productFile.updateUserId = id;
                    productDto.files.Add(productFile);
                }
            }
            var productToCreate = this.mapper.Map<MegaStore.API.Models.Product.Product.Product>(productDto);

            productToCreate.creationUserId = id;
            productToCreate.updateUserId = id;

            this.repository.Add<MegaStore.API.Models.Product.Product.Product>(productToCreate);
            await this.repository.SaveAll();
            return NoContent();
        }

        [HttpPost("addFile")]
        public async Task<IActionResult> AddFile([FromForm] ProductFileListForAddDto fileDto)
        {
            int id = Extensions.GetSessionDetails(this).id;
            int plantId = Extensions.GetSessionDetails(this).plantId;

            var product = await this.repository.GetProduct(fileDto.productId, plantId);
            if (product == null)
                return BadRequest($"Product with id {fileDto.productId} does not Exists");

            if (fileDto.imagesOrVideos != null)
            {
                foreach (FormFile file in fileDto.imagesOrVideos)
                {
                    string fileName = await FileManager.Upload(file, "Product/Files");
                    ProductFileForAddDto productFile = new ProductFileForAddDto();
                    productFile.fileName = fileName;
                    productFile.fileLength = file.Length;
                    productFile.contentType = file.ContentDisposition;
                    productFile.fileType = file.ContentType;
                    productFile.productId = fileDto.productId;
                    productFile.creationUserId = id;
                    productFile.updateUserId = id;
                    var productFileToCreate = this.mapper.Map<ProductFile>(productFile);
                    this.repository.Add<ProductFile>(productFileToCreate);
                }
            }
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


        // Attribute Functions
        [HttpPost("color")]
        public async Task<IActionResult> AddColor(ColorForAddDto colorDto)
        {
            int id = Extensions.GetSessionDetails(this).id;
            int plantId = Extensions.GetSessionDetails(this).plantId;

            var plant = await this.companyRepository.GetPlant(plantId);
            if (null == plant)
                return BadRequest($"Plant with the id {plantId} does not exists");

            var color = await this.repository.ColorExists(colorDto.colorName, plantId);
            if (color)
                return BadRequest($"Color {colorDto.colorName} already Exists");


            var colorToCreate = this.mapper.Map<Color>(colorDto);
            colorToCreate.creationUserId = id;
            colorToCreate.updateUserId = id;
            colorToCreate.plantId = plantId;

            this.repository.Add<Color>(colorToCreate);
            await this.repository.SaveAll();
            return NoContent();
        }

        [HttpGet("color")]
        public async Task<IActionResult> GetColors(int id)
        {
            int plantId = Extensions.GetSessionDetails(this).plantId;

            var colors = await this.repository.GetColors(plantId);
            var colorToReturn = this.mapper.Map<ICollection<ColorDto>>(colors);
            return Ok(colorToReturn);
        }

        [HttpPost("line")]
        public async Task<IActionResult> AddLine(ProductLineToCreateDto productLineDto)
        {
            int id = Extensions.GetSessionDetails(this).id;
            int plantId = Extensions.GetSessionDetails(this).plantId;

            var product = await this.repository.GetProduct(productLineDto.productId, plantId);
            if (product == null)
                return BadRequest($"Product with id {productLineDto.productId} does not Exists");

            ProductLine lineToCreate = this.mapper.Map<ProductLine>(productLineDto);
            lineToCreate.creationUserId = id;
            lineToCreate.updateUserId = id;

            this.repository.Add<ProductLine>(lineToCreate);
            await this.repository.SaveAll();
            return NoContent();
        }

        [HttpDelete("line/{id}")]
        public async Task<IActionResult> DeleteLine(int id)
        {
            var lineToDelete = await this.repository.GetLine(id);
            if (lineToDelete == null)
                return BadRequest($"Line with id {id} does not Exists");
            this.repository.Delete(lineToDelete);
            await this.repository.SaveAll();
            return NoContent();
        }

        [HttpGet("line/{id}")]
        public async Task<IActionResult> GetLine(int id)
        {
            var line = await this.repository.GetLine(id);
            var lineToReturn = this.mapper.Map<ProductLineForDetailsDto>(line);
            return Ok(lineToReturn);
        }

        [HttpGet("lines")]
        public async Task<IActionResult> GetLines([FromQuery] UserParams userParams)
        {
            int plantId = Extensions.GetSessionDetails(this).plantId;

            var lines = await this.repository.GetLines(userParams, plantId);
            var linesToReturn = this.mapper.Map<IEnumerable<ProductLineDto>>(lines);

            Response.AddPagintaion(lines.currentPage, lines.pageSize, lines.totalCount, lines.totalPages);

            return Ok(linesToReturn);
        }
    }
}