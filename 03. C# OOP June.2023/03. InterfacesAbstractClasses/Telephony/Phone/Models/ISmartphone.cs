namespace Telephony.Phone.Models
{
    internal interface ISmartphone : IPhone
    {
        public string Call(string phoneNumber);
        void Browse();
    }
}
