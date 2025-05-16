using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Infrastructure;
using TechXpress.DAL.Repository.Contracts;

namespace TechXpress.DAL.Repository.Implementations
{
    public class ContactMessagesRepository:Repository<ContactMessage,int>,IContactMessagesRepository
    {
        public ContactMessagesRepository(AppDbContext context) : base(context)
        {
        }
    }
  
}
