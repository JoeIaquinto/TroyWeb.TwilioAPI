namespace TroyWeb.TwilioAPI.Wrappers.PhoneNumbers
{
    using System.Threading.Tasks;
    using TroyWeb.TwilioAPI.Enums;
    using Twilio.Base;
    using Twilio.Clients;
    using Twilio.Rest.Api.V2010.Account;

    public static class AvailablePhoneNumbersWrappers
    {
        public static async Task<AvailablePhoneNumberCountryResource> GetAvailablePhoneNumberAsync(ITwilioRestClient client, CountryCode countryCode, string accountSid = null)
        {
            var options = new FetchAvailablePhoneNumberCountryOptions($"{countryCode:G}")
            {
                PathAccountSid = accountSid
            };
            return await AvailablePhoneNumberCountryResource.FetchAsync(options, client);
        }

        public static async Task<ResourceSet<AvailablePhoneNumberCountryResource>> GetAvailablePhoneNumbersAsync(ITwilioRestClient client, string accountSid, long? limit = null)
        {
            var options = new ReadAvailablePhoneNumberCountryOptions()
            {
                PathAccountSid = accountSid,
                Limit = limit,
                PageSize = null
            };
            return await AvailablePhoneNumberCountryResource.ReadAsync(options, client);
        }
    }
}
