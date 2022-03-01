using ApiRest.Dto;
using ApiRest.Entities;

namespace ApiRest
{
          public static class Extentions
          {
                    public static ItemDto AsDto(this Item item)
                    {
                              return new ItemDto
                              {
                                        Id = item.Id,
                                        Name = item.Name,
                                        Price = item.Price,
                                        Stored = item.Stored,
                                        CreateDate = item.CreateDate
                              };
                    }
          }
}