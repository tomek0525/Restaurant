using Restaurant.Domain;
using System;
using System.Collections.Generic;

namespace OnlineOrderingSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}
