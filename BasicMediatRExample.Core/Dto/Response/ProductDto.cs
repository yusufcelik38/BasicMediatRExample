using System;
using System.Collections.Generic;
using System.Text;

namespace BasicMediatRExample.Core.Dto.Response
{
    public class ProductDto
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
    }
}
