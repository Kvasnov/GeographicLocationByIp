using System;

namespace GeographicLocationByIp.Domain.Interfaces
{
    public interface IAuditableEntity
    {
        DateTime Created {get; set;}

        DateTime? LastModified {get; set;}
    }
}