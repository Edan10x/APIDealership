using APIDealership.Interface;
using APIDealership.Models;
using APIDealership.Request;
using Microsoft.AspNetCore.Mvc;

namespace APIDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {

        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetCustomer")]
        public async Task<CustomerDescription?> Get(int id)
        {
            var customer = await _repository.Get(id);
            return customer;
        }
        [HttpPost(Name = "CreateCustomer")]
        public async Task<IActionResult?> Create([FromBody] CreateCustomerRequest request)
        {
            var customer = await _repository.Create(request.FirstName, request.LastName, request.VehicleId, request.DealershipId);
            return Ok();
        }


        [HttpDelete(Name = "DeleteCustomer")]
        public async Task<IActionResult?> Delete(int id)
        {
            var customer = await _repository.Delete(id);
            return Ok();
        }

    }
}
