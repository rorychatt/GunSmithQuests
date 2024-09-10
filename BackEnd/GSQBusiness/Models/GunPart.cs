using System.ComponentModel.DataAnnotations;
using System.Numerics;
using GSQBusiness.Contracts;

namespace GSQBusiness.Models;

public class GunPart : IDescribable, IPositionable
{
    [Key]
    public int Id { get; set; }
    public Guid Guid { get; set; } = new();
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public byte[] Content { get; set; } = null!;

    public Vector3 Position { get; set; } = new(0, 0, 0);
    public Vector3 EulerAngles { get; set; } = new(0, 0, 0);
}