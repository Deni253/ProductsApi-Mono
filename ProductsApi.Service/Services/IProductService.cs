using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProductsApi.Service.Models;
using ProductsApi.Service.DTOs;

namespace ProductsApi.Service.Services
{
    public interface IProductService
    {
        Task<Product> GetProduct(Guid productId);
        Task<List<Product>> GetAllProducts(ProductFilterDto filter, ProductSortDto sort, PagingDto page);
        Task<Product> CreateProduct(CreateProductDTO productDTO);
        Task<Product> UpdateProduct(Guid Id, UpdateProductDTO productDTO);
        Task<bool> DeleteProduct(Guid productId);

    }
}
