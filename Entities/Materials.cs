using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Framework.Entities
{
    public class Materials : EntityBase
    {
     //   public Guid Id { get; set; }
        public string Type { get; set; }
        public ICollection<ProductMaterials> ProductMaterials { get; set; }
        public string Value { get; set; }

    }
}
