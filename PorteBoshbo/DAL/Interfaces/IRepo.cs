using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo <T>
    {
        T Get (int id);
        List<T> GetAll ();
        bool Update(T obj);
        bool Add(T obj);
        bool Remove (int id);
    }
}
