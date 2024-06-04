using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stamp.Site.Models;

public class StampMaker
{
    [Key]
    public int Id { get; set; }
    public string? Transferee { get; set; }

    [Column(TypeName = "image")]
    public byte[]? ConfirmationReceipt { get; set; }
}