using Microsoft.EntityFrameworkCore;
using Week6Capstone.Models;

namespace Week6Capstone.Data
{
    public class CapstoneDbContext : DbContext
    {
        public CapstoneDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
       public DbSet<LoginModel> Users { get; set; }
       
       public DbSet<TaskModel> TaskList { get; set; }
    }
}
