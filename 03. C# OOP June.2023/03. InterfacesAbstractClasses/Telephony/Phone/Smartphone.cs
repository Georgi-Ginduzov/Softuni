using Telephony.Phone.Models;

namespace Telephony.Phone
{
    internal class Smartphone : ISmartphone
    {
        public string Call(string phoneNumber)
        => $"Calling... {phoneNumber}";
        public void Browse()
        {
            //To do
        }

        
    }
}
