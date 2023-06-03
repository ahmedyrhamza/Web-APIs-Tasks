using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.Dtos;
using TicketSystem.DAL;

namespace TicketSystem.BL;

public class DepartmentsManager: IDepartmentsManager
{
    private readonly IDepartmentsRepo _departmentsRepo;

    public DepartmentsManager(IDepartmentsRepo departmentsRepo) 
    {
        _departmentsRepo = departmentsRepo;
    }

    public List<DepartmentsReadDto> GetAllDepartments()
    {
        var DepartmentsFromDb = _departmentsRepo.GetAllDepartments();
        return DepartmentsFromDb.Select(DepartmentsFromDb => new DepartmentsReadDto
        {
            Id = DepartmentsFromDb.Id,
            Name = DepartmentsFromDb.Name,
        }).ToList();
    }

    public DepartmentDetailsReadDto? GetDepartmentById(int id)
    {
        var DepartmentFromDb = _departmentsRepo.GetDepartmentWithItsTicketsAndDevelopers(id);
        if (DepartmentFromDb == null)
        {
            return null;
        }
        return new DepartmentDetailsReadDto
        {
            Id = DepartmentFromDb.Id,
            Name = DepartmentFromDb.Name,
            Tickets = DepartmentFromDb.Tickets.Select(t => new TicketsChildReadDto
            {
                Id=t.Id,
                Description = t.Description,
                DevelopersCount = t.Developers.Count()
            }).ToList(),
        };
    }
}
