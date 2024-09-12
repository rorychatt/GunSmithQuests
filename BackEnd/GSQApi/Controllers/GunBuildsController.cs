using GSQApi.Database;
using GSQBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSQApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GunBuildsController(GunBuildsContext db) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<GunBuild>> GetGunBuilds()
    {
        throw new NotImplementedException();
    }
}