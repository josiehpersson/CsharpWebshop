using System;
using System.Collections.Generic;

public class CustomerDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }

    public ICollection<OrderDTO> Orders { get; set; }
}