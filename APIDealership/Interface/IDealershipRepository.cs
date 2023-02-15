using APIDealership.Models;

namespace APIDealership.Interface
{
    public interface IDealershipRepository
    {
        Task<Dealership?> Create(string city, string state);
        Task<Dealership?> Delete(int id);
        Task<Dealership?> Get(int id);
    }
}