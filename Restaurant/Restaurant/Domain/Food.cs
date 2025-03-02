﻿using System;
using System.Collections.Generic;

namespace OnlineOrderingSystem.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}