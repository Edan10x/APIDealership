using APIDealership.Models;
using APIDealership.Request;

namespace APIDealership.Interface
{
    public interface IInventoryRepository
    {
        Task<Inventory?> Create(int quantity, int vehicleId, int dealershipId);
        Task<Inventory?> Delete(int id);
        Task<InventoryDescription?> Get(int id);
    }
}