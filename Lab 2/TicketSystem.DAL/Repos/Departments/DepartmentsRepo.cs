using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DAL;

public class DepartmentsRepo: IDepartmentsRepo
{
    private readonly TicketsContext _context;

    public DepartmentsRepo(TicketsContext context)
    {
        _context = context;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _context.Set<Department>().AsNoTracking();
    }

    public Department? GetDepartmentById(int id)
    {
        return _context.Set<Department>().Find(id);
    }

    public Department? GetDepartmentWithItsTicketsAndDevelopers(int id)
    {
        return _context.Set<Department>()
            .Include(d => d.Tickets)
                .ThenInclude(t => t.Developers)
            .FirstOrDefault(t => t.Id == id);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
