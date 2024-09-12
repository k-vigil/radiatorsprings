using Microsoft.Extensions.Configuration;

namespace RadiatorSprings.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    private readonly IConfiguration _configuration;
    public DbSet<Category> Categories { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserPermission> UserPermissions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conn = _configuration.GetConnectionString("Default");
        
        optionsBuilder.UseNpgsql(conn);

        base.OnConfiguring(optionsBuilder);
    }
}
