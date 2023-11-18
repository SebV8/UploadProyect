using Microsoft.EntityFrameworkCore;
using WODMaster.DAL.Entities;

namespace WODMaster.DAL;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {

    }

    public DbSet<User> User { get; set; }
    public DbSet<Membership> Membership { get; set; }
    public DbSet<Enrollment> Enrollment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(e => e.Id);

        modelBuilder.Entity<Membership>().HasKey(e => e.Id);

        modelBuilder.Entity<Enrollment>().HasKey(e => e.Id);
    }
}
