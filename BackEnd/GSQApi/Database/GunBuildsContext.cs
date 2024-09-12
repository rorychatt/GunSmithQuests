using GSQBusiness.Models;
using Microsoft.EntityFrameworkCore;

namespace GSQApi.Database;

public class GunBuildsContext(DbContextOptions<GunBuildsContext> options) : DbContext(options)
{
    public DbSet<GunPart> GunParts { get; init; } = null!;
    public DbSet<GunBuild> GunBuilds { get; init; } = null!;
    public DbSet<Attachment> Attachments { get; init; } = null!;
    public DbSet<GunPartContent> GunPartContents { get; init; } = null!;
    
}