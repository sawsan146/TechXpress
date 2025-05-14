using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.BLL.Services.Contracts
{
    public interface IService<T, TKey> where T : class
    {
        T GetById(TKey id);

        List<T> GetAll();

        bool Add(T entity);

        bool Update(T entity);

        bool Delete(TKey id);
    }


}
