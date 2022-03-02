using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiRest.Repositories;
using System.Linq;
using ApiRest.Dto;
using ApiRest.Dtos;
using ApiRest.Entities;

namespace ApiRest.Controllers
{
        [ApiController]
        [Route(" items")]
        public class ItemsController : ControllerBase
        {

                private readonly IItemsRepository repository;

                public ItemsController(IItemsRepository repository)
                {
                        this.repository = repository;
                }

                [HttpGet]
                public IEnumerable<ItemDto> GetItems()
                {
                        var item = repository.GetItems().Select(item => item.AsDto());
                        return item;
                }

                [HttpGet("{id}")]
                public ActionResult<ItemDto> GetItem(Guid id)
                {
                        var item = repository.GetItem(id);
                        if (item is null)
                        {
                                return NotFound();
                        }
                        return item.AsDto();
                }

                [HttpPost]
                public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
                {
                        Item item = new()
                        {
                                Id = Guid.NewGuid(),
                                Name = itemDto.Name,
                                Price = itemDto.Price,
                                Stored = itemDto.Stored,
                                CreateDate = DateTimeOffset.UtcNow
                        };
                        repository.CreateItem(item);

                        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
                }

                //PUT  /items/{id}
                [HttpPut("{id}")]
                public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
                {
                        var existingItem = repository.GetItem(id);
                        if (existingItem is null)
                        {
                                return NotFound();
                        }
                        Item updateItem = existingItem with
                        {
                                Name = itemDto.Name,
                                Price = itemDto.Price,
                                Stored = itemDto.Stored,
                                CreateDate = DateTimeOffset.UtcNow
                        };
                        repository.UpdateItem(updateItem);

                        return NoContent();
                }
        }
}


//dependecy injection
//class  => uses =>         other class
//data transfer object  DTO
//example:
// public Items Contrillers(){
// repository = new inMenItemsRepositories();
// }
// Dependency inversion Principle

// public ItemsController(repository)
// {
//           this.repository = repository
// }
// inject  the repository dependecy

// WHY?? => by having our code depend upon abstractions we are decoupling our code from the implementation  from each other

// How to construct the dependencies
// dependecy  a, dependecy b, dependecy c = (register)=> IserviceProvider ==(resolve contruct and inject dependencies)=> class

