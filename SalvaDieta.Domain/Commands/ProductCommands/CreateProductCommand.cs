﻿namespace SalvaDieta.Domain.Commands.ProductCommands
{
    public class CreateProductCommand
    {
        public CreateProductCommand(
               string title, 
               string description,
               string weight,
               decimal price, 
               int quantityOnHand, 
               int category, 
               string image = "")
        {
            this.Title = title;
            this.Description = description;
            this.Weight = weight;
            this.Price = price;
            this.QuantityOnHand = quantityOnHand;
            this.CategoryId = category;
            this.Image = image;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Weight { get; private set; }
        public decimal Price { get; set; }
        public int QuantityOnHand { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
