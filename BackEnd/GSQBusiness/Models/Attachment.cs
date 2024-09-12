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
    public Vector3 Position { get; set; } = new Vector3(0, 0, 0);
    public Vector3 EulerAngles { get; set; } = new Vector3(0, 0, 0);
}