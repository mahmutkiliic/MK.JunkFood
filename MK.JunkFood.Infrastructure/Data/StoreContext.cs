using Microsoft.EntityFrameworkCore;
using MK.JunkFood.Core.Entities;

namespace MK.JunkFood.Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {             
        }

        public DbSet<Product> Products { get; set; }


    }

}
