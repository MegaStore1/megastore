using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Data.Core;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Product.Inventory;
using MegaStore.API.Models.Product.Product;
using Microsoft.EntityFrameworkCore;

namespace MegaStore.API.Data.ProductRepo
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly DataContext context;

        public ProductRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> CategoryExists(string categoryName, int plantId)
        {
            return await this.context.Category.AnyAsync(c => c.categoryName == categoryName && c.plantId == plantId);
        }

        public async Task<bool> ColorExists(string colorName, int plantId)
        {
            return await this.context.Color.AnyAsync(o => o.colorName == colorName && o.plantId == plantId);
        }

        public async Task<PagedList<Category>> GetCategories(UserParams userParams, int plantId)
        {
            var categories = this.context.Category.Include(o => o.plant).AsQueryable().Where(o => o.plantId == plantId);

            return await PagedList<Category>.CreateAsync(categories, userParams.pageNumber, userParams.pageSize);
        }

        public async Task<Category> GetCategory(int id, int plantId)
        {
            var category = await this.context.Category.Include(m => m.plant).FirstOrDefaultAsync(x => x.id == id && x.plantId == plantId);
            return category;
        }

        public async Task<Color> GetColor(int id, int plantId)
        {
            var color = await this.context.Color.FirstOrDefaultAsync(o => o.id == id && o.plantId == plantId);
            return color;
        }

        public async Task<ICollection<Color>> GetColors(int plantId)
        {
            var colors = await this.context.Color.Where(o => o.plantId == plantId).ToListAsync();
            return colors;
        }

        public async Task<Product> GetProduct(int id, int plantId)
        {
            var product = await this.context.Product
            .Include(m => m.category)
            .Include(o => o.files)
            .Include(o => o.color)
            .ThenInclude(o => o.plant)
            .Include(o => o.lines)
            .FirstOrDefaultAsync(x => x.id == id && x.category.plantId == plantId);
            return product;
        }

        public async Task<PagedList<Product>> GetProducts(UserParams userParams, int plantId)
        {
            var products = this.context.Product
            .Include(o => o.category)
            .Include(o => o.color)
            .Include(o => o.lines)
            .AsQueryable()
            .Where(o => o.category.plantId == plantId);

            return await PagedList<Product>.CreateAsync(products, userParams.pageNumber, userParams.pageSize);
        }

        public async Task<bool> ProductExists(string productName, int plantId)
        {

            return await this.context.Product.AnyAsync(c => c.productName == productName && c.category.plantId == plantId);
        }


        public async Task<ProductLine> GetLine(int id)
        {
            var line = await this.context.ProductLines
            .Include(m => m.product)
            .ThenInclude(o => o.category)
            .FirstOrDefaultAsync(x => x.id == id);
            return line;
        }

        public async Task<PagedList<ProductLine>> GetLines(UserParams userParams, int plantId)
        {
            var products = this.context.ProductLines
            .Include(o => o.product)
            .AsQueryable()
            .Where(o => o.product.category.plantId == plantId)
            .OrderBy(o => o.product.productName);

            return await PagedList<ProductLine>.CreateAsync(products, userParams.pageNumber, userParams.pageSize);
        }
    }
}