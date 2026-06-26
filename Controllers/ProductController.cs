using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProductsApi.Service.DTOs;
using ProductsApi.Service.Services;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductController:ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            this._service = service;
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var result = await _service.GetProduct(id);
            if (result == null) { return NotFound();}
            else
            {
                var responseDTO = new ProductResponseDTO
                {
                    Id = result.Id,
                    CategoryId = result.CategoryId,
                    Name = result.Name,
                    Price = result.Price,
                    StockQuantity = result.StockQuantity,
                    IsActive = result.IsActive,
                    CreatedAt = result.CreatedAt

                };

                return Ok(responseDTO);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductDTO dto)
        {
            var result = await _service.CreateProduct(dto);
            if (result == null) { return BadRequest(); }
            else
            {
                var responseDTO = new ProductResponseDTO
                {
                    Id = result.Id,
                    CategoryId = result.CategoryId,
                    Name = result.Name,
                    Price = result.Price,
                    StockQuantity = result.StockQuantity,
                    IsActive = result.IsActive,
                    CreatedAt = result.CreatedAt

                };

                return Ok(responseDTO);
            }

        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id,[FromBody] UpdateProductDTO dto)
        {
            var result = await _service.UpdateProduct(id,dto);
            if (result == null) { return NotFound(); }
            else
            {
            var responseDTO = new ProductResponseDTO
                {
                 Id = result.Id,
                 CategoryId = result.CategoryId,
                 Name = result.Name,
                 Price = result.Price,
                 StockQuantity = result.StockQuantity,
                 IsActive = result.IsActive,
                 CreatedAt = result.CreatedAt

                };
            
                 return Ok(responseDTO); 
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            bool result = await _service.DeleteProduct(id);

            if (result == false) { return BadRequest(); }
            else { return Ok(result); }

        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductFilterDto filter, [FromQuery] PagingDto page, [FromQuery] string sort = "Price", [FromQuery] string direction = "Ascending")
        {
            
            var sortDto = new ProductSortDto
            {
                Sort = Enum.Parse<ProductSortDto.SortBy>(sort),
                Direction = Enum.Parse<ProductSortDto.SortDirection>(direction)
            };
            var result = await _service.GetAllProducts(filter, sortDto, page);
            List<ProductResponseDTO> responseDTOs = new List<ProductResponseDTO>();
            if (result == null) { return NotFound(); }
            else
            {
                foreach (var r in result)
                {
                   var responseDTO = new ProductResponseDTO
                   {
                    Id = r.Id,
                    CategoryId = r.CategoryId,
                    Name = r.Name,
                    Price = r.Price,
                    StockQuantity = r.StockQuantity,
                    IsActive = r.IsActive,
                    CreatedAt = r.CreatedAt

                    };
                    responseDTOs.Add(responseDTO);
                }
            }
            
            
            return Ok(responseDTOs);

        }
    }
}
