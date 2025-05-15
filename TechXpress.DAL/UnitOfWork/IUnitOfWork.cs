using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Repository;
using TechXpress.DAL.Repository.Contracts;

namespace TechXpress.DAL.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Products { get; }
        IProductImageRepository ProductImages { get; }
        ICartRepository CartRepository { get; }

        Task<int> CompleteAsync();

    }
}
