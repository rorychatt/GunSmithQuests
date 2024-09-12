using System.ComponentModel.DataAnnotations;
using GSQBusiness.Contracts;

namespace GSQBusiness.Models;

public class GunBuild : IDescribable, IPositionable
{
    [Key] public int Id { get; init; }
    [Required] public string Name { get; set; } = null!;
    public string? Description { get; set; }
    private List<Attachment> Attachments { get; set; } = [];
    public float PositionX { get; set; }
    public float PositionY { get; set; }
    public float PositionZ { get; set; }
    public float RotationX { get; set; }
    public float RotationY { get; set; }
    public float RotationZ { get; set; }

    public bool AddAttachment(Attachment attachment)
    {
        if (Attachments.Any(att => att.Name == attachment.Name))
        {
            return false;
        }

        Attachments.Add(attachment);
        return true;
    }

    public bool RemoveAttachment(Attachment attachment)
    {
        if (Attachments.All(att => att.Name != attachment.Name)) return false;
        Attachments.Remove(attachment);
        return true;
    }
}