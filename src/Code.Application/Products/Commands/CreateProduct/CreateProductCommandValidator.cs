using Code.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(v => v.ProductName)
                .NotEmpty().WithMessage("Product Name is required")
                .MaximumLength(200).WithMessage("Product must not exceed 200 character");
        }
    }
}
