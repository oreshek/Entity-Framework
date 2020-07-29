using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity_Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AsupContext())
            {

                var p = context.Products
                    .Include(p => p.ProductMaterials)
                    .ThenInclude(p => p.Material)
                    .ToList();

                //var product = context.Products.FirstOrDefault();

                //var materials = context.Materials.ToList();

                //product.ProductMaterials = new List<ProductMaterials>();
                //foreach (var m in materials) {
                //    product.ProductMaterials.Add(new ProductMaterials() {
                //        ProductId = product.Id,
                //        MaterialId = m.Id
                //    });
                //}

                //context.SaveChanges();

                //context.Materials.AddRange(new List<Materials>() { 
                //    new Materials() { Id = Guid.NewGuid(), Value = "", Type = "Wood" }, 
                //    new Materials() { Id = Guid.NewGuid(), Value = "", Type = "Glass" },
                //    new Materials() { Id = Guid.NewGuid(), Value = "", Type = "Plastic" }});

                //context.SaveChanges();

                //var vendors = new List<Vendor>() { 
                //    new Vendor() { Id = Guid.NewGuid(), Name = "ClassSolutions" },
                //    new Vendor() { Id = Guid.NewGuid(), Name = "WoodSolutions" },
                //};
                //context.Vendor.AddRange(vendors);

                //var product = new Product()
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Cap",
                //    Decimalnumber = "№758725.112",
                //    Routing = "17, 40, 39",
                //    Vendor = new Vendor() { Id = Guid.NewGuid(), Name = "ClassSolutions" },
                //    //Materials = new List<Materials>() { new Materials() { Id = Guid.NewGuid(), Type = "Glass" } }


                //};

                //var vendor = context.Vendor.FirstOrDefault(a => a.Name == "GlassSolutions");

                //var product = new Product()
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Bottle",
                //    Decimalnumber = "№758725.113",
                //    Routing = "17, 40, 39",
                //    VendorId = vendor.Id,
                //    //Materials = new List<Materials>() { new Materials() { Id = Guid.NewGuid(), Type = "Glass" } }
                //};

                //Console.WriteLine(product.routing);
                //context.Products.Add(product);
                //context.SaveChanges();
            }
        }






    }

}
