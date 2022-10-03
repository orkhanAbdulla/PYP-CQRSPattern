using Code.Application.Common.Interfaces;
using Code.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryComman(int id) : IRequest { }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryComman>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCategoryComman request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories.Where(x => x.Id == request.id).SingleOrDefaultAsync();
            if (entity==null)
            {
                throw new Exception();
            }
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
