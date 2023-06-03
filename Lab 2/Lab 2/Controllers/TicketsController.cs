using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.BL;
using TicketSystem.BL.Dtos;

namespace Lab_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsManager ticketsManager;

        public TicketsController(ITicketsManager ticketsManager) {
            this.ticketsManager = ticketsManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TicketReadDto>> GetAll() {
            var Tickets = ticketsManager.GetAllTickets();
            if (!Tickets.Any()) { 
                return NotFound();
            }
            return Tickets;
        }

        [HttpGet]
        [Route("id")]
        public ActionResult<TicketDetailsReadDto> GetByID(int id)
        {
            var Ticket = ticketsManager.GetTicketById(id);
            if (Ticket == null)
            {
                return NotFound();
            }
            return Ticket;
        }

        [HttpPost]
        public ActionResult Add(TicketAddDto ticket)
        {
            var NewTicketID = ticketsManager.AddTicket(ticket);
            return CreatedAtAction("GetByID", new { id = NewTicketID });
        }

        [HttpPut]
        [Route("id")]
        public ActionResult Update(int id, TicketUpdateDto ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest("Enter vaild data please!");
            }
            var Updated = ticketsManager.UpdateTicket(ticket);
            if (!Updated) { 
                return NotFound(ticket.Id);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("id")]
        public ActionResult Delete(int id)
        {
            var Deleted = ticketsManager.DeleteTicket(id);
            if (!Deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
