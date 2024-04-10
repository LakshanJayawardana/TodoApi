using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class ShopDbContext : IdentityDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
            
        }

        
        public DbSet<TodoItem> TodoItems { get; set; }
    }
    
}