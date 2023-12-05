


using Entities;

namespace servies
{
    public interface IOrderService
    {
        Task<Order> CreateNewOrder(Order order);
    }
}