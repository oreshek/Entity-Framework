using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Framework.Entities
{
    public class ProductMaterials
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } // navigation prop

        public Guid MaterialId { get; set; }
        public Materials Material { get; set; }
    }
}
