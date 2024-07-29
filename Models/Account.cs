namespace WEB_API_1_Paskaita.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
    }
}
