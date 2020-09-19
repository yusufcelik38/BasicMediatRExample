using System;
using System.Collections.Generic;
using System.Text;

namespace BasicMediatRExample.Entities
{
    public abstract class EntityBase
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
