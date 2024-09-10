using System.Numerics;

namespace GSQBusiness.Contracts;

public interface IPositionable
{
    public Vector3 Position { get; set; }
    public Vector3 EulerAngles { get; set; }
}