using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Services.Helpers.Emails
{
     public interface IEmailStructure
    {
        public string To { get; }

        public string Body { get; }
   
        public string Subject {  get; }

    }
}
