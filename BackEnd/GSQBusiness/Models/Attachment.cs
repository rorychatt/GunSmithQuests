using System.ComponentModel.DataAnnotations;
using System.Numerics;
using GSQBusiness.Contracts;

namespace GSQBusiness.Models;

public class Attachment : IDescribable, IPositionable
{
    [Key]
    public int Id { get; init; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    
    public float PositionX { get; set; }
    public float PositionY { get; set; }
    public float PositionZ { get; set; }
    public float RotationX { get; set; }
    public float RotationY { get; set; }
    public float RotationZ { get; set; }

}