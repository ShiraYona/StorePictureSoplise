

using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDataBase1Context _DbContext;

        public OrderRepository(StoreDataBase1Context dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<Order> CreateNewOrder(Order order)
        {
            await _DbContext.AddAsync(order);
             await _DbContext.SaveChangesAsync();
            return order;

        }
        public async Task<double> getprice(OrderItem order)
        {
            Product product = _DbContext.Products.Where(item => item.ProductId == order.ProductId).FirstOrDefault();
            return  (double)product.Price;
        }
    }
}
