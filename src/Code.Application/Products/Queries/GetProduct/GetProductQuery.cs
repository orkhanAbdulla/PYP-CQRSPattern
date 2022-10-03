using AutoMapper;
using Code.Application.Categories.Queries.GetCategory;
using Code.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Products.Queries.GetProduct
{
        public record class GetProductQuery(int Id) : IRequest<ProductDto>;
        public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetProductQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<ProductDto>(await _dbContext.Products.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken));
            }
        }
    }

