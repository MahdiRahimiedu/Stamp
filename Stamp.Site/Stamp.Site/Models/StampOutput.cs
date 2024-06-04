using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stamp.Site.Models;

public class StampOutput
{
    [Key]
    public int Id { get; set; }
    public string? EmployeeCode { get; set; }
    public string? FullName { get; set; }
    public string? DateExit { get; set; }

    [Column(TypeName = "image")]
    public byte[]? MinutesForm { get; set; }
    [Column(TypeName = "image")]
    public byte[]? FormOfTransformation { get; set; }
}