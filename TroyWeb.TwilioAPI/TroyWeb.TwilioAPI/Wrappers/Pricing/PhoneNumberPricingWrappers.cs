namespace TroyWeb.TwilioAPI.Wrappers.Pricing
{
    using System.Threading.Tasks;
    using TroyWeb.TwilioAPI.Enums;
    using Twilio.Base;
    using Twilio.Clients;
    using Twilio.Rest.Pricing.V1.PhoneNumber;

    public static class PhoneNumberPricingWrappers
    {
        public static async Task<CountryResource> GetPhoneNumberPricingAsync(ITwilioRestClient client, CountryCode countryCode)
        {
            return await CountryResource.FetchAsync($"{countryCode:G}", client);
        }

        public static async Task<ResourceSet<CountryResource>> GetPhoneNumberPricingAsync(ITwilioRestClient client, long? limit, int? pageSize)
        {
            var options = new ReadCountryOptions();
            options.Limit = limit;
            options.PageSize = pageSize;
            return await CountryResource.ReadAsync(options, client);
        }

        public static Page<CountryResource> GetPhoneNumberPricingPage(ITwilioRestClient client, string targetUrl)
        {
            return CountryResource.GetPage(targetUrl, client);
        }

        public static Page<CountryResource> GetNextPhoneNumberPricingPage(ITwilioRestClient client, Page<CountryResource> page)
        {
            return CountryResource.NextPage(page, client);
        }

        public static Page<CountryResource> GetPreviousPhoneNumberPricingPage(ITwilioRestClient client, Page<CountryResource> page)
        {
            return CountryResource.PreviousPage(page, client);
        }
    }
}
