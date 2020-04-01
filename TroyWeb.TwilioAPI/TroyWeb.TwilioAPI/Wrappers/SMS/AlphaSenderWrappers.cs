namespace TroyWeb.TwilioAPI.Wrappers.SMS
{
    using System.Threading.Tasks;
    using Twilio.Base;
    using Twilio.Clients;
    using Twilio.Rest.Messaging.V1.Service;

    public static class AlphaSenderWrappers
    {
        public static async Task<AlphaSenderResource> CreateAlphaSenderAsync(ITwilioRestClient client, string serviceSid, string alphaSenderName)
        {
            var options = new CreateAlphaSenderOptions(serviceSid, alphaSenderName);
            return await AlphaSenderResource.CreateAsync(options, client);
        }

        public static async Task<bool> DeleteAlphaSenderAsync(ITwilioRestClient client, string serviceSid, string alphaSenderSid)
        {
            var options = new DeleteAlphaSenderOptions(serviceSid, alphaSenderSid);
            return await AlphaSenderResource.DeleteAsync(options, client);
        }

        public static async Task<AlphaSenderResource> GetAlphaSenderAsync(ITwilioRestClient client, string serviceSid, string alphaSenderSid)
        {
            var options = new FetchAlphaSenderOptions(serviceSid, alphaSenderSid);
            return await AlphaSenderResource.FetchAsync(options, client);
        }

        public static async Task<ResourceSet<AlphaSenderResource>> GetAlphaSendersAsync(ITwilioRestClient client, string serviceSid, long? limit = null)
        {
            var options = new ReadAlphaSenderOptions(serviceSid)
            {
                Limit = limit,
                PageSize = null
            };
            return await AlphaSenderResource.ReadAsync(options, client);
        }

        public static Page<AlphaSenderResource> GetAlphaSenderPage(ITwilioRestClient client, string targetUrl)
        {
            return AlphaSenderResource.GetPage(targetUrl, client);
        }

        public static Page<AlphaSenderResource> GetNextAlphaSenderPage(ITwilioRestClient client, Page<AlphaSenderResource> page)
        {
            return AlphaSenderResource.NextPage(page, client);
        }

        public static Page<AlphaSenderResource> GetPreviousAlphaSenderPage(ITwilioRestClient client, Page<AlphaSenderResource> page)
        {
            return AlphaSenderResource.PreviousPage(page, client);
        }
    }
}
