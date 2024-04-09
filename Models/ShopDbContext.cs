using Microsoft.EntityFrameworkCore;
namespace TodoApi.Models
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) 
        : base(options)
        {}

        
        public DbSet<TodoItem> TodoItems { get; set; }
    }
    
}