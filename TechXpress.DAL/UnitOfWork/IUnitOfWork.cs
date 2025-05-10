using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Logic.Repository.Contracts;

namespace TechXpress.Logic.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Products { get; }
        Task<int> CompleteAsync();

    }
}
