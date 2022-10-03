using Code.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Code.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Categoryname).NotEmpty().WithMessage("CategoryName is reqitied")
            .MaximumLength(200).WithMessage("CategotyName must not exceed 200 characters")
            .MustAsync(BeUniqName).WithMessage("The specified categoryName alreadt exists");
        }
        public async Task<bool> BeUniqName(string categoryName, CancellationToken cancellationToken)
        {
            return await _context.Categories.AllAsync(x => x.CategoryName != categoryName, cancellationToken);
        }
    }
}
