using Microsoft.Extensions.Options;
using SendEmailWithTwilio.Helper;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SendEmailWithTwilio.Services
{
    public class SMSServices : ISMSServices
    {
        private readonly TwilioSetting _twilio;

        public SMSServices(IOptions<TwilioSetting> twilio)
        {
            _twilio = twilio.Value;
        }

        public MessageResource Send(string mobileNumber, string body)
        {

            TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);

            var result = MessageResource.Create(
                    body: body,
                    from : new Twilio.Types.PhoneNumber(_twilio.TwilioPhoneNumber),
                    to : mobileNumber
                );
            return result;
        }
    }
}
