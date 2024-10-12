using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Session.Core.Dto;
using Store.Session.Core.Entities;

namespace Store.Session.Core.Reposities.Contract
{
    public interface IProductService
    {
        Task <IEnumerable<ProductDto>>  GetAllProductAsync();


        Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync();
        Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync();

         Task<ProductDto>  GetProductById(int id);

    }
}
