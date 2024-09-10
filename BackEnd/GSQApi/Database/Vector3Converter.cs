using System.Numerics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GSQApi.Database;

public class Vector3Converter() : ValueConverter<Vector3, string>(v => ConvertToString(v),
    v => ConvertToVector3(v))
{
    private static string ConvertToString(Vector3 vector)
    {
        return $"{vector.X},{vector.Y},{vector.Z}";
    }

    private static Vector3 ConvertToVector3(string vectorString)
    {
        var parts = vectorString.Split(',');
        return new Vector3(
            float.Parse(parts[0]),
            float.Parse(parts[1]),
            float.Parse(parts[2])
        );
    }
}