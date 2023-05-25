using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Data.OrderRepo;
using MegaStore.API.Data.ProductRepo;
using MegaStore.API.Data.Settings.CompanyRepo;
using MegaStore.API.Dtos.Order;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MegaStore.API.Controllers.Order
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository repository;
        private readonly ICompanyRepository companyRepository;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public OrderController(
            IOrderRepository repository,
            ICompanyRepository companyRepository,
            IProductRepository productRepository,
            IMapper mapper
        )
        {
            this.repository = repository;
            this.companyRepository = companyRepository;
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            int plantId = Extensions.GetSessionDetails(this).plantId;

            var order = await this.repository.GetOrder(id, plantId);
            var orderToReturn = this.mapper.Map<OrderDetailsDto>(order);
            return Ok(orderToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] UserParams userParams)
        {
            int plantId = Extensions.GetSessionDetails(this).plantId;

            var orders = await this.repository.GetOrders(userParams, plantId);

            var ordersToReturn = this.mapper.Map<IEnumerable<OrderForListDto>>(orders);

            Response.AddPagintaion(orders.currentPage, orders.pageSize, orders.totalCount, orders.totalPages);

            return Ok(ordersToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderForAddDto orderDto)
        {
            int id = Extensions.GetSessionDetails(this).id;
            int plantId = Extensions.GetSessionDetails(this).plantId;


            var orderToCreate = this.mapper.Map<MegaStore.API.Models.Order.Order>(orderDto);

            foreach (OrderLine line in orderToCreate.lines)
            {
                line.creationUserId = id;
                line.updateUserId = id;
            }

            orderToCreate.creationUserId = id;
            orderToCreate.updateUserId = id;
            orderToCreate.customerId = id;
            orderToCreate.plantId = plantId;

            this.repository.Add<MegaStore.API.Models.Order.Order>(orderToCreate);

            await this.repository.SaveAll();
            return NoContent();
        }
    }
}