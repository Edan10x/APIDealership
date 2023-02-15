using APIDealership.Interface;
using APIDealership.Models;
using APIDealership.Request;
using Microsoft.AspNetCore.Mvc;

namespace APIDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealershipController : Controller
    {
        private readonly IDealershipRepository _repository;

        public DealershipController(IDealershipRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetDealership")]
        public async Task<Dealership?> Get(int id)
        {
            var dealership = await _repository.Get(id);
            return dealership;
        }

        [HttpPost(Name = "CreateDealership")]
        public async Task<IActionResult?> Create([FromBody] CreateDealershipRequests request)
        {

            var dealership = await _repository.Create(request.City, request.State);
            return Ok();
        }

        [HttpDelete(Name = "DeleteDealership")]
        public async Task<IActionResult?> Delete(int id)
        {

            var dealership = await _repository.Delete(id);
            return Ok();
        }
    }
}
