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

namespace Code.Application.Categories.Queries.GetCategories
{
    public record GetCategoriesQuery:IRequest<IEnumerable<CategoriesDto>>;
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoriesDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    
        public async Task<IEnumerable<CategoriesDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories =await _context.Categories.AsNoTracking()
           .ProjectTo<CategoriesDto>(_mapper.ConfigurationProvider).OrderBy(x => x.CategoryName)
           .ToListAsync(cancellationToken);

            return categories;
        }
    }
}
