using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DAL;

public interface IDepartmentsRepo
{
    IEnumerable<Department> GetAllDepartments();

    Department? GetDepartmentById(int departmentId);

    Department? GetDepartmentWithItsTicketsAndDevelopers(int departmentId);

    int SaveChanges();
}
