﻿namespace Telephony.Models.Interfaces
{
    public interface IBrowsable : ICallable
    {
        string Browse(string url);
    }
}
