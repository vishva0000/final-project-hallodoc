using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace BusinessLayer.Utility
{
    public class SMSSend
    {
        public void sendSMS(string msg)
        {
            var accountSid = "ACce727103bb81a94a70d2df3bed9b3bd0";
            var authToken = "5cbcf89282a29103f5102cf344c192ba";
            TwilioClient.Init(accountSid, authToken);        

            var message = MessageResource.Create(body: msg,
         from: new Twilio.Types.PhoneNumber("+12512204228"),
         to: new Twilio.Types.PhoneNumber("+916352804566")
     );

        }
    }
}
