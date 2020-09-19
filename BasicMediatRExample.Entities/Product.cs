
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicMediatRExample.Entities
{
    public class Product : EntityBase
    {

        public decimal Price { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }

    }
}
