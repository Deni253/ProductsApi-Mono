using ProductsApi.Service.Data;
using ProductsApi.Service.DTOs;
using ProductsApi.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Service.Services
{
    public class CategoryService : ICategoryService
    {
        AppDbContext _db;

        public CategoryService(AppDbContext context)
        {
            this._db=context;
        }
        public async Task<Category> CreateCategory(CategoryDTO dto)
        {
            Category category = new Category { Name=dto.Name, Description=dto.Description };
            _db.categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategory(Guid categoryId)
        {
            var category = await _db.categories.FirstOrDefaultAsync(c => c.Id == categoryId);
            if (category == null) return false;
            _db.categories.Remove(category);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetAllCategories(CategorySortDTO sort, PagingDto page)
        {
            IQueryable<Category> query=_db.categories; // ovo je deklaracija kojom započinjem query pa poslije na njega nadodajem stvari samo
            query = sort.SortBy switch // pristupamo preko propertija tome što nam treba

            {
                CategorySortDTO.Sort.Ascending => query.OrderBy(c=>c.Name), //konkretan sort kao vrijednost1 i onda nakon => rezultat što radimo u bazi

                CategorySortDTO.Sort.Descending => query.OrderByDescending(c => c.Name), 

                _ => query
            };

            query = query.Skip((page.PageNumber-1) * page.ItemsPerPage).Take(page.ItemsPerPage);

            return await query.ToListAsync();
        }

        public async Task<Category> GetCategory(Guid categoryId)
        {
            return await _db.categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task<Category> UpdateCategory(Guid id ,CategoryDTO dto)
        {
            var category = await _db.categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return null;
            else
            {
                category.Name=dto.Name;
                category.Description=dto.Description;
                await _db.SaveChangesAsync();
            }
            
            return category;
        }
    }
}
