using Microsoft.EntityFrameworkCore;
using ProductsApi.Service.Data;
using ProductsApi.Service.Models;
using ProductsApi.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProductsApi.Service.Services
{
    public class ProductService : IProductService
    {
        private AppDbContext _context;
        public ProductService(AppDbContext context) 
        { 
            this._context=context;
        }

        public async Task<Product> CreateProduct(CreateProductDTO dto)
        {
            Product newProduct = new Product { Name = dto.Name, Price = dto.Price, StockQuantity = dto.StockQuantity , IsActive=true,CategoryId=dto.CategoryId, CreatedAt=DateTime.UtcNow};
            _context.products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            var product = await _context.products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null) return false;
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<List<Product>> GetAllProducts(ProductFilterDto filter, ProductSortDto sort, PagingDto page)
        {
            var query = _context.products
            .Where(p => p.CategoryId == filter.CategoryId)
            .Where(p => p.Price >= filter.PriceMin)
            .Where(p => p.Price <= filter.PriceMax)
            .Where(p => p.IsActive == filter.IsActive);

            query = sort.Sort switch
            {
                ProductSortDto.SortBy.Price => sort.Direction == ProductSortDto.SortDirection.Descending ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price),
                ProductSortDto.SortBy.Name => sort.Direction == ProductSortDto.SortDirection.Descending ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name),
                ProductSortDto.SortBy.Date => sort.Direction == ProductSortDto.SortDirection.Descending ? query.OrderByDescending(p => p.CreatedAt) : query.OrderBy(p => p.CreatedAt),
               
                _ => query
            };


            query = query
            .Skip((page.PageNumber - 1) * page.ItemsPerPage)
            .Take(page.ItemsPerPage);

            return await query.ToListAsync();
        }

        public async Task<Product> GetProduct(Guid productId)
        {
            var prod= await _context.products.FirstOrDefaultAsync(p=>p.Id==productId);
            return prod;
        }

        public async Task<Product> UpdateProduct(Guid Id,UpdateProductDTO productDTO)
        {
            var product = await _context.products.FirstOrDefaultAsync(p => p.Id == Id);
            if (product == null) return null;
           
            else
            {
                product.Name = productDTO.Name;
                product.Price = productDTO.Price;
                product.StockQuantity = productDTO.StockQuantity;
                product.IsActive = productDTO.IsActive;
                if (product.StockQuantity == 0) { product.IsActive = false; }
                await _context.SaveChangesAsync();

            }
            
            return product;
        }
    }
}
