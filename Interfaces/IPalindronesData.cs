using System;
using System.Linq;

namespace Interfaces
{
    public interface IPalindronesData
    {
        void Add(string item);
        IQueryable<string> Get();
    }
}
