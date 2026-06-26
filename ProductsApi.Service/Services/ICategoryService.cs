using ProductsApi.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsApi.Service.DTOs;

namespace ProductsApi.Service.Services
{
    public interface ICategoryService
    {
        Task<Category> GetCategory(Guid categoryId);
        Task<List<Category>> GetAllCategories(CategorySortDTO sort, PagingDto page);
        Task<Category> CreateCategory(CategoryDTO dto);
        Task<Category> UpdateCategory(Guid Id, CategoryDTO dto);
        Task<bool> DeleteCategory(Guid categoryId);
    }
}
