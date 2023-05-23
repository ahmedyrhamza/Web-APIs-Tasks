using Microsoft.EntityFrameworkCore;

namespace TicketSystem.DAL;

public class Department
{
    //[PrimaryKey("Department")]
    public int Id { get; set; }
    public string Name { get; set; }= string.Empty;
    // 1 relation in 1-M
    public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
}