﻿using Newtonsoft.Json;
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

        public static List<Products> GetProductsFromFile()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Products>();
            }

            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Products>>(json);
        }

        public static void SaveProductsToFile(List<Products> products)
        {
            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}
