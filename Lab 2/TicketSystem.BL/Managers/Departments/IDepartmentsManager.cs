using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.Dtos;

namespace TicketSystem.BL;

public interface IDepartmentsManager
{
    List<DepartmentsReadDto> GetAllDepartments();
    DepartmentDetailsReadDto? GetDepartmentById(int id);
}
