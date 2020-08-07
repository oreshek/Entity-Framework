using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity_Framework.Entities
{
    public class Product : EntityBase
    {
        //[Key]
        //public Guid Id { get; set; }// PK ()
        public string Name { get; set; }
        public string Decimalnumber { get; set; }

        public string Routing { get; set; } 

        public ICollection<ProductMaterials> ProductMaterials { get; set; }

        public Guid VendorId { get; set; }//FK

        public Vendor Vendor { get; set; }// Navigation prop
        public string Inbox { get; set; }

        // [NotMapped]


    }






 

  
       
}
