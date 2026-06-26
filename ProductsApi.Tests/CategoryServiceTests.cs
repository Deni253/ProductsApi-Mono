using Microsoft.EntityFrameworkCore;
using ProductsApi.Service.Data;
using ProductsApi.Service.DTOs;
using ProductsApi.Service.Models;
using ProductsApi.Service.Services;

namespace ProductsApi.Tests
{
    public class CategoryServiceTests
    {
        private AppDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public async Task GetCategory_CategoryExists_ReturnsCategory()
        {
            var context = CreateContext();
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Electronics",
                Description = "Electronic devices"
            };
            context.categories.Add(category);
            await context.SaveChangesAsync();

            var service = new CategoryService(context);
            var result = await service.GetCategory(category.Id);

            Assert.NotNull(result);
            Assert.Equal(category.Id, result.Id);
        }

        [Fact]
        public async Task GetCategory_CategoryDoesNotExist_ReturnsNull()
        {
            var context = CreateContext();

            var service = new CategoryService(context);
            var result = await service.GetCategory(Guid.NewGuid());

            Assert.Null(result);
        }

        [Fact]
        public async Task CreateCategory_ValidDto_ReturnsCreatedCategory()
        {
            var context = CreateContext();
            var dto = new CategoryDTO
            {
                Name = "Clothing",
                Description = "Clothes and accessories"
            };

            var service = new CategoryService(context);
            var result = await service.CreateCategory(dto);

            Assert.NotNull(result);
            Assert.Equal(dto.Name, result.Name);
            Assert.Equal(dto.Description, result.Description);
        }

        [Fact]
        public async Task UpdateCategory_CategoryExists_ReturnsUpdatedCategory()
        {
            var context = CreateContext();
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Old Name",
                Description = "Old Description"
            };
            context.categories.Add(category);
            await context.SaveChangesAsync();

            var dto = new CategoryDTO
            {
                Name = "New Name",
                Description = "New Description"
            };

            var service = new CategoryService(context);
            var result = await service.UpdateCategory(category.Id, dto);

            Assert.NotNull(result);
            Assert.Equal("New Name", result.Name);
            Assert.Equal("New Description", result.Description);
        }

        [Fact]
        public async Task UpdateCategory_CategoryDoesNotExist_ReturnsNull()
        {
            var context = CreateContext();
            var dto = new CategoryDTO
            {
                Name = "New Name",
                Description = "New Description"
            };

            var service = new CategoryService(context);
            var result = await service.UpdateCategory(Guid.NewGuid(), dto);

            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteCategory_CategoryExists_ReturnsTrue()
        {
            var context = CreateContext();
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Sports",
                Description = "Sports equipment"
            };
            context.categories.Add(category);
            await context.SaveChangesAsync();

            var service = new CategoryService(context);
            var result = await service.DeleteCategory(category.Id);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteCategory_CategoryDoesNotExist_ReturnsFalse()
        {
            var context = CreateContext();

            var service = new CategoryService(context);
            var result = await service.DeleteCategory(Guid.NewGuid());

            Assert.False(result);
        }
    }
}
