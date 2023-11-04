using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02._Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string phoneNumber)
        {
            if (ValidatePhoneNumber(phoneNumber) == true)
            {
                return $"Calling... {phoneNumber}";

            }
            else
            {
                throw new ArgumentException("Invalid number!");
            }
        }
        public string Browse(string url)
        {
            if (ValidateURL(url) == true)
            {
                return $"Browsing... {url}";

            }
            else
            {
                throw new ArgumentException("Invalid URL!");
            }
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        => phoneNumber.All(x => char.IsDigit(x));
        private bool ValidateURL(string url)
                => url.All(x => !char.IsDigit(x));


    }
}
