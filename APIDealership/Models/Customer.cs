namespace APIDealership.Models
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        
        public int VehicleId { get; set; }

        public int DealershipId { get; set; }
    }
    
}
