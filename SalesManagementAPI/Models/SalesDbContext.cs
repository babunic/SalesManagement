using Microsoft.EntityFrameworkCore;

public class SalesDbContext : DbContext
{
    public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }

    public DbSet<SalesRecord> SalesRecords { get; set; }
    public DbSet<SalesRepresentative> SalesRepresentatives { get; set; }
}