﻿namespace Lab5Assignment2.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
        public Product product { get; set; }
        public List<Product> listProduct { get; set; }
    }
}
