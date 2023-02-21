using APIDealership.Interface;
using APIDealership.Models;
using APIDealership.Request;
using Microsoft.AspNetCore.Mvc;

namespace APIDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly IInventoryRepository _repository;

        public InventoryController(IInventoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetInventory")]
        public async Task<InventoryDescription?> Get(int id)
        {
            var inventory = await _repository.Get(id);
            return inventory;
        }

        [HttpPost(Name = "CreateInventory")]
        public async Task<IActionResult?> Create([FromBody] CreateInventoryRequestcs request)
        {
            var inventory = await _repository.Create(request.Quantity, request.VehicleId, request.DealershipId);
            return Ok();
        }

        [HttpDelete(Name = "DeleteInventory")]
        public async Task<IActionResult?> Delete(int id)
        {
            var inventory = await _repository.Delete(id);
            return Ok();
        }

    }
}
