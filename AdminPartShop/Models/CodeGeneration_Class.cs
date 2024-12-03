using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPartShop.Models
{
    public class TwoFactorAuthenticationService
    {
        private string code;
        private DateTime codeGeneratedTime;
        private readonly TimeSpan codeExpirationDuration = TimeSpan.FromMinutes(3);

        public void GenerateCode()
        {
            Random random = new Random();
            code = random.Next(1000, 9999).ToString();
            codeGeneratedTime = DateTime.Now;
        }

        public string GetCode()
        {
            return code;
        }

        public bool IsCodeValid(string inputCode)
        {
            if (DateTime.Now - codeGeneratedTime > codeExpirationDuration)
            {
                return false;
            }

            return inputCode == code;
        }
    }
}
