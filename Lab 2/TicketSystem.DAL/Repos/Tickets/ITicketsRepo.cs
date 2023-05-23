using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DAL;

public interface ITicketsRepo
{
    IEnumerable<Ticket> GetAllTickets();
    Ticket? GetTicketById(int id);
    void AddTicket(Ticket ticket);
    void UpdatTicket(Ticket ticket);
    void DeleteTicket(Ticket ticket);
    int SaveChanges();
}