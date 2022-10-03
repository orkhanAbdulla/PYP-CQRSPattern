using Code.Application.Common.Mappings;
using Code.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Categories.Queries.GetCategories
{
    public class CategoriesDto:IMapFrom<Category>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; } = null!;
    }
}
