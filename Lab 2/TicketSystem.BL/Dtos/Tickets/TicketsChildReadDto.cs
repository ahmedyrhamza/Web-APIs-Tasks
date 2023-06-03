using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BL.Dtos;

public class TicketsChildReadDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int DevelopersCount { get; set; }
}
