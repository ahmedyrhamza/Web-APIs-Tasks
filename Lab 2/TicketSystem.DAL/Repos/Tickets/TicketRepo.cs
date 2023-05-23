using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DAL;
public class TicketRepo: ITicketsRepo
{
    private readonly TicketsContext _context;
    public TicketRepo(TicketsContext context)
    {
        _context = context;
    }

    public IEnumerable<Ticket> GetAllTickets()
    {
        //return _context.Tickets;
        return _context.Set<Ticket>();
    }

    public Ticket? GetTicketById(int id)
    {
        return _context.Set<Ticket>().Find(id);
    }

    public void AddTicket(Ticket ticket)
    {
        _context.Set<Ticket>().Add(ticket);
    }

    public void UpdatTicket(Ticket ticket)
    {
        throw new NotImplementedException();
    }

    public void DeleteTicket(Ticket ticket)
    {
        _context.Set<Ticket>().Remove(ticket);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges ();
    }
}
