using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using goblin_cheese.Models.Game;
using goblin_cheese.Areas.Identity.Data;

namespace goblin_cheese.Data;

public class ApplicationDbContext : IdentityDbContext<GoblinUser>
{
    public DbSet<Game> Game { get; set; } = default!;
    public DbSet<Screenshot> Screenshot { get; set; } = default!;
    public DbSet<Genre> Genre { get; set; } = default!;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    
}
