using AutoMapper;
using Code.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Categories.Queries.GetCategory
{
    public record GetCategoryQuery(int Id) : IRequest<CategoryDto>;
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<CategoryDto>(await _dbContext.Categories.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken));
        }
    }
}
