﻿namespace WEB_API_1_Paskaita.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? City { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;
    }
}