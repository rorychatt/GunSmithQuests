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
        
        await db.AddGunPartAsync(gunPart);
    }

    [HttpGet("listAll")]
    public Task<ActionResult<IEnumerable<GunPartResponse>>> ListAllGunParts()
    {
        throw new NotImplementedException();

    }

    [HttpGet("download/{partName}")]
    public Task<IActionResult> DownloadGunPart(string partName)
    {
        throw new NotImplementedException();

    }
}