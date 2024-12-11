using Microsoft.AspNetCore.Mvc;
using AdminPartShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace AdminPartShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Products> GetProduct(int id)
        {
            var products = ProductsJson.GetProductsFromFile();
            var product = products.FirstOrDefault(p => p.Id == id);

            return product == null ? NotFound("Продукт не найден.") : Ok(product);
        }

        [HttpGet("All Products")]
        public ActionResult<IEnumerable<Products>> GetAllProducts()
        {
            var products = ProductsJson.GetProductsFromFile();
            return products == null || !products.Any() ? NotFound("Продукты не найдены.") : Ok(products);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var products = ProductsJson.GetProductsFromFile();
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound("Продукт не найден.");
            }

            products.Remove(product);
            ProductsJson.SaveProductsToFile(products);
            return Ok("Продукт успешно удалён.");
        }

        [HttpPost("Add")]
        public ActionResult<Products> AddProduct(Products product)
        {
            var products = ProductsJson.GetProductsFromFile();

            int maxId = products.Count > 0 ? products.Max(p => p.Id) : 0;

            product.Id = maxId + 1;

            products.Add(product);
            ProductsJson.SaveProductsToFile(products);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }


        [HttpPut("Update/{id}")]
        public ActionResult<Products> UpdateProduct(int id, Products updatedProduct)
        {
            var products = ProductsJson.GetProductsFromFile();
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound("Продукт не найден.");
            }

            product.Name_Product = updatedProduct.Name_Product;
            product.Price = updatedProduct.Price;
            product.Count_Product = updatedProduct.Count_Product;
            product.Description = updatedProduct.Description;
            product.ImagePath = updatedProduct.ImagePath;
            product.CategoryID = updatedProduct.CategoryID;
            product.Rating = updatedProduct.Rating;

            ProductsJson.SaveProductsToFile(products);
            return Ok(product);
        }

    }
}
