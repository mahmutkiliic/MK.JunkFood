using MK.JunkFood.Core.Entities;

namespace MK.JunkFood.Core.Specifications
{
    /* Get the count of items so we can populate that in our pagination*/ 
    public class ProductWithFilterForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFilterForCountSpecification(ProductSpecParams productParams) : base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) && /*Searching*/
                (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&            /*filtering*/
                (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
        {
        }
    }
}
