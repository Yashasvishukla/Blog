using Microsoft.EntityFrameworkCore;
using ToDo.API.Models;

namespace ToDo.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; } 
    }
}