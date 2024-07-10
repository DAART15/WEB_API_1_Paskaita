
namespace WEB_API_1_Paskaita.Controllers.Models
{
    public class Food
    {
        public Food(int id, string name, string country, double weight)
        {
            this.id = id;
            Name = name;
            Country = country;
            Weight = weight;
            CreationDateTime = DateTime.Now;
            ExpirationDateTime = DateTime.Now.AddDays(30);
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public double Weight { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ExpirationDateTime { get; set; }
    }
}
