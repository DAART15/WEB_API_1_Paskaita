namespace WEB_API_1_Paskaita.Models
{
    public class Contact
    {
        public Contact(int id, string firstName, string lastName, string company, string phoneNumber, string mail, string note)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Company = company;
            PhoneNumber = phoneNumber;
            Mail = mail;
            Note = note;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
