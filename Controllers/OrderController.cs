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
            List<Order> orders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderRows)
                .ToListAsync();
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
            Customer cust = await CreateCustomer(newOrderDTO.CustomerDTO); 
            //anropar metoden som skapar en customer
            CustomerDTO custD = _mapper.Map<CustomerDTO>(cust); 
            //automappar objektet vi hämtat in från CreateCustomer

            Order newOrder = _mapper.Map<Order>(newOrderDTO); 
            //automappar objektet newOrderDTO till newOrder.
            newOrder.Created = DateTime.Now; 
            //skapar datum för order
            newOrder.CustomerId = cust.Id; 
            //lägger till Id:t från cust i newOrders CustomerId.
            newOrder.OrderRows = new List<OrderRow>(); 
            //skapar en ny lista i newOrders property OrderRows

             _context.Orders.Add(newOrder); 
            //sparar newOrder
            await _context.SaveChangesAsync(); 
            //lägger till newOrder i DB
            
            OrderDTO newOrderD = _mapper.Map<OrderDTO>(newOrder); 
            //automappar objektet newOrder till newOrderD
            newOrderD.CustomerDTO = custD; 
            //lägger till objektet custD som newOrderD's CustomerDTO

            List<OrderRow> or = await CreateOrderRow(newOrderDTO.OrderRows, newOrder.Id); 
            //anropar metoden som skapar en lista med orderrows, skickar in vårt orderId

            List<OrderRowDTO> orderRowD = _mapper.Map<List<OrderRowDTO>>(or); 
            //automappar listan or till orderRowD
            newOrderD.OrderRows = orderRowD; 
            //ger newOrderD's propery OrderRows värdet av orderRowD

            int sum = 0;
            foreach(OrderRow orderrow in newOrder.OrderRows) {
            int pricetag = (await _context.Products.FirstAsync(prod => prod.Id == orderrow.ProductId)).Price;
            sum = sum + pricetag;
            }
            newOrderD.TotalPrice = sum;
            await _context.SaveChangesAsync();

            return CreatedAtAction("CreateOrder", newOrderD); 
            //returnerar objektet newOrderD
        }

        public async Task<List<OrderRow>> CreateOrderRow(ICollection<OrderRowDTO> newOrderRowDTO, int orderId) 
        {
            List<OrderRow> newlyCreatedOrderRows = new List<OrderRow>(); 
            //skapar en lista med datatypen OrderRow

            foreach(OrderRowDTO orDto in newOrderRowDTO) {
                //skapar en loop som går igenom varje objekt av datatypen OrderRowDTO i newOrderRowDTO 
                OrderRow newOrderRow = new OrderRow()
                //skapar en ny instans av OrderRow
                {
                    OrderId = orderId,
                    //lägger till orderId som vi skickade till metoden genom anropet, i OrderId propertyn i OrderRow
                    ProductId = orDto.ProductId
                    //lägger till ProductId av produkter som skickas in
                };

                _context.OrderRows.Add(newOrderRow);
                //sparar newOrderRow
                await _context.SaveChangesAsync();
                //lägger till ändringarna i DB
                newlyCreatedOrderRows.Add(newOrderRow);
                //lägger till en newOrderRow i listan newlyCreatedOrderRows
            }

            return newlyCreatedOrderRows;
        }

        public async Task<Customer>CreateCustomer(CustomerDTO newCustomerDTO) 
        {
        Customer newCustomer = new Customer() 
        {
        Name = newCustomerDTO.Name,
        Address = newCustomerDTO.Address,
        ZipCode = newCustomerDTO.ZipCode,
        City = newCustomerDTO.City
        };
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return newCustomer;
        }

     }

}