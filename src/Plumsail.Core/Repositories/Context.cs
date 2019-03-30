using Microsoft.EntityFrameworkCore;

using Plumsail.Core.Models;

namespace Plumsail.Core.Repositories
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
