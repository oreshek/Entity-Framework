using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Framework.Entities
{
    public class Vendor : EntityBase
    {
        //public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
