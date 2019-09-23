using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }
        public DbSet<FieldModel> Fields { get; set; }
    }
}
