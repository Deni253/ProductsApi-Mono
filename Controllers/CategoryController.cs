using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProductsApi.Service.DTOs;
using ProductsApi.Service.Services;


namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/Categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service) { this._service = service; }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var result = await _service.GetCategory(id);
            if (result == null) { return NotFound(); }
            else
            {
                var responseDTO = new CategoryResponseDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description

                };

                return Ok(responseDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]CategoryDTO dto)
        {
            var result = await _service.CreateCategory(dto);
            if (result == null) { return BadRequest(); }
            else
            {
                var responseDTO = new CategoryResponseDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description

                };

                return Ok(responseDTO);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            bool result = await _service.DeleteCategory(id);
            if (result == false) { return BadRequest(); }
            else
            {
    

                return Ok(result);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id,[FromBody] CategoryDTO dto)
        {
            var result = await _service.UpdateCategory(id,dto);
            if (result == null) { return NotFound(); }
            else
            {
                var responseDTO = new CategoryResponseDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description

                };

                return Ok(responseDTO);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery]CategorySortDTO sort, [FromQuery] PagingDto page)
        {
            var result = await _service.GetAllCategories(sort,page);
            List <CategoryResponseDTO> responseDTOs= new List<CategoryResponseDTO>();
            if (result == null) { return NotFound(); }
            else
            {
                foreach (var item in result)
                {
                    var responseDTO = new CategoryResponseDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description

                    };
                    responseDTOs.Add(responseDTO);
                }
                return Ok(responseDTOs);
            }
        }


    }
}
