namespace TroyWeb.TwilioAPI.Wrappers.Pricing
{
    using System.Threading.Tasks;
    using TroyWeb.TwilioAPI.Enums;
    using Twilio.Base;
    using Twilio.Clients;
    using Twilio.Rest.Pricing.V2.Voice;

    public static class VoicePricingWrappers
    {
        public static async Task<CountryResource> GetVoicePricingAsync(ITwilioRestClient client, CountryCode countryCode)
        {
            return await CountryResource.FetchAsync($"{countryCode:G}", client);
        }

        public static async Task<ResourceSet<CountryResource>> GetVoicePricingAsync(ITwilioRestClient client, long? limit, int? pageSize)
        {
            var options = new ReadCountryOptions();
            options.Limit = limit;
            options.PageSize = pageSize;
            return await CountryResource.ReadAsync(options, client);
        }

        public static Page<CountryResource> GetVoicePricingPage(ITwilioRestClient client, string targetUrl)
        {
            return CountryResource.GetPage(targetUrl, client);
        }

        public static Page<CountryResource> GetNextVoicePricingPage(ITwilioRestClient client, Page<CountryResource> page)
        {
            return CountryResource.NextPage(page, client);
        }

        public static Page<CountryResource> GetPreviousVoicePricingPage(ITwilioRestClient client, Page<CountryResource> page)
        {
            return CountryResource.PreviousPage(page, client);
        }
    }
}
