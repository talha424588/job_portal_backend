using JobPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Context
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options){
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Job> Jobs { get; set; }


        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
                .HasMany(j => j.skills)
                .WithOne()
                .HasForeignKey(j => j.id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
