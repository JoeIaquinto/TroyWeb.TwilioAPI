namespace TroyWeb.TwilioAPI.Wrappers.PhoneNumbers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TroyWeb.TwilioAPI.Enums;
    using Twilio.Clients;
    using Twilio.Rest.Lookups.V1;

    public static class LookupWrappers
    {
        public static async Task<PhoneNumberResource> LookupPhoneNumber(ITwilioRestClient client, string number, CountryCode? countryCode, bool includeCallerName, bool includeCarrier, List<string> addOns, Dictionary<string, object> addOnsData)
        {
            var phoneNumber = new Twilio.Types.PhoneNumber(number);
            var type = new List<string>();
            if (includeCallerName)
            {
                type.Add("caller_name");
            }
            if (includeCarrier)
            {
                type.Add("carrier");
            }
            var options = new FetchPhoneNumberOptions(phoneNumber)
            {
                CountryCode = countryCode != null ? $"{countryCode:G}" : null,
                Type = type,
                AddOns = addOns,
                AddOnsData = addOnsData
            };

            return await PhoneNumberResource.FetchAsync(options, client);
        }
    }
}
