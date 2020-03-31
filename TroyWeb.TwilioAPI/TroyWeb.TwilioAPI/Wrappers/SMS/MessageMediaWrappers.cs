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

        public static async Task<ResourceSet<MediaResource>> GetSMSMediumAsync(ITwilioRestClient client, string messageSid, long? limit = null, int? pageSize = null)
        {
            var options = new ReadMediaOptions(messageSid)
            {
                Limit = limit,
                PageSize = pageSize
            };
            return await MediaResource.ReadAsync(options, client);
        }

        public static Page<MediaResource> GetSMSMediaPage(ITwilioRestClient client, string targetUrl)
        {
            return MediaResource.GetPage(targetUrl, client);
        }

        public static Page<MediaResource> GetNextSMSMediaPage(ITwilioRestClient client, Page<MediaResource> page)
        {
            return MediaResource.NextPage(page, client);
        }

        public static Page<MediaResource> GetPreviousSMSMediaPage(ITwilioRestClient client, Page<MediaResource> page)
        {
            return MediaResource.PreviousPage(page, client);
        }
    }
}
