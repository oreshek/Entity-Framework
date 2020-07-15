using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Framework
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Decimalnumber { get; set; }

        public string Routing { get; set; } 

        //public ICollection<Materials> Materials { get; set; }

        public Guid VendorId { get; set; }

        public Vendor Vendor { get; set; }



    }

    public class Vendor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

    }


    public class Materials
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public ICollection<Product> Products { get; set; }
        //public string Value { get; set; }

    }

  
       
}
