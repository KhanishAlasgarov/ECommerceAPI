using AutoMapper;
using ECommerceAPI.Application.Features.Commands.Product.CreateProduct;
using ECommerceAPI.Application.Features.Queries.Product.GetProductById;
using ECommerceAPI.Application.Features.Queries.Product.GetProductByName;
using ECommerceAPI.Application.Features.Queries.Product.GetProductImages;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using P = ECommerceAPI.Domain.Entities;
namespace ECommerceAPI.Application.Profiles;

public class ProductMappingProfile : Profile
{
    IConfiguration _configuration { get; }
    public ProductMappingProfile(IConfiguration configuration)
    {
        _configuration = configuration;
        CreateMap<P::Product, CreateProductCommandRequest>().ReverseMap();
        CreateMap<P::Product, GetProductByIdQueryResponse>().ReverseMap();
        CreateMap<P::Product, GetProductByNameQueryResponse>().ReverseMap();

        CreateMap<P::ProductImageFile, GetProductImagesQueryResponse>().ForMember(destinationMember: x => x.Path, memberOptions: opt => opt.MapFrom(x => $"{_configuration["BaseStorageUrl"]}/{x.Path}"));

    }
}
