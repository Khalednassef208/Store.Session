using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Store.Session.Core.Dto;
using Store.Session.Core.Entities;

namespace Store.Session.Core.Mapping
{
    
     public   class ProductProfile:Profile
    {
        public ProductProfile()
        {




            CreateMap<Product, ProductDto>()
               .ForMember(D=> D.BrandName, options=> options.MapFrom(B=> B.Brand.Name))
               .ForMember(D=> D.TypeName, options=> options.MapFrom(T => T.Type.Name)) ;
            CreateMap<ProductBrand, TypeBrandDto>();
            CreateMap<ProductType, TypeBrandDto>();


        }
    }
}
