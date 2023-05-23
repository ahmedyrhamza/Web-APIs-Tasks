namespace TicketSystem.DAL;

public class Developer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    // easy way in M-N relation
    public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
}
