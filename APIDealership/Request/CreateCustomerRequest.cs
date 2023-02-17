namespace APIDealership.Request
{
    public class CreateCustomerRequest
    {

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int VehicleId { get; set; }

        public int DealershipId { get; set; }
    }
}
