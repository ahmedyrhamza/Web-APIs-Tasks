using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BL.Dtos;

public class DepartmentDetailsReadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<TicketsChildReadDto> Tickets { get; set; } = new List<TicketsChildReadDto>();
}
