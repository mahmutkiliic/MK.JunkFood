using Microsoft.EntityFrameworkCore;
using MK.JunkFood.Core.Entities;
using MK.JunkFood.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.JunkFood.Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderByAscending != null)
            {
                query = query.OrderBy(spec.OrderByAscending);
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            /* MUST: Paging operators need to come after any filtering and sorting operations.*/
            if(spec.IsPagingEnabled)
            {
                query=query.Skip(spec.Skip).Take(spec.Take);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;

        }
    }
}
