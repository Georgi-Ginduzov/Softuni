using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Phone.Models;

namespace Telephony.Phone
{
    internal class StationaryPhone : IPhone
    {
        public string Call(string phoneNumber)
        => $"Dialing... {phoneNumber}";
    }
}
