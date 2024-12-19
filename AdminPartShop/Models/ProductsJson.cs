using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPartShop.Models
{
    public class ProductsJson
    {
        private const string FilePath = "C:\\Users\\rakhm\\source\\repos\\AdminPartShop\\AdminPartShop\\JsonFiles\\products.json";

        private static bool IsJsonValid(string json)
        {
            try
            {
                var products = JsonConvert.DeserializeObject<List<Products>>(json);
                return products != null;
            }
            catch
            {
                return false;
            }
        }

        public static List<Products> GetProductsFromFile()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Products>();
            }

            var json = File.ReadAllText(FilePath);

            if (IsJsonValid(json))
            {
                var collection = JsonConvert.DeserializeObject<List<Products>>(json) ?? new List<Products>();

                foreach (var product in collection)
                {
                    if (!File.Exists(product.ImagePath))
                    {
                        product.ImagePath = "C:\\Users\\rakhm\\Downloads\\no-image.png";
                    }
                }

                return collection;
            }
            else
            {
                SaveProductsToFile(new List<Products>());
                return new List<Products>();
            }
        }

        public static void SaveProductsToFile(List<Products> products)
        {
            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}
