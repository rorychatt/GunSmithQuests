using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSQBusiness.Models;

public class GunPartContent
{
    [Key, ForeignKey("GunPartId")] public int GunPartId { get; init; }

    public virtual GunPart? GunPart { get; init; }
    public byte[] ByteArr { get; init; } = null!;
}