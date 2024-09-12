using GSQApi.Database;
using GSQBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSQApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GunBuildsController(GunBuildsContext db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GunBuild>>> GetGunBuilds()
    {
        return await Task.FromResult<ActionResult<IEnumerable<GunBuild>>>(Ok(db.GetGunBuilds()));
    }
}