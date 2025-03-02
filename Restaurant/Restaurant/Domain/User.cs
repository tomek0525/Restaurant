using Restaurant.Domain;
using System;
using System.Collections.Generic;

namespace OnlineOrderingSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}