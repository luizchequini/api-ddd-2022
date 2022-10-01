using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration;

public class ContextBase : IdentityDbContext<ApplicationUser>
{
    public ContextBase(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Message> Messages { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ObterStringConexao());
            base.OnConfiguring(optionsBuilder);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
        base.OnModelCreating(builder);
    }

    public string ObterStringConexao()
    {
        //return @"Data Source=DESKTOP-GE1B99A\SQLEXPRESS;Initial Catalog=API_Net6_DDD2022;Integrated Security=False";
        return "server=DESKTOP-GE1B99A\\SQLEXPRESS; Database=API_Net6_DDD2022;Integrated Security=SSPI;";
    }
}
