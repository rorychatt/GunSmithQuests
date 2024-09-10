using GSQBusiness.Contracts;
using GSQBusiness.Models;
using Microsoft.EntityFrameworkCore;

namespace GSQApi.Database;

public class GunBuildsContext(DbContextOptions<GunBuildsContext> options) : DbContext(options)
{
    public DbSet<GunBuild> GunBuilds { get; init; }
    public DbSet<GunPart> GunParts { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GunPart>()
            .Property(e => e.Position)
            .HasConversion(new Vector3Converter());

        modelBuilder.Entity<GunPart>()
            .Property(e => e.EulerAngles)
            .HasConversion(new Vector3Converter());
        
        modelBuilder.Entity<GunBuild>()
            .Property(e => e.Position)
            .HasConversion(new Vector3Converter());

        modelBuilder.Entity<GunBuild>()
            .Property(e => e.EulerAngles)
            .HasConversion(new Vector3Converter());

        base.OnModelCreating(modelBuilder);
    }

    public GunPart? GetGunPartByName(string partName)
    {
        return GunParts.FirstOrDefault(part => part.Name.Contains(partName));
    }

    public async Task<bool> SaveGunPartFile(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        var gunPart = new GunPart
        {
            Name = file.FileName,
            Content = memoryStream.ToArray(),
            ContentType = file.ContentType
        };
        if(GetGunPartByName(file.FileName) != null) return false;
        GunParts.Add(gunPart);
        await SaveChangesAsync();
        return true;
    }
}