using Microsoft.EntityFrameworkCore;

namespace Stamp.Site.Models;

public class StampDbContext:DbContext
{
    public StampDbContext()
    {
    }
    public StampDbContext(DbContextOptions<StampDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees  { get; set; }
    public DbSet<StampMaintenance> StampMaintenances { get; set; }
    public DbSet<StampOutput> StampOutputs { get; set; }
    public DbSet<StampResult> StampResults { get; set; }
    public DbSet<StampMaker> StampMakers { get; set; }


}