using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using YongaTekWebAPI2.Models;

namespace YongaTekWebAPI2.Fake
{
    public class FakeData
    {
        
        private static List<Product> _products;

        public static List<Product> GetProducts(int number)
        {
            if (_products==null)
            {
                _products = new Faker<Product>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Title, f => f.Commerce.Department())
                .RuleFor(p => p.Brand, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => f.Commerce.Price(2, 100, 1, "")).Generate(number);
            }
            
            return _products;
        }
        
    }
}
