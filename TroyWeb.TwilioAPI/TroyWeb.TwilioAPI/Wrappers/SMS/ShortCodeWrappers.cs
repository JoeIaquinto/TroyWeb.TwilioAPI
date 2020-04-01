namespace TroyWeb.TwilioAPI.Wrappers.SMS
{
    using System.Threading.Tasks;
    using Twilio.Base;
    using Twilio.Clients;
    using Twilio.Rest.Api.V2010.Account;

    public static class ShortCodeWrappers
    {
        public static async Task<ShortCodeResource> UpdateShortCodeAsync(ITwilioRestClient client, string shortCodeSid, string accountSid = null, string friendlyName = null, System.Uri smsUrl = null, Twilio.Http.HttpMethod smsMethod = null, System.Uri smsFallbackUrl = null, Twilio.Http.HttpMethod smsFallbackMethod = null)
        {
            var options = new UpdateShortCodeOptions(shortCodeSid)
            {
                PathAccountSid = accountSid,
                FriendlyName = friendlyName,
                SmsUrl = smsUrl,
                SmsMethod = smsMethod,
                SmsFallbackUrl = smsFallbackUrl,
                SmsFallbackMethod = smsFallbackMethod
            };
            return await ShortCodeResource.UpdateAsync(options, client);
        }

        public static async Task<ShortCodeResource> GetShortCodeAsync(ITwilioRestClient client, string shortCodeSid, string accountSid)
        {
            var options = new FetchShortCodeOptions(shortCodeSid)
            {
                PathAccountSid = accountSid,
            };
            return await ShortCodeResource.FetchAsync(options, client);
        }

        public static async Task<ResourceSet<ShortCodeResource>> GetShortCodesAsync(ITwilioRestClient client, string accountSid = null, string shortCode = null, string friendlyName = null, long? limit = null)
        {
            var options = new ReadShortCodeOptions
            {
                PathAccountSid = accountSid,
                ShortCode = shortCode,
                FriendlyName = friendlyName,
                Limit = limit,
                PageSize = null
            };
            return await ShortCodeResource.ReadAsync(options, client);
        }

        public static Page<ShortCodeResource> GetShortCodePage(ITwilioRestClient client, string targetUrl)
        {
            return ShortCodeResource.GetPage(targetUrl, client);
        }

        public static Page<ShortCodeResource> GetNextShortCodePage(ITwilioRestClient client, Page<ShortCodeResource> page)
        {
            return ShortCodeResource.NextPage(page, client);
        }

        public static Page<ShortCodeResource> GetPreviousShortCodePage(ITwilioRestClient client, Page<ShortCodeResource> page)
        {
            return ShortCodeResource.PreviousPage(page, client);
        }
    }
}
