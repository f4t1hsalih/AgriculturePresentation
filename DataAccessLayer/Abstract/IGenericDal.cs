using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //where T : class: Bu ifade, T tipinin bir referans tipi (class) olması gerektiğini belirtir.
    //where T : new (): Bu ifade, T tipinin parametresiz bir kurucuya sahip olması gerektiğini belirtir.
    public interface IGenericDal<T> where T : class, new()
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        T GetById(int id);
        List<T> GetListAll();

    }
}
