using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DatabasovyProjektPV.Core;


namespace DatabasovyProjektPV.Core
{
    public interface IRepozitory<T> where T : IBaseClass
    {
        T GetByID(int id);
        IEnumerable<T> GetAll();
        void Save(T element);
        void Delete(T element);
    }
}
