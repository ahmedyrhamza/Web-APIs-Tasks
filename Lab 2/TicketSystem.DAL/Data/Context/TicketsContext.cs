using Microsoft.EntityFrameworkCore;

namespace TicketSystem.DAL;

public class TicketsContext : DbContext
{
    public DbSet<Ticket> Tickets        => Set<Ticket>       (); // just like context.Tickets
    public DbSet<Developer> developers  => Set<Developer>    ();
    public DbSet<Department> departments => Set<Department>();
    public TicketsContext(DbContextOptions<TicketsContext> options) 
        : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed Tickets
        modelBuilder.Entity<Ticket>().HasData(
            new Ticket { Id = 1, Description = "Very cool ticket", Title = "Ticket 1 Title", DepartmentId = 1 },
            new Ticket { Id = 2, Description = "weird bug", Title = "Ticket 2 Title", DepartmentId = 1 }
        );

        // Seed Departments
        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Web App Development Department" },
            new Department { Id = 2, Name = "Mobile App Development Department" }
        );

        // Seed Developers
        modelBuilder.Entity<Developer>().HasData(
            new Developer { Id = 1, Name = "Developer 1" },
            new Developer { Id = 2, Name = "Developer 2" },
            new Developer { Id = 3, Name = "Developer 3" },
            new Developer { Id = 4, Name = "Developer 4" },
            new Developer { Id = 5, Name = "Developer 5" },
            new Developer { Id = 6, Name = "Developer 6" },
            new Developer { Id = 7, Name = "Developer 7" },
            new Developer { Id = 8, Name = "Developer 8" },
            new Developer { Id = 9, Name = "Developer 9" },
            new Developer { Id = 10, Name = "Developer 10" }
        );
    }
}
