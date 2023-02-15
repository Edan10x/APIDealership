using APIDealership.Interface;
using APIDealership.Models;
using Dapper;
using Microsoft.Extensions.Primitives;
using System.Data.SqlClient;
using System.Security.Principal;

namespace APIDealership.Repository
{
    public class DealershipRepository : IDealershipRepository
    {
        private readonly SqlConnection _connection;

        public DealershipRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<Dealership?> Get(int id)
        {
            var dealership = await _connection.QueryAsync<Dealership>($"SELECT * FROM [dbo].[Dealership] WHERE id = {id};");
            return dealership.FirstOrDefault();
        }

        public async Task<Dealership?> Create(string city, string state)
        {
            var dealership = await _connection.QueryAsync<Dealership>($"INSERT INTO [dbo].[Dealership] VALUES ('{city}', '{state}');");
            return dealership.FirstOrDefault();
        }

        public async Task<Dealership?> Delete(int id)
        {
            var dealership = await _connection.QueryAsync($"DELETE FROM[DealershipDb].[dbo].[Dealership] WHERE id = {id};");

            return dealership.FirstOrDefault();
        }
    }
}
