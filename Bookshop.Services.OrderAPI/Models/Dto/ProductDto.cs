﻿namespace Bookshop.Services.OrderAPI.Models.Dto
{
    public class ProductDto
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Precio { get; set; }
        public string Autor { get; set; }
        public string CategoriaName { get; set; }
        public string ImageUrl { get; set; }


        public int Count { get; set; } = 1;
    }
}
