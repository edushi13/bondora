using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private IItemsRepository _itemRepo;
        public ItemController(IItemsRepository repo)
        {
            _itemRepo = repo;
        }

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _itemRepo.GetItems();
        }

        [HttpGet("{id}")]
        public Item GetItem(int id)
        {
            return _itemRepo.GetItem(id);
        }
    }
}