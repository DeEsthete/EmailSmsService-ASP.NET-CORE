using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Services
{
    public class SmsService : ISmsService
    {
        private const string TWILIO_USER_NAME = "djoniqaz@gmail.com";
        private const string TWILIO_USER_PASSWORD = "Ms5CuDFnDjzA4ui";
        private const string TWILIO_ACCOUNT_SID = "AC0ee885789d5939e0c9356a903d5e1d44";
        private const string TWILIO_AUTH_TOKEN = "214aeade02d0e408c78e72d920b96507";

        public Task SendSms(string phoneNumber, string text)
        {
            return Task.Run(() =>
            {
                TwilioRestClient client;

                // ACCOUNT_SID and ACCOUNT_TOKEN are from your Twilio account
                client = new TwilioRestClient(TWILIO_ACCOUNT_SID, TWILIO_AUTH_TOKEN);

                var result = client.Request(CALLER_ID, "PHONE NUMBER TO SEND TO", "The answer is 42");
                if (result.RestException != null)
                {
                    Debug.Writeline(result.RestException.Message);
                }
            });
        }
    }
}
