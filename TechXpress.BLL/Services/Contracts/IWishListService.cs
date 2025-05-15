using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;

namespace TechXpress.BLL.Services.Contracts
{
    public interface IWishListService : IService<WishList, int>
    {
        Task<WishList> GetWishListByUserIdAsync(int userId);
    }
}
