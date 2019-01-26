using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Services;
using Services.Abstract;

namespace AspCoreHomeWork.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private MainContext _context;

        public ServiceController(MainContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<EmailMessage> Get()
        {
            return _context.EmailMessages.ToList();
        }

        [HttpPost]
        public IActionResult SendEmail([FromBody]EmailMessage message)
        {
            if (message == null)
            {
                return BadRequest();
            }

            try
            {
                IEmailService service = new EmailService();
                service.SendSimpleEmailMessage(message.To, message.Title, message.Text);
                
                _context.EmailMessages.Add(message);

                return Ok(message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult SendSms([FromBody]SmsMessage message)
        {
            if (message == null)
            {
                return BadRequest();
            }

            try
            {
                ISmsService service = new SmsService();
                service.SendSms(message.RecipientsNumber, message.Text);
                
                _context.SmsMessages.Add(message);

                return Ok(message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}