using System;
using System.Collections.Generic;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime Created { get; set; }
    public int orderRows { get; set; }
    public int TotalPrice { get; set; }
}