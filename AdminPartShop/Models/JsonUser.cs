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

        private static bool IsJsonValid(string json)
        {
            try
            {
                var users = JsonConvert.DeserializeObject<List<User>>(json);
                return users != null;
            }
            catch
            {
                return false;
            }
        }


        public static List<User> GetUsers()
        {
            string json = File.ReadAllText(FilePath);

            if (IsJsonValid(json))
            {
                var users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
                return users;
            }
            else
            {
                SaveUsers(new List<User>());
                return new List<User>();
            }
        }

        public static void SaveUsers(List<User> users)
        {
            string newJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(FilePath, newJson);
        }
    }
}
