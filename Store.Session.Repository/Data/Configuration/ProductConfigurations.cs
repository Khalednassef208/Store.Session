using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Session.Core.Entities;

namespace Store.Session.Repository.Data.Configuration
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Name).HasMaxLength(100).IsRequired();
            builder.Property(p=> p.PictureUrl).IsRequired();



            builder.HasOne(p => p.Brand).WithMany().HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.SetNull);




            builder.HasOne(p => p.Type).WithMany().HasForeignKey(p => p.TypeId)
                .OnDelete(DeleteBehavior.SetNull);



            builder.Property(p=> p.BrandId).IsRequired(false);
            builder.Property(p=> p.TypeId).IsRequired(false);

        }
    }
}
