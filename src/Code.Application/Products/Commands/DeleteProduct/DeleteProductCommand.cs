﻿using Code.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(int id):IRequest;
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IApplicationDbContext _aplicationDbContext;

        public DeleteProductCommandHandler(IApplicationDbContext aplicationDbContext)
        {
            _aplicationDbContext = aplicationDbContext;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _aplicationDbContext.Products.Where(x => x.Id == request.id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception("");
            }
            _aplicationDbContext.Products.Remove(entity);
            await _aplicationDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
