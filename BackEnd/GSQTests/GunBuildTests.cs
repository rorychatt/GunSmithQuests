using FluentAssertions;
using GSQBusiness.Models;

namespace GSQTests;

public class GunBuildTests
{
    [Fact]
    public void Build_Should_Add_GunPart()
    {
        var gunBuild = new GunBuild();
        var gunPart = new GunPart { Name = "TestPart" };
        
        gunBuild.TryAddPart(gunPart);
        
        gunBuild.Attachments.Should().ContainSingle(attachment => attachment.Name == gunPart.Name);
        gunBuild.Attachments[0].Should().BeOfType<Attachment>();
    }
    
    [Fact]
    public void Build_Should_Remove_GunPart()
    {
        var gunBuild = new GunBuild();
        var gunPart = new GunPart { Name = "TestPart" };
        
        gunBuild.TryAddPart(gunPart);
        gunBuild.TryRemovePart(gunPart);
        
        gunBuild.Attachments.Should().BeEmpty();
    }
}