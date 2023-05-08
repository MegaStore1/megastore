using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Data.Core;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Product.Product;

namespace MegaStore.API.Data.ProductRepo
{
    public interface IProductRepository : IBaseRepository
    {
        Task<PagedList<Product>> GetProducts(UserParams userParams, int plantId);
        Task<bool> ProductExists(string productName, int plantId);
        Task<bool> CategoryExists(string categoryName, int plantId);
        Task<Product> GetProduct(int id, int plantId);
        Task<PagedList<Category>> GetCategories(UserParams userParams, int plantId);
        Task<Category> GetCategory(int id, int plantId);

        // Product Attributes
        Task<ICollection<Color>> GetColors(int plantId);
        Task<bool> ColorExists(string colorName, int plantId);
        Task<Color> GetColor(int id, int plantId);

    }
}