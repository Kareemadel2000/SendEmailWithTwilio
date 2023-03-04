using Twilio.Rest.Api.V2010.Account;

namespace SendEmailWithTwilio.Services
{
    public interface ISMSServices
    {
        MessageResource Send(string mobileNumber, string body);
    }
}
