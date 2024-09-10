using GSQApi.Database;
using GSQApi.Dto;
using GSQBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSQApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GunPartsController(GunBuildsContext db) : ControllerBase
{
    [HttpGet("{partName}")]
    public async Task<ActionResult<GunPart>> GetGunPart(string partName)
    {
        return await Task.FromResult<ActionResult<GunPart>>(Ok(db.GetGunPartByName(partName)));
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadGunPart([FromForm] IFormFile file)
    {
        return await (await db.SaveGunPartFile(file)
            ? Task.FromResult<IActionResult>(Ok())
            : Task.FromResult<IActionResult>(StatusCode(500)));
    }

    [HttpGet("listAll")]
    public async Task<ActionResult<IEnumerable<GunPartResponse>>> ListAllGunParts()
    {
        return await Task.FromResult<ActionResult<IEnumerable<GunPartResponse>>>(
            Ok(db.GunParts.Select(part => (GunPartResponse)part).ToList()));
    }

    [HttpGet("download/{partName}")]
    public async Task<IActionResult> DownloadGunPart(string partName)
    {
        var gunPart = db.GetGunPartByName(partName);
        return await (gunPart == null
            ? Task.FromResult<IActionResult>(NotFound())
            : Task.FromResult<IActionResult>(File(gunPart.Content.ByteArr, gunPart.ContentType, gunPart.Name)));
    }
}