using System;
using System.Collections.Generic;

public class Order
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public int TotalPrice { get; set; }

    public ICollection<OrderRow> OrderRows { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}