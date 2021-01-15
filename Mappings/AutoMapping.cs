using AutoMapper;

public class AutoMapping : Profile
{

    public AutoMapping()
    {
        CreateMap<Customer, CustomerDTO>();
        CreateMap<CustomerDTO, Customer>();

        CreateMap<Order, OrderDTO>();
        CreateMap<OrderDTO, Order>();

        CreateMap<OrderRow, OrderRowDTO>();
        CreateMap<OrderRowDTO, OrderRow>();

        CreateMap<Product, ProductDTO>();
        CreateMap<ProductDTO, Product>();
    }

}