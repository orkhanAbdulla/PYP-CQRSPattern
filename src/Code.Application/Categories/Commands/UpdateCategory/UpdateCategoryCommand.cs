using AutoMapper;
using Code.Application.Common.Interfaces;
using Code.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand:IRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
    }
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Categories.FirstOrDefault(c => c.Id == request.Id);
            if (entity == null)
                throw new Exception();
            _context.Categories.Update(_mapper.Map<Category>(request));
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
