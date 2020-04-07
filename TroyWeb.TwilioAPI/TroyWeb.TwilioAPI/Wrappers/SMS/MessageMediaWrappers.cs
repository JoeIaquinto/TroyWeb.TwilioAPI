namespace TroyWeb.TwilioAPI.Wrappers.SMS
{
    using System.Threading.Tasks;
    using Twilio.Base;
    using Twilio.Clients;
    using Twilio.Rest.Api.V2010.Account.Message;

    public static class MessageMediaWrappers
    {
        public static async Task<bool> DeleteSMSMediaAsync(ITwilioRestClient client,
            string messageSid, string messageMediaSid)
        {
            var options = new DeleteMediaOptions(messageSid, messageMediaSid);
            return await MediaResource.DeleteAsync(options, client);
        }

        public static async Task<MediaResource> GetSMSMediaAsync(ITwilioRestClient client, string messageSid, string messageMediaSid)
        {
            var options = new FetchMediaOptions(messageSid, messageMediaSid);
            return await MediaResource.FetchAsync(options, client);
        }

        public static async Task<ResourceSet<MediaResource>> GetSMSMediasAsync(ITwilioRestClient client, string messageSid, long? limit = null)
        {
            var options = new ReadMediaOptions(messageSid)
            {
                Limit = limit,
                PageSize = null
            };
            return await MediaResource.ReadAsync(options, client);
        }
    }
}
