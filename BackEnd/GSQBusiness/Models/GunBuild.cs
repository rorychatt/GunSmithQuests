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

    private List<GunPart> Attachments { get; set; } = [];
    
    public void AddAttachment(GunPart attachment)
    {
        Attachments.Add(attachment);
    }
    
    public void RemoveAttachment(GunPart attachment)
    {
        Attachments.Remove(attachment);
    }
    
    public void ClearAttachments()
    {
        Attachments.Clear();
    }
    
    public void SetAttachments(List<GunPart> attachments)
    {
        Attachments = attachments;
    }
}