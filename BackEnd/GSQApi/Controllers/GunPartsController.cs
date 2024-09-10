using GSQApi.Database;
using GSQBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSQApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GunPartsController(GunBuildsContext db) : ControllerBase
{
    [HttpGet("{partName}")]
    public Task<ActionResult<GunPart>> GetGunPart(string partName)
    {
        return Task.FromResult<ActionResult<GunPart>>(Ok(db.GetGunPartByName(partName)));
    }

    [HttpPost("upload")]
    public Task<IActionResult> UploadGunPart([FromForm] IFormFile file)
    {
        return file.Length == 0
            ? Task.FromResult<IActionResult>(BadRequest("No file was provided"))
            : Task.FromResult<IActionResult>(Ok(db.SaveGunPartFile(file)));
    }

    [HttpGet("listAll")]
    public Task<ActionResult<IEnumerable<GunPart>>> ListAllGunParts()
    {
        return Task.FromResult<ActionResult<IEnumerable<GunPart>>>(Ok(db.GunParts.ToList()));
    }

    [HttpGet("download/{partName}")]
    public Task<IActionResult> DownloadGunPart(string partName)
    {
        var gunPart = db.GetGunPartByName(partName);
        return gunPart == null
            ? Task.FromResult<IActionResult>(NotFound())
            : Task.FromResult<IActionResult>(File(gunPart.Content, gunPart.ContentType, gunPart.Name));
    }
}