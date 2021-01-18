using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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
            //Customer customer = new Customer();
            Order newOrder = _mapper.Map<Order>(newOrderDTO);
            //int custId = await CreateCustomer(newOrderDTO.CustomerDTO);
            newOrder.Created = DateTime.Now; 
            //newOrder.CustomerId = customer.Id;

             _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("CreateOrder", newOrder);
        }

        public async Task<int>CreateCustomer(CustomerDTO newCustomerDTO) {
        Customer newCustomer = new Customer() {
        Name = newCustomerDTO.Name
        };
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            return newCustomer.Id;
        }

    }
}