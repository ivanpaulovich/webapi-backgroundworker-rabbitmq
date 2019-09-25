using System.Collections.Generic;

namespace Orders.Application.Services
{
    public interface ISubscriber
    {
        IEnumerable<string> Listen();
        void Stop();
    }
}