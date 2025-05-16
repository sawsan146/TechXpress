using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;

namespace TechXpress.DAL.Repository.Contracts
{
    public interface IContactMessagesRepository:IRepository<ContactMessage,int>
    {
    }
}
