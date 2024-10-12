using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Store.Session.Core.Dto;
using Store.Session.Core.Entities;
using Store.Session.Core.Reposities.Contract;

namespace Store.Session.Service.Services.Products
{
    public class ProductService : IProductService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
        }
        public  async Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync()
        {
            return _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync());

        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {

           return _mapper.Map<IEnumerable<ProductDto>>(await _unitOfWork.Repository<Product, int>().GetAllAsync());
        }

        public  async Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync()
        {
            return _mapper.Map<IEnumerable<TypeBrandDto >> (  await _unitOfWork.Repository<ProductType, int>().GetAllAsync());

        }

        public async Task<ProductDto> GetProductById(int id)
        {
           var product=   await _unitOfWork.Repository<Product, int >().GetAsync(id);
            var mappproduct = _mapper.Map<ProductDto>(product);
            return mappproduct;
        }
    }
}
