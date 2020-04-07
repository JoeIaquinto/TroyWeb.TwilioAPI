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

        public static async Task<ResourceSet<CountryResource>> GetPhoneNumberPricingAsync(ITwilioRestClient client, long? limit)
        {
            var options = new ReadCountryOptions
            {
                Limit = limit,
                PageSize = null
            };
            return await CountryResource.ReadAsync(options, client);
        }
    }
}
