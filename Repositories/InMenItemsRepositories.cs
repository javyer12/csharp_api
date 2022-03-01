using System;
using System.Collections.Generic;
using System.Linq;
using ApiRest.Entities;

namespace ApiRest.Repositories
{
          public class InMenItemsRepositories : IItemsRepository
          {
                    //target-type
                    private readonly List<Item> items = new()
                    {
                              new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, Stored = 6, CreateDate = DateTimeOffset.UtcNow },
                              new Item { Id = Guid.NewGuid(), Name = "Potion-deal", Price = 19, Stored = 5, CreateDate = DateTimeOffset.UtcNow },
                              new Item { Id = Guid.NewGuid(), Name = "Potion-feal", Price = 29, Stored = 15, CreateDate = DateTimeOffset.UtcNow },
                              new Item { Id = Guid.NewGuid(), Name = "cellphones", Price = 999, Stored = 53, CreateDate = DateTimeOffset.UtcNow },
                    };

                    public IEnumerable<Item> GetItems()
                    {
                              return items;
                    }
                    public Item GetItem(Guid id)
                    {
                              return items.Where(item => item.Id == id).SingleOrDefault();
                    }

                    public void CreateItem(Item item)
                    {
                              items.Add(item);
                    }
          }
}