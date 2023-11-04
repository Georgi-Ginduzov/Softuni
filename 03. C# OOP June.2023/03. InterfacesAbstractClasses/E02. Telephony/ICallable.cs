using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02._Telephony
{
    public interface ICallable
    {
        public string Call(string phoneNumber);
    }
}
