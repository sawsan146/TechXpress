using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs;
using TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;

namespace TechXpress.Application.ApplicationServices.Implementation
{
    public class ContactMessageAppService : IContactMessageAppService
    {
        private readonly IContactMessagesService _contactMessagesService;
        private readonly IMapper _mapper;


        public ContactMessageAppService(IContactMessagesService contactMessagesService, IMapper mapper)
        {
            _contactMessagesService = contactMessagesService;
            _mapper = mapper;
        }

        public void SendMessage(ContactMassegeDTO contactMassegeDTO)
        {
            if (contactMassegeDTO != null)
            {
                var Message = _mapper.Map<ContactMessage>(contactMassegeDTO);
                _contactMessagesService.Add(Message);
            }
            else
            {

                throw new ArgumentNullException(nameof(contactMassegeDTO), "Contact message cannot be null.");
            }

            }
    }
}
