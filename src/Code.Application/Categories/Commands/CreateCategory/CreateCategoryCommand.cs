using AutoMapper;
using Code.Application.Common.Interfaces;
using Code.Domain.Entity;
using FluentValidation.Validators;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand:IRequest<int>
    {
        public string Categoryname { get; set; } = null!;
        public string? Description { get; set; } = null!;
    }
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            EntityEntry<Category> category=_context.Categories.Add(_mapper.Map<Category>(request));
            await _context.SaveChangesAsync(cancellationToken);
            return category.Entity.Id;
        }
    }
}
