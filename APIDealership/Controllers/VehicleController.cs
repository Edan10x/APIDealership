using APIDealership.Interface;
using APIDealership.Models;
using APIDealership.Request;
using Microsoft.AspNetCore.Mvc;

namespace APIDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _repository;

        public VehicleController(IVehicleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetVehicle")]
        public async Task<Vehicle?> Get(int id)
        {
            var vehicle = await _repository.Get(id);
            return vehicle;
        }
        
        [HttpPost(Name = "CreateVehicle")]
        public async Task<IActionResult?> Create([FromBody] CreateVehicleRequest request)
        {
           var vehicle = await _repository.Create(request.Make, request.Model, request.Year, request.Color, request.VinNumber, request.Price);
           return Ok();
        }

        [HttpDelete(Name = "DeleteVehicle")]
        public async Task<IActionResult?> Delete(int id)
        {
           var vehicle = await _repository.Delete(id);
            return Ok();
        }
    }
}
