using System;

namespace JWTAuthentication.Entity;

public class Test
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime LastModifiedAt { get; set; }
    public DateTime LastModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedAt { get; set; }
    public DateTime DeletedBy { get; set; }
    public bool IsActive { get; set; }
    public DateTime ActiveFrom { get; set; }
    public DateTime ActiveTo { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public string ActiveBy { get; set; }
    public string DeactivatedBy { get; set; }
}
