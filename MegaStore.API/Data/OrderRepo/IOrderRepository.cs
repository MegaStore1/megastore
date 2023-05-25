using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Data.Core;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Order;

namespace MegaStore.API.Data.OrderRepo
{
    public interface IOrderRepository : IBaseRepository
    {
        Task<PagedList<Order>> GetOrders(UserParams userParams, int plantId);
        Task<Order> GetOrder(int id, int plantId);
    }
}