using AutoMapper;
using AutoMapper.QueryableExtensions;
using Code.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Products.Queries.GetProducts
{
    public record GetProductsQuery : IRequest<IEnumerable<ProductsDto>>;
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductsDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductsHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductsDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.AsNoTracking()
               .ProjectTo<ProductsDto>(_mapper.ConfigurationProvider)
               .OrderBy(c => c.Name)
               .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
