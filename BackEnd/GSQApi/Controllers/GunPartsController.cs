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
    public Task<ActionResult<GunPart>> GetGunPart(string partName)
    {
        throw new NotImplementedException();

    }

    [HttpPost("upload")]
    public Task<IActionResult> UploadGunPart([FromForm] IFormFile file)
    {
        throw new NotImplementedException();

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