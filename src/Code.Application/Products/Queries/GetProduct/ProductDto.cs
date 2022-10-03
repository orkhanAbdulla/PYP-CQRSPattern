using Code.Application.Common.Mappings;
using Code.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Products.Queries.GetProduct
{
    public class ProductDto:IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
