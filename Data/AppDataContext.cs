// using Microsoft.EntityFrameworkCore;

// namespace FirstApp.Data
// {
//     public class AppDataContext : DbContext
//     {
//         public DbSet<User> User { get; set; } // Adicione esta propriedade

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
//         }
//     }
// }
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Email);
        }
    }
}
