using AutoMapper;
using ECommerceAPI.Application.Features.Commands.Product.CreateProduct;
using P = ECommerceAPI.Domain.Entities;
namespace ECommerceAPI.Application.Profiles;

public partial class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<P::Product, CreateProductCommandRequest>().ReverseMap();
    }
}
