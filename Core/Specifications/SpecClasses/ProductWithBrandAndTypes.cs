using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications.SpecClasses
{
    public class ProductWithBrandAndTypes : BaseSpecification<Product>
    {
        public ProductWithBrandAndTypes()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }

        public ProductWithBrandAndTypes(int id) : base(x => x.Id == id)
        {  
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}