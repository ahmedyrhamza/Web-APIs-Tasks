using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.Dtos;
using TicketSystem.DAL;

namespace TicketSystem.BL;
public interface ITicketsManager
{
    List<TicketReadDto> GetAllTickets();
    TicketDetailsReadDto? GetTicketById(int id);
    int AddTicket(TicketAddDto ticketDto);
    bool UpdateTicket(TicketUpdateDto ticketDto);
    bool DeleteTicket(int id);
}
