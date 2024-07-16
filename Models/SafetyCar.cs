namespace WEB_API_1_Paskaita.Models
{
    public class SafetyCar
    {
        public SafetyCar(int id, string brand, string model, string color)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Color = color;
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }
}
