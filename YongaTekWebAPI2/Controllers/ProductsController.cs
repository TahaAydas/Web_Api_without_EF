using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YongaTekWebAPI2.Fake;
using YongaTekWebAPI2.Models;

namespace YongaTekWebAPI2.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private List<Product> _products = FakeData.GetProducts(100);


        [HttpGet]
        public List<Product> Get()
        {
            return _products;
        }


        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            return product;
        }


        [HttpPost]
        public Product Post([FromBody]Product product)
        {
            _products.Add(product);
            return product;
        }

        [HttpPut]
        public Product Put([FromBody] Product product)
        {
            var editedProducts = _products.FirstOrDefault(x=>x.Id==product.Id);
            editedProducts.Brand = product.Brand;
            editedProducts.Price = product.Price;
            editedProducts.Title = product.Title;

            _products.Add(product);
            return product;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedProducts = _products.FirstOrDefault(x=>x.Id==id);
            _products.Remove(deletedProducts);
        }

    }
}
