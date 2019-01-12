using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ISmsService
    {
        Task SendSms(string phoneNumber, string text);
    }
}
