using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Repository.Contracts;
using TechXpress.DAL.UnitOfWork;

namespace TechXpress.BLL.Services.Implementations
{
    public class ContactMessagesService : Service<ContactMessage, int>, IContactMessagesService
    {
        public ContactMessagesService(IRepository<ContactMessage, int> repository, IUnitOfWork unitOfWork, ILogger<Service<ContactMessage, int>> logger) : base(repository, unitOfWork, logger)
        {
        }
    }
}
