using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SmsMessage : Entity
    {
        public string RecipientsNumber { get; set; }
        public string Text { get; set; }
    }
}
