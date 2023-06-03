using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.Dtos;
using TicketSystem.DAL;

namespace TicketSystem.BL;
public class TicketsManager : ITicketsManager
{
    private readonly ITicketsRepo _ticketsRepo;
    public TicketsManager(ITicketsRepo ticketsRepo)
    {
        _ticketsRepo = ticketsRepo;
    }

    public List<TicketReadDto> GetAllTickets()
    {
        var TicketsFromDb = _ticketsRepo.GetAllTickets();
        return TicketsFromDb.Select(T => new TicketReadDto
        {
            Id = T.Id,
            Description = T.Description,
            Title = T.Title,
        }).ToList();
    }

    public TicketDetailsReadDto? GetTicketById(int id)
    {
        var TicketFromDb = _ticketsRepo.GetTicketById(id);
        if (TicketFromDb == null)
        {
            return null;
        }
        return new TicketDetailsReadDto
        {
            Id = TicketFromDb.Id,
            Description = TicketFromDb.Description,
            Title = TicketFromDb.Title
        };
    }

    public int AddTicket(TicketAddDto ticketDto)
    {
        var NewTicket = new Ticket
        {
            Title = ticketDto.Title,
            Description = ticketDto.Description
        };
        _ticketsRepo.AddTicket(NewTicket);
        _ticketsRepo.SaveChanges();    // it will auto fill the id 
        return NewTicket.Id;
    }

    public bool UpdateTicket(TicketUpdateDto ticketDto)
    {
        var UpdateTicket = _ticketsRepo.GetTicketById(ticketDto.Id);
        if (UpdateTicket == null) { return false; }
        UpdateTicket.Description = ticketDto.Description;
        UpdateTicket.Title = ticketDto.Title;
        _ticketsRepo.UpdateTicket(UpdateTicket);    // Just call it in order to make any future change in logic 
        _ticketsRepo.SaveChanges();
        return true;
    }

    public bool DeleteTicket(int id)
    {
        var DeleteTicket = _ticketsRepo.GetTicketById(id);
        if (UpdateTicket == null) { return false; }
        _ticketsRepo.DeleteTicket(DeleteTicket);
        _ticketsRepo.SaveChanges();
        return true;
    }
}
