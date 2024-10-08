﻿using System.ComponentModel.DataAnnotations;
using System.Numerics;
using GSQBusiness.Contracts;

namespace GSQBusiness.Models;

public class GunPart : IDescribable, IPositionable
{
    [Key]
    public int Id { get; init; }

    public Guid Guid { get; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string ContentType { get; init; } = null!;
    public GunPartContent Content { get; init; } = null!;
    public Vector3 Position { get; set; } = new(0, 0, 0);
    public Vector3 EulerAngles { get; set; } = new(0, 0, 0);
    
}