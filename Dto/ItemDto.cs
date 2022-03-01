using System;

namespace ApiRest.Dto
{
          public record ItemDto
          {
                    public Guid Id { get; set; }
                    public string Name { get; set; }
                    public decimal Price { get; set; }
                    public int Stored { get; set; }
                    public DateTimeOffset CreateDate { get; set; }
          }
}