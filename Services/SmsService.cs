using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Services
{
    public class SmsService : ISmsService
    {
        private const string TWILIO_ACCOUNT_SID = "AC0ee885789d5939e0c9356a903d5e1d44";
        private const string TWILIO_AUTH_TOKEN = "214aeade02d0e408c78e72d920b96507";

        public Task SendSms(string phoneNumber, string text)
        {
            return Task.Run(() =>
            {
                TwilioClient.Init(
                    Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID"),
                    Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN"));
                MessageResource.Create(
                    to: new PhoneNumber("87071434861"),
                    from: new PhoneNumber("AC0ee885789d5939e0c9356a903d5e1d44"),
                    body: "Ahoy from Twilio!");
            });
        }
    }
}
