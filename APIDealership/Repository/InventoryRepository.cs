using APIDealership.Interface;
using APIDealership.Models;
using APIDealership.Request;
using Dapper;
using System.Data.SqlClient;

namespace APIDealership.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly SqlConnection _connection;

        public InventoryRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<InventoryDescription?> Get(int id)
        {
            var inventory = await _connection.QueryAsync<InventoryDescription>($"SELECT Quantity, Make, Model, Year FROM Inventory " +
                                                                               $"inner join Vehicle on VehicleId = Vehicle.id " +
                                                                               $"inner join Dealership on DealershipId = Dealership.id " +
                                                                               $"WHERE [Inventory].id = {id}");
            return inventory.FirstOrDefault();
        }

        public async Task<Inventory?> Create(int quantity, int vehicleId, int dealershipId)
        {
            var inventory = await _connection.QueryAsync<Inventory>($"INSERT INTO [dbo].[Inventory] " +
                                                                    $"VALUES{quantity}, {vehicleId}, {dealershipId});");
            return inventory.FirstOrDefault();
        }

        public async Task<Inventory?> Delete(int id)
        {
            var inventory = await _connection.QueryAsync($"DELETE FROM[DealershipDb].[dbo].[Inventory] " +
                                                         $"WHERE id = {id};");

            return inventory.FirstOrDefault();
        }
    }
}
