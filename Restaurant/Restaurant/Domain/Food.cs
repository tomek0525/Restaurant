﻿namespace Restaurant.Domain;

public class Food
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public FoodCategory Category{ get; set; }
}