using MK.JunkFood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MK.JunkFood.Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpec : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpec(ProductSpecParams productParams) 
            : base(x=> 
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) && /* searching*/
                (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&            /*filtering*/
                (!productParams.TypeId.HasValue || x.ProductTypeId== productParams.TypeId)            
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderByAscending(x => x.Name);
            
            /* Skip and take parameters inside ApplyPaging, using minus 1 is necessary because if page number is 1 we don't want to skip the elements in first page */
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderByAscending(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderByAscending(x=>x.Name);
                        break;
                }
            }
            
        }

        public ProductsWithTypesAndBrandsSpec(int id) : base(x=>x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
