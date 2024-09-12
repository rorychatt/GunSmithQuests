using GSQBusiness.Models;

namespace GSQApi.Dto;

public record GunPartResponse(Guid Guid, string Name, string? Description)
{
    // public static explicit operator GunPartResponse(GunPart gunPart) =>
    //     new(gunPart.Guid, gunPart.Name, gunPart.Description);
};