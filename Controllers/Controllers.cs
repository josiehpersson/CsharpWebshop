using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace dotnetwebshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context) {
            _context = context;
        }
        
        [HttpGet]
        public async Task<List<Product>> Get() {
            return await _context.Products.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        [HttpPost]
        public async Task<Product> CreateProduct(Product newProduct)
        {
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return newProduct;
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
    private readonly ProductContext _context;

        public CustomerController() { }

        [HttpGet]
        public List<Customer> GetCustomers()
        {
            return new List<Customer>();
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class OrderRowController : ControllerBase
    {
        private readonly ProductContext _context;

        public OrderRowController() { }

        [HttpGet]
        public List<OrderRow> GetOrderRows()
        {
            return new List<OrderRow>();
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ProductContext _context;

        public OrderController() { }

        [HttpGet]
        public List<Order> GetOrders()
        {
            return new List<Order>();
        }

        [HttpPost]
        public async Task<Order> CreateOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            return newOrder;
        }


    }
}
