using System;
using System.Collections.Generic;

public class OrderRowDTO
{
    public int OrderDTOId { get; set; }
    public OrderDTO OrderDTO { get; set; }

    public int ProductDTOId { get; set; }
    public ProductDTO ProductDTO { get; set; }
}