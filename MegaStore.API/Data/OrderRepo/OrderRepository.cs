using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Data.Core;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Order;
using Microsoft.EntityFrameworkCore;

namespace MegaStore.API.Data.OrderRepo
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        private readonly DataContext context;

        public OrderRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Order> GetOrder(int id, int plantId)
        {
            var order = await this.context.Orders
                .Include(o => o.lines)
                .ThenInclude(o => o.productLine)
                .Include(o => o.plant)
                .FirstOrDefaultAsync(o => o.id == id && o.plantId == plantId);
            return order;
        }

        public async Task<PagedList<Order>> GetOrders(UserParams userParams, int plantId)
        {
            var orders = this.context.Orders
                .Include(o => o.plant)
                .Include(o => o.lines).AsQueryable();

            if (plantId > 0)
            {
                orders = orders.Where(o => o.plantId == plantId);
            }

            if (userParams.customerId > 0)
            {
                orders = orders.Where(x => x.customerId == userParams.customerId);
            }

            return await PagedList<Order>.CreateAsync(orders, userParams.pageNumber, userParams.pageSize);
        }
    }
}