using Microsoft.EntityFrameworkCore;
using ProductsApi.Service.Data;
using ProductsApi.Service.DTOs;
using ProductsApi.Service.Models;
using ProductsApi.Service.Services;

namespace ProductsApi.Tests
{
    public class ProductServiceTests
    {
        private AppDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public async Task GetProduct_ProductExists_ReturnsProduct()
        {
            var context = CreateContext();
            var newProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Coat",
                Price = 144,
                StockQuantity = 15,
                IsActive = true,
                CategoryId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow
            };
            context.products.Add(newProduct);
            await context.SaveChangesAsync();

            var service = new ProductService(context);
            var result = await service.GetProduct(newProduct.Id);

            Assert.NotNull(result);
            Assert.Equal(newProduct.Id, result.Id);
        }

        [Fact]
        public async Task GetProduct_ProductDoesNotExist_ReturnsNull()
        {
            var context = CreateContext();

            var service = new ProductService(context);
            var result = await service.GetProduct(Guid.NewGuid());

            Assert.Null(result);
        }

        [Fact]
        public async Task CreateProduct_ValidDto_ReturnsCreatedProduct()
        {
            var context = CreateContext();
            var dto = new CreateProductDTO
            {
                Name = "Laptop",
                Price = 999.99,
                StockQuantity = 10,
                CategoryId = Guid.NewGuid()
            };

            var service = new ProductService(context);
            var result = await service.CreateProduct(dto);

            Assert.NotNull(result);
            Assert.Equal(dto.Name, result.Name);
            Assert.Equal(dto.Price, result.Price);
            Assert.True(result.IsActive);
        }

        [Fact]
        public async Task UpdateProduct_ProductExists_ReturnsUpdatedProduct()
        {
            var context = CreateContext();
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Old Name",
                Price = 50,
                StockQuantity = 5,
                IsActive = true,
                CategoryId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow
            };
            context.products.Add(product);
            await context.SaveChangesAsync();

            var dto = new UpdateProductDTO
            {
                Name = "New Name",
                Price = 99,
                StockQuantity = 10,
                IsActive = true
            };

            var service = new ProductService(context);
            var result = await service.UpdateProduct(product.Id, dto);

            Assert.NotNull(result);
            Assert.Equal("New Name", result.Name);
            Assert.Equal(99, result.Price);
        }

        [Fact]
        public async Task UpdateProduct_ProductDoesNotExist_ReturnsNull()
        {
            var context = CreateContext();
            var dto = new UpdateProductDTO
            {
                Name = "New Name",
                Price = 99,
                StockQuantity = 10,
                IsActive = true
            };

            var service = new ProductService(context);
            var result = await service.UpdateProduct(Guid.NewGuid(), dto);

            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteProduct_ProductExists_ReturnsTrue()
        {
            var context = CreateContext();
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Shoes",
                Price = 79,
                StockQuantity = 3,
                IsActive = true,
                CategoryId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow
            };
            context.products.Add(product);
            await context.SaveChangesAsync();

            var service = new ProductService(context);
            var result = await service.DeleteProduct(product.Id);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteProduct_ProductDoesNotExist_ReturnsFalse()
        {
            var context = CreateContext();

            var service = new ProductService(context);
            var result = await service.DeleteProduct(Guid.NewGuid());

            Assert.False(result);
        }
    }
}
