using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace E02._Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (ValidatePhoneNumber(phoneNumber) == true)
            {
                return $"Dialing... {phoneNumber}";

            }
            else
            {
                throw new ArgumentException("Invalid number!");
            }
        }

        private bool ValidatePhoneNumber(string phoneNumber)
       => phoneNumber.All(x => char.IsDigit(x));
    }
}
