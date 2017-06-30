using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Twilio;

namespace MvcAppExample.Infra.CrossCutting.Identity.Configurations
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Habilitar o envio de e-mail
            if (false)
            {
                // Utilizando TWILIO como SMS Provider.
                // https://www.twilio.com/docs/quickstart/csharp/sms/sending-via-rest

                const string accountSid = "SEU ID";
                const string authToken = "SEU TOKEN";

                var client = new TwilioRestClient(accountSid, authToken);

                client.SendMessage("Seu Telefone", message.Destination, message.Body);
            }

            return Task.FromResult(0);
        }
    }
}