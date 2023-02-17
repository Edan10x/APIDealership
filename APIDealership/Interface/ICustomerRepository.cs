using APIDealership.Models;
using APIDealership.Request;

namespace APIDealership.Interface
{
    public interface ICustomerRepository
    {
        Task<Customer?> Create(string firstName, string lastName, int vehicleId, int dealershipId);
        Task<Customer?> Delete(int id);
        Task<CustomerDescription?> Get(int id);
    }
}