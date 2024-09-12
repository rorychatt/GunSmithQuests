using GSQBusiness.Models;

namespace GSQApi.Dto;

public record GunPartResponse(int Id, string Name, string? Description)
{
    public static explicit operator GunPartResponse(GunPart gunPart) =>
        new(gunPart.Id, gunPart.Name, gunPart.Description);
};