using System;
using System.Collections.Generic;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int ZipCode {get; set;}
    public string City { get; set; }

    public ICollection<Order> Orders { get; set; }
}