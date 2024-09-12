using GSQBusiness.Models;
using Microsoft.EntityFrameworkCore;

namespace GSQApi.Database;

public class GunBuildsContext(DbContextOptions<GunBuildsContext> options) : DbContext(options)
{
    public DbSet<GunPart> GunParts { get; init; } = null!;
    public DbSet<GunBuild> GunBuilds { get; init; } = null!;
    public DbSet<Attachment> Attachments { get; init; } = null!;
    public DbSet<GunPartContent> GunPartContents { get; init; } = null!;

    public Task<GunPart?> GetGunPartByNameAsync(string partName)
    {
        return GunParts.Include(gp => gp.Content).FirstOrDefaultAsync(part => part.Name == partName);
    }

    public async Task<int> AddGunPartAsync(GunPart gunPart)
    {
        await GunParts.AddAsync(gunPart);
        return await SaveChangesAsync();
    }

    public Task<List<GunPart>> GetAllGunPartsAsync()
    {
        return GunParts.Include(gp => gp.Content).ToListAsync();
    }

    public async Task<List<GunBuild>> GetAllGunBuildsAsync()
    {
        return await GunBuilds.ToListAsync();
    }
}