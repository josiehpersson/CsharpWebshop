using System;
using System.Collections.Generic;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public int TotalPrice { get; set; }

    public ICollection<OrderRowDTO> OrderRowsDTO { get; set; }

    public int CustomerDTOId { get; set; }
    public CustomerDTO CustomerDTO { get; set; }
}