using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stamp.Site.Models;

public class StampResult
{
    [Key]
    public int Id { get; set; }
    public string? EmployeeCode { get; set; }
    public string? Transferee { get; set; }
    public string? FullName { get; set; }
    public string? DeliveryDate  { get; set; }

    [Column(TypeName = "image")]
    public byte[]? StampImage { get; set; }



}