using Telephony.Models.Interfaces;

namespace Telephony.Models
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
