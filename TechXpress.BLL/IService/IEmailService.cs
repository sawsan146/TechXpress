using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Services.Helpers.Emails;

namespace TechXpress.BLL.IService
{
    public interface IEmailService
    {

        public Task SendEmail(IEmailStructure emailStructure);


    }
}
