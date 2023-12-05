
using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using servies;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;

        }
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Post([FromBody] OrderDto orderDto)
        {

            Order o1 = _mapper.Map<OrderDto, Order>(orderDto);
            Order order=  await _orderService.CreateNewOrder(o1);
            OrderDto orderDto1 = _mapper.Map<Order, OrderDto>(order);
            if (orderDto1 == null)
            {
                return NoContent();
            }

           
            return orderDto1;
        }
    }
}
 