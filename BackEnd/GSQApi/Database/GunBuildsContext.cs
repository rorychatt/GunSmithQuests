using GSQBusiness.Models;
using Microsoft.EntityFrameworkCore;

namespace GSQApi.Database;

public class GunBuildsContext(DbContextOptions<GunBuildsContext> options) : DbContext(options)
{
    public DbSet<GunBuild> GunBuilds { get; init; }
    public DbSet<GunPart> GunParts { get; init; }
    public DbSet<GunPartContent> GunPartContents { get; init; }
    
    public DbSet<Attachment> Attachments { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GunPartContent>()
            .HasOne(g => g.GunPart)
            .WithOne(p => p.Content)
            .HasForeignKey<GunPartContent>(c => c.GunPartId);

        modelBuilder.Entity<GunBuild>()
            .Property(e => e.Position)
            .HasConversion(new Vector3Converter());

        modelBuilder.Entity<GunBuild>()
            .Property(e => e.EulerAngles)
            .HasConversion(new Vector3Converter());
        
        modelBuilder.Entity<Attachment>()
            .Property(e => e.Position)
            .HasConversion(new Vector3Converter());

        modelBuilder.Entity<Attachment>()
            .Property(e => e.EulerAngles)
            .HasConversion(new Vector3Converter());
        
        
        

        base.OnModelCreating(modelBuilder);
    }

    public GunPart? GetGunPartByName(string partName)
    {
        return GunParts.Include(part => part.Content).FirstOrDefault(part => part.Name.Contains(partName));
    }

    public async Task<bool> SaveGunPartFile(IFormFile file)
    {
        await using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);

        var gunPartContent = new GunPartContent() { ByteArr = memoryStream.ToArray() };

        var gunPart = new GunPart
        {
            Name = file.FileName,
            ContentType = file.ContentType,
            Content = gunPartContent
        };

        GunPartContents.Add(gunPartContent);
        GunParts.Add(gunPart);

        await SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<GunBuild?>> GetGunBuilds()
    {
        return await GunBuilds.ToListAsync();
    }

    public Task<GunBuild?> GetGunBuildByName(string searchTerm)
    {
        return Task.FromResult(GunBuilds.Include(build => build.Attachments).FirstOrDefault(build => build.Name.Contains(searchTerm)));
    }
}