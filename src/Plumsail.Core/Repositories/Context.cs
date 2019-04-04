using Microsoft.EntityFrameworkCore;

using Plumsail.Core.Models;

namespace Plumsail.Core.Repositories
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Phone> Phones { get; set; }
    }
}
