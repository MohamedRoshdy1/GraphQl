using GraphQlTask.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace GraphQlTask.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public virtual DbSet<Product> Products { get; set; }
}
