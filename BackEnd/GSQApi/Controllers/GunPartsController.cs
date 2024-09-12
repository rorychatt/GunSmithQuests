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
        return Ok(await db.GetGunPartByNameAsync(partName));
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadGunPart([FromForm] IFormFile file)
    {
        using var ms = new MemoryStream();
        await file.CopyToAsync(ms);
        var content = new GunPartContent { ByteArr = ms.ToArray() };

        var gunPart = new GunPart
        {
            Name = file.FileName,
            Content = content
        };

        var taskResult = await db.AddGunPartAsync(gunPart);

        return taskResult == 1 ? Ok() : StatusCode(400);
    }

    [HttpGet("listAll")]
    public Task<ActionResult<List<GunPartResponse>>> ListAllGunParts()
    {
        return Task.FromResult<ActionResult<List<GunPartResponse>>>(Ok(db.GetAllGunPartsAsync()));
    }

    [HttpGet("download/{partName}")]
    public Task<IActionResult> DownloadGunPart(string partName)
    {
        var gunPart = db.GetGunPartByNameAsync(partName).Result;

        return gunPart is null
            ? Task.FromResult<IActionResult>(NotFound())
            : Task.FromResult<IActionResult>(File(gunPart.Content.ByteArr, "application/octet-stream", gunPart.Name));
    }
}