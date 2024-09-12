using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSQBusiness.Models;

public class GunPartContent
{
    [Key]
    public int Id { get; init; }
    public byte[] ByteArr { get; init; } = null!;
}