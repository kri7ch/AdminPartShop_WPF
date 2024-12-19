using AdminPartShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace AdminPartShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Products> products;

        public ProductController()
        {
            products = ProductsJson.GetProductsFromFile();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Products>> GetProducts()
        {
            return Ok(products);
        }

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

            if (products == null)
            {
                return NotFound("Продукты не найдены.");
            }
            return Ok(products);
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
            product.ImageBase64 = updatedProduct.ImageBase64;
            product.CategoryID = updatedProduct.CategoryID;
            product.Rating = updatedProduct.Rating;

            ProductsJson.SaveProductsToFile(products);
            return Ok(product);
        }

        [HttpGet("Search")]
        public ActionResult<IEnumerable<Products>> Search(string query)
        {
            var filteredProducts = products.Where(p => p.Name_Product.ToLower().Contains(query.ToLower())).ToList();
            return Ok(filteredProducts);
        }

        [HttpGet("Filter")]
        public ActionResult<IEnumerable<Products>> Filter(int? categoryId, string priceFilter)
        {
            IEnumerable<Products> filteredProducts = products;

            if (categoryId.HasValue && categoryId.Value != 0)
            {
                filteredProducts = filteredProducts.Where(p => p.CategoryID == categoryId.Value);
            }

            if (!string.IsNullOrEmpty(priceFilter))
            {
                switch (priceFilter)
                {
                    case "1":
                        filteredProducts = filteredProducts.OrderBy(p => ParsePrice(p.Price));
                        break;

                    case "2":
                        filteredProducts = filteredProducts.OrderByDescending(p => ParsePrice(p.Price));
                        break;

                    case "3":
                        filteredProducts = filteredProducts.Where(p => p.Rating >= 1 && p.Rating <= 5).OrderBy(p => p.Rating);
                        break;

                    case "4":
                        filteredProducts = filteredProducts.Where(p => p.Rating >= 1 && p.Rating <= 5).OrderByDescending(p => p.Rating);
                        break;
                }
            }

            return Ok(filteredProducts.ToList());
        }

        private decimal ParsePrice(string priceText)
        {
            var match = Regex.Match(priceText, @"\d+");
            if (match.Success)
            {
                return decimal.Parse(match.Value);
            }
            return 0;
        }
    }
}
