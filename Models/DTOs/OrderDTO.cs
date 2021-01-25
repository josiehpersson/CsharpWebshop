using System;
using System.Collections.Generic;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public int TotalPrice { get; set; }

    //public List<OrderRow> OrderRows {get; set;}
    public ICollection<OrderRowDTO> OrderRows {get; set;}
   // public OrderRowDTO OrderRowDTO {get; set;}

    public int CustomerId {get; set;}
    public CustomerDTO CustomerDTO{ get; set; }
}