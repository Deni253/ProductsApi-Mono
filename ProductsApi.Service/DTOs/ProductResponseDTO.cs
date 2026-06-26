using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Service.DTOs
{
    public class ProductResponseDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        [Range(3,12)]
        public string Name { get; set; }

        [Range(0.01,double.MaxValue)]
        public double Price { get; set; }
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
