namespace APIDealership.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int VehicleId { get; set; }

        public int DealershipId { get; set; }
    }
}
