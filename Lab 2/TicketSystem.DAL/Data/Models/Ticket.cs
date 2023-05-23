using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.DAL;

public class Ticket
{
    public int Id { get; set; }
    public string Description { get; set; }= string.Empty;
    public string Title { get; set; } = string.Empty;
    // M relation in 1-M
    //[ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    // easy way in M-N relation
    public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
}
