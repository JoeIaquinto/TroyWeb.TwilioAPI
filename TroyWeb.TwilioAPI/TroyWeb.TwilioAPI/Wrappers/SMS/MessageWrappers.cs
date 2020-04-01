namespace TroyWeb.TwilioAPI.Wrappers.SMS
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Twilio.Base;
    using Twilio.Clients;
    using Twilio.Rest.Api.V2010.Account;
    using Twilio.Types;

    public static class MessageWrappers
    {
        public static async Task<MessageResource> SendMessageAsync(ITwilioRestClient client, string from, string to, string body, List<Uri> media = null, decimal? maxPrice = null, int? validityPeriod = null, bool? smartEncoded = null, string accountSid = null, string applicationSid = null, string messagingServiceSid = null, bool? provideFeedback = null, Uri statusCallback = null)
        {
            var fromNumber = new PhoneNumber(from);
            var toNumber = new PhoneNumber(to);
            var options = new CreateMessageOptions(toNumber)
            {
                From = fromNumber,
                Body = body,
                MediaUrl = media,
                MaxPrice = maxPrice,
                ValidityPeriod = validityPeriod,
                SmartEncoded = smartEncoded,
                PathAccountSid = accountSid,
                ApplicationSid = applicationSid,
                MessagingServiceSid = messagingServiceSid,
                ProvideFeedback = provideFeedback,
                StatusCallback = statusCallback
            };
            return await MessageResource.CreateAsync(options, client);
        }

        public static async Task<MessageResource> CancelMessageAsync(ITwilioRestClient client, string messageSid, string accountSid = null)
        {
            var options = new UpdateMessageOptions(messageSid, string.Empty)
            {
                PathAccountSid = accountSid
            };
            return await MessageResource.UpdateAsync(options, client);
        }

        public static async Task<MessageResource> UpdateMessageAsync(ITwilioRestClient client, string messageSid, string body, string accountSid = null)
        {
            var options = new UpdateMessageOptions(messageSid, body)
            {
                PathAccountSid = accountSid
            };
            return await MessageResource.UpdateAsync(options, client);
        }

        public static async Task<bool> DeleteMessageAsync(ITwilioRestClient client,
            string messageSid, string accountSid = null)
        {
            var options = new DeleteMessageOptions(messageSid)
            {
                PathAccountSid = accountSid
            };
            return await MessageResource.DeleteAsync(options, client);
        }

        public static async Task<MessageResource> GetMessageAsync(ITwilioRestClient client, string messageSid, string accountSid)
        {
            var options = new FetchMessageOptions(messageSid)
            {
                PathAccountSid = accountSid
            };
            return await MessageResource.FetchAsync(options, client);
        }

        public static async Task<ResourceSet<MessageResource>> GetMessagesAsync(ITwilioRestClient client, string from = null, string to = null, string accountSid = null, DateTime? dateSent = null, DateTime? dateSentAfter = null, DateTime? dateSentBefore = null, long? limit = null)
        {
            var fromNumber = from != null ? new PhoneNumber(from) : null;
            var toNumber = to != null ? new PhoneNumber(to) : null;
            var options = new ReadMessageOptions
            {
                PathAccountSid = accountSid,
                DateSent = dateSent,
                DateSentAfter = dateSentAfter,
                DateSentBefore = dateSentBefore,
                From = fromNumber,
                Limit = limit,
                To = toNumber,
                PageSize = null
            };
            return await MessageResource.ReadAsync(options, client);
        }
    }
}
