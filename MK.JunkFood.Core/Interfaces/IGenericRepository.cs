using MK.JunkFood.Core.Entities;
using MK.JunkFood.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.JunkFood.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListEntityWithSpecAsync(ISpecification<T> spec);

        Task<int> CountAsync(ISpecification<T> spec);

    }
}
