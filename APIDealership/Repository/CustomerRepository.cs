using APIDealership.Interface;
using APIDealership.Models;
using APIDealership.Request;
using Dapper;
using System.Data.SqlClient;

namespace APIDealership.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlConnection _connection;

        public CustomerRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<CustomerDescription?> Get(int id)
        {
            var customer = await _connection.QueryAsync<CustomerDescription>($"SELECT FirstName, LastName, Make, Model, Year, Color, VinNumber FROM Customer " +
                                                                  $"inner join Vehicle on VehicleId = Vehicle.id " +
                                                                  $"inner join Dealership on DealershipId = Dealership.id " +
                                                                  $"WHERE [Customer].id = {id}");
            return customer.FirstOrDefault();
        }

        public async Task<Customer?> Create(string firstName, string lastName, int vehicleId, int dealershipId)
        {
            var customer = await _connection.QueryAsync<Customer>($"INSERT INTO [dbo].[Customer] " +
                                                                  $"VALUES ('{firstName}', '{lastName}', {vehicleId}, {dealershipId});");
            return customer.FirstOrDefault();
        }

        public async Task<Customer?> Delete(int id)
        {
            var customer = await _connection.QueryAsync($"DELETE FROM[DealershipDb].[dbo].[Customer]  " +
                                                        $"WHERE id = {id};");

            return customer.FirstOrDefault();
        }
    }
}
