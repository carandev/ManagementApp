namespace ManagementApp.API.Data.Models;

public class EntityWithTraceability
{
    public DateTime CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    
    public int CreatorId { get; set; }
    public User Creator { get; set; } = null!;
    
    public int? UpdaterId { get; set; }
    public User? Updater { get; set; } = null!;
}