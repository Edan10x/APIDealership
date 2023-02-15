using APIDealership.Interface;
using APIDealership.Models;
using Dapper;
using System;
using System.Data.SqlClient;

namespace APIDealership.Repository
{
    
    public class VehicleRepository : IVehicleRepository
    {

        private readonly SqlConnection _connection;
        

        public VehicleRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<Vehicle?> Get(int id)
        {
            var vehicle = await _connection.QueryAsync<Vehicle>($"SELECT * FROM [dbo].[Vehicle] " +
                                                                $"WHERE id = {id};");
            return vehicle.FirstOrDefault();
        }

        public async Task<Vehicle?> Create(string make, string model, string year, string color, string vinNumber, double price)
        {
            
            var vehicle = await _connection.QueryAsync<Vehicle>($"INSERT INTO [dbo].[Vehicle]" +
                                                                $"VALUES ('{make}', '{model}','{year}', '{color}', '{vinNumber}', {price});");
            return vehicle.FirstOrDefault();
        }

        public async Task<Vehicle?> Delete(int id)
        {
            var vehicle = await _connection.QueryAsync($"DELETE FROM[DealershipDb].[dbo].[Vehicle]  " +
                                                       $"WHERE id = {id};");

            return vehicle.FirstOrDefault();
        }
    }
}
