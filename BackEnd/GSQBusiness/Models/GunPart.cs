using System.ComponentModel.DataAnnotations;

namespace GSQBusiness.Models;

public class GunPart
{
    [Key]
    public int Id { get; init; }
    [Required]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    [Required]
    public GunPartContent Content { get; set; } = null!;
}