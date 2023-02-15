using APIDealership.Models;

namespace APIDealership.Interface
{
    public interface IVehicleRepository
    {
        Task<Vehicle?> Create(string make, string model, string year, string color, string vinNumber, double price);
        Task<Vehicle?> Delete(int id);
        Task<Vehicle?> Get(int id);
    }
}