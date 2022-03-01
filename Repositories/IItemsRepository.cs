using System;
using System.Collections.Generic;
using ApiRest.Entities;

namespace ApiRest.Repositories
{
          public interface IItemsRepository
          {
                    Item GetItem(Guid id);
                    IEnumerable<Item> GetItems();
                    void CreateItem(Item item);
          }
}