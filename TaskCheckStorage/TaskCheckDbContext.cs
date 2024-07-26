using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskCheckStorage.Entities;

namespace TaskCheckStorage
{
    public class TaskCheckDbContext : DbContext
    {
        private IConfiguration configuration { get; }
        public DbSet<UserTask> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }


        public TaskCheckDbContext()
            :base()
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDb;database=TaskCheck_Project;trusted_connection=true;",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "TaskCheck"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserTask>()
            .HasOne(t => t.User)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<UserTask>()
            .HasOne(t => t.Category)
            .WithMany(c => c.Tasks)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.User)
                .WithMany(u => u.Categories)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
