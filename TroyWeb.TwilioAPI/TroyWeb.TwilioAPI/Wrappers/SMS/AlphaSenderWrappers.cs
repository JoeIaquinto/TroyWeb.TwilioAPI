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
    }
}
