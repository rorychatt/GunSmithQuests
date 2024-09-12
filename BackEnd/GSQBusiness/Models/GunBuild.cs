using System.ComponentModel.DataAnnotations;
using System.Numerics;
using GSQBusiness.Contracts;

namespace GSQBusiness.Models;

public class GunBuild : IDescribable, IPositionable
{
    [Key] public int Id { get; init; }

    public Guid Guid { get; } = Guid.NewGuid();

    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public Vector3 Position { get; set; }
    public Vector3 EulerAngles { get; set; }
    public List<Attachment> Attachments { get; init; } = [];

    public bool TryAddPart(GunPart gunPart)
    {
        if (Attachments.Any(attachment => attachment.Name == gunPart.Name)) return false;

        Attachments.Add(new Attachment
        {
            Name = gunPart.Name,
            Description = gunPart.Description
        });

        return true;
    }

    public bool TryRemovePart(GunPart gunPart)
    {
        var attachment = Attachments.FirstOrDefault(attachment => attachment.Name == gunPart.Name);
        if (attachment == null) return false;

        Attachments.Remove(attachment);
        return true;
    }
}