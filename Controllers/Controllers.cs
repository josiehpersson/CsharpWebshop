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
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;
        private readonly IMapper _mapper;

        public ProductController(ProductContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetProducts() {
            List<Product> products = await _context.Products.ToListAsync();
            List<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);

            return Ok(productDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            Product found = await _context.Products.FindAsync(id);

            if(found == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductDTO>(found));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductDTO newProductDTO)
        {
            Product newProduct = _mapper.Map<Product>(newProductDTO);
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("CreateProduct", newProduct);
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
    private readonly ProductContext _context;
        private readonly IMapper _mapper;

        public CustomerController(ProductContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper; 
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            List<Customer> customers = await _context.Customers.Include(c => c.Orders).ToListAsync();
            List<CustomerDTO> customerDTOs = _mapper.Map<List<CustomerDTO>>(customers);

            return Ok(customerDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            Customer found = await _context.Customers.FindAsync(id);

            if(found == null) {
            return NotFound();
            }

            return Ok(_mapper.Map<CustomerDTO>(found));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CustomerDTO newCustomerDTO) {
        Customer newCustomer = _mapper.Map<Customer>(newCustomerDTO);

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("CreateCustomer", newCustomer);
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class OrderRowController : ControllerBase
    {
        private readonly ProductContext _context;
        private readonly IMapper _mapper;

        public OrderRowController(ProductContext context, IMapper mapper) { 
        _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrderRows()
        {
           List<OrderRow> orderRows = await _context.OrderRows.Include(or => or.Order).Include(or=> or.Product).ToListAsync();
            List<OrderRowDTO> orderRowDTOs = _mapper.Map<List<OrderRowDTO>>(orderRows);

            return Ok(orderRowDTOs);
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ProductContext _context;
        private readonly IMapper _mapper;

        public OrderController(ProductContext context, IMapper mapper) {
        _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            List<Order> orders = await _context.Orders.Include(o=> o.Customer).ToListAsync();
            List<OrderDTO> orderDTOs = _mapper.Map<List<OrderDTO>>(orders);

            return Ok(orderDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            Order found = await _context.Orders.FindAsync(id);

            if(found == null){
            
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
