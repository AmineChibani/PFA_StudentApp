
using Twilio.Types;
using Twilio;
using Microsoft.Extensions.Options;
using Twilio.Rest.Api.V2010.Account;

namespace StudentApp.Services
{
    public class SmsService : IServiceSender
    { 
        private readonly TwilioSetting _twilioSettings;
        private SmsEntity smsEntity { get; set; }

        public SmsService(IOptions<TwilioSetting> twilioSettings)
        {
            _twilioSettings = twilioSettings.Value;
            TwilioClient.Init(_twilioSettings.AccountSid, _twilioSettings.AuthToken);
        }
        
        public bool SendMessage()
        {
            try
            {
                var messageOptions = new CreateMessageOptions(new PhoneNumber(smsEntity.ToPhoneNumber))
                {
                    From = new PhoneNumber(_twilioSettings.PhoneNumber),
                    Body = smsEntity.bodyMessage
                };
                MessageResource.Create(messageOptions);
                return true;
            }
            catch
            {
                return false;
            } 
        }


    }
}
