using System;
using GeographicLocationByIp.Domain.Interfaces;

namespace GeographicLocationByIp.Domain.Entities.Common
{
    public abstract class BaseEntity : IIdentity, IAuditableEntity
    {
        public DateTime Created {get; set;}
        public DateTime? LastModified {get; set;}
        public Guid Id {get; set;}
    }
}