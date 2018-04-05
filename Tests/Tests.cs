using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Xunit;

namespace GifService.Tests
{
    public class SomeUnitTests
    {
        [Fact]
        public void CanSendGif()
        {
            const string accountSid = "AC27e30810c241bc256c8d93174c8fe7b1";
            const string authToken = "3392bc4f4f78c9e65ad8f8f2490f3695";
            TwilioClient.Init(accountSid, authToken);

            var mediaUrl = new List<Uri>()
            {
                new Uri("https://media2.giphy.com/media/xT0BKwUV9bLhr8btRK/200_d.gif")
            };
            var to = new PhoneNumber("+18014034602");
            var message = MessageResource.Create(to,
                                                 from: new PhoneNumber("+13852470161"),
                                                 mediaUrl: mediaUrl);
        }
    }
}