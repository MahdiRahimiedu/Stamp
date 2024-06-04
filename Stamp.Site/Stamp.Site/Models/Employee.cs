using System.ComponentModel.DataAnnotations;

namespace Stamp.Site.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? CategoryJob { get; set; }
    public string? NationalCode { get; set; }
    public bool? Signature { get; set; }
}