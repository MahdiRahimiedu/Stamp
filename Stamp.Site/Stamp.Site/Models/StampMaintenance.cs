using System.ComponentModel.DataAnnotations;

namespace Stamp.Site.Models;

public class StampMaintenance
{
    [Key]
    public int Id { get; set; }
    public string? SignatureDate { get; set; }
    public string? Transferee { get; set; }
}