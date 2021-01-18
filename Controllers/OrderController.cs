using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace dotnetwebshop.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ProductContext _context;
        private readonly IMapper _mapper;

        public OrderController(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            List<Order> orders = await _context.Orders.Include(o => o.Customer).ToListAsync();
            List<OrderDTO> orderDTOs = _mapper.Map<List<OrderDTO>>(orders);

            return Ok(orderDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            Order found = await _context.Orders.FindAsync(id);

            if (found == null)
            {

                return NotFound();
            }

            return Ok(_mapper.Map<OrderDTO>(found));
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(OrderDTO newOrderDTO)
        {
            Order newOrder = _mapper.Map<Order>(newOrderDTO);
            newOrder.Created = DateTime.Now;

             _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("CreateOrder", newOrder);

        }
    }
}