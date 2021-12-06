using Abby.Model;
using Microsoft.EntityFrameworkCore;

namespace Abby.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // Allows the passing of connection string into the database constructor
        {

        }
        public DbSet<Category> Category { get; set; } // This uses the model as a definition to generate and work with a table in the database named "Category"
    }
}
