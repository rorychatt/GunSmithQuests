using Microsoft.AspNetCore.Mvc;

namespace GSQApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GunPartsController(IConfiguration configuration) : ControllerBase
{
    private readonly string _folderPath =
        Path.Combine(AppContext.BaseDirectory, configuration["FileStorage:FolderPath"]!);
    
    [HttpGet("{filename}")]
    public IActionResult GetGunPart(string filename)
    {
        var filePath = Path.Combine(_folderPath, filename);
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }
        
        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        return File(fileBytes, "application/octet-stream");
    }
    
    [HttpPost("upload")]
    public async Task<IActionResult> UploadGunPart([FromForm] IFormFile file)
    {
        if(file.Length == 0)
        {
            return BadRequest("No file was provided");
        }
        
        var filePath = Path.Combine(_folderPath, file.FileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        
        return Ok(new { filePath});
    }
}