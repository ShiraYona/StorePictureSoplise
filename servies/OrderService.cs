
using Entities;
using Microsoft.Extensions.Logging;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servies
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;

        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        public async Task<Order> CreateNewOrder(Order order)
        {
            double order_sum = 0;
            var o = order.OrderItems;
            foreach (OrderItem i in o)
            {
                double sum = await _orderRepository.getprice(i);
                sum = sum * (i.Quantity + 1);
                order_sum += sum;

            }
            if (order_sum != order.OrderSum)

            {
              
                _logger.LogInformation("{1} try to still!!!!!!!!!!! ", order.UserId);
                _logger.LogError($"try to still: {order.UserId}");
            }

            return await _orderRepository.CreateNewOrder(order);
           
        }
    }
}

