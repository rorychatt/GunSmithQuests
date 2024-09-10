using System.Numerics;
using GSQBusiness.Contracts;

namespace GSQBusiness.Models;

public class GunBuild : IPositionable, IDescribable

{
    public Vector3 Position { get; set; } = new Vector3(0, 0, 0);
    public Vector3 EulerAngles { get; set; } = new Vector3(0, 0, 0);
    public List<GunPart> GunParts { get; set; } = [];
    
    public required string Name { get; set; }
    public required string Description { get; set; }
}