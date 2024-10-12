using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Store.Session.Core.Entities;
using Store.Session.Repository.Data.Context;

namespace Store.Session.Repository.Data
{
    public class StoreDbContextSeed
    {
        public   async static Task SeedASync(AppDbContext _context)
        {
            if (_context.Brands.Count() == 0)
            {
                var brandData = File.ReadAllText(@"..\Store.Session.Repository\Data\DataSeed\brands.json");
                var brand = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                if (brand is not null && brand.Count() > 0)
                {
                    await _context.Brands.AddRangeAsync(brand);
                    await _context.SaveChangesAsync();
                }
            }






            if (_context.ProductTypes.Count() == 0)
            {
                var typeData = File.ReadAllText(@"..\Store.Session.Repository\Data\DataSeed\types.json");
                var type = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                if(type is not null && type.Count() > 0)
                {
                    await _context.ProductTypes.AddRangeAsync(type);
                    await _context.SaveChangesAsync();

                }
            }


            if (_context.Products.Count() == 0)
            {
                var productsData = File.ReadAllText(@"..\Store.Session.Repository\Data\DataSeed\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if(products is not null && products.Count() > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                    await _context.SaveChangesAsync();
                }
            }

        }
    }
}
