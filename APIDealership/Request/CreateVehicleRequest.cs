namespace APIDealership.Request
{
    public class CreateVehicleRequest
    {
        public int Id { get; set; }

        public string? Make { get; set; }

        public string? Model { get; set; }

        public string? Year { get; set; }

        public string? Color { get; set; }

        // i want to generate a uniqe vin for each car
        public string? VinNumber { get; set; }

        public int Price { get; set; }
    }
}
