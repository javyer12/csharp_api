using System;

namespace ApiRest.Entities
{
          //record  type is used to work with immutable objects, is  like class but with different 
          //with-expressions support 
          //value-based equality suppot

          public record Item
          {
                    public Guid Id { get; init; }
                    public string Name { get; init; }
                    public decimal Price { get; init; }
                    public int Stored { get; init; }
                    public DateTimeOffset CreateDate { get; init; }
          }
}