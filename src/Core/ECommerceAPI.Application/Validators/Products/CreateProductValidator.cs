using ECommerceAPI.Domain.Entities;
using FluentValidation;

namespace ECommerceAPI.Application.Validators.Products;

public class CreateProductValidator : AbstractValidator<ProductDto>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("sa");
    }
}
public class ProductDto
{
    public string? Name { get; set; }
}
