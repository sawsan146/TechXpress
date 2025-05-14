using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.DAL.Repository.Contracts
{
    using TechXpress.DAL.Entities;
    using TechXpress.Logic.Repository.Contracts;

    public interface ICategoryRepository : IRepository<Category,string>
    {
       
    }

}
