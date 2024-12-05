using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPartShop.Models
{
    public class JsonUser
    {
        private const string FilePath = "C:\\Users\\rakhm\\source\\repos\\AdminPartShop\\AdminPartShop\\JsonFiles\\users.json";

        public static List<User> GetUsers()
        {
            string json = File.ReadAllText(FilePath);
            var users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
            return users;
        }

        public static void SaveUsers(List<User> users)
        {
            string newJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(FilePath, newJson);
        }
    }
}
