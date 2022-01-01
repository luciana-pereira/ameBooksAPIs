using Microsoft.EntityFrameworkCore;

namespace AmeBooks.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> option) : base (option)
        {

        }

        public DbSet<Product> todoProducts { get; set; }

    }
}
