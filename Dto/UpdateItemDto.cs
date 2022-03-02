using System.ComponentModel.DataAnnotations;

namespace ApiRest.Dtos
{
        public record UpdateItemDto
        {
                [Required]
                public string Name { get; set; }
                [Required]
                [Range(10, 1000)]
                public decimal Price { get; set; }
                [Required]
                [Range(1, 100)]
                public int Stored { get; set; }
        }
}