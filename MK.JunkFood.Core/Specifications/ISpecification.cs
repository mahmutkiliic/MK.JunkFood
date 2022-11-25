using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MK.JunkFood.Core.Specifications
{
    public interface ISpecification<T> 
    {
        Expression<Func<T,bool>>Criteria { get; }

        List<Expression<Func<T,object>>> Includes { get; }

        /* Sorting */
        Expression<Func<T,object>> OrderByAscending { get; }
        Expression<Func<T,object>> OrderByDescending { get; }

        /* Pagination */
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
