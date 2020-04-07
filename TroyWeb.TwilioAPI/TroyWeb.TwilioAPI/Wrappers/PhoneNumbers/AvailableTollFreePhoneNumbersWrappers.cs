namespace TroyWeb.TwilioAPI.Wrappers.PhoneNumbers
{
    using System.Threading.Tasks;
    using TroyWeb.TwilioAPI.Enums;
    using Twilio.Base;
    using Twilio.Clients;
    using Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry;
    using Twilio.Types;

    public static class AvailableTollFreePhoneNumbersWrappers
    {
        public static async Task<ResourceSet<TollFreeResource>> GetAvailableTollFreePhoneNumberAsync(ITwilioRestClient client, CountryCode countryCode, string accountSid = null, int? areaCode = null, bool? smsEnabled = null, bool? mmsEnabled = null, bool? faxEnabled = null, bool? voiceEnabled = null, bool? beta = null, string containsPattern = null, string lata = null, string latLong = null, PhoneNumber nearNumber = null, int? distance = null, string locality = null, string postalCode = null, string rateCenter = null, string region = null, bool? excludeAllAddressRequired = null, bool? excludeForeignAddressRequired = null, bool? excludeTollFreeAddressRequired = null, long? limit = null)
        {
            var options = new ReadTollFreeOptions($"{countryCode:G}")
            {
                PathAccountSid = accountSid,
                AreaCode = areaCode,
                SmsEnabled = smsEnabled,
                MmsEnabled = mmsEnabled,
                FaxEnabled = faxEnabled,
                VoiceEnabled = voiceEnabled,
                Beta = beta,
                Contains = containsPattern,
                InLata = lata,
                NearLatLong = latLong,
                NearNumber = nearNumber,
                Distance = distance,
                InLocality = locality,
                InPostalCode = postalCode,
                InRateCenter = rateCenter,
                InRegion = region,
                ExcludeAllAddressRequired = excludeAllAddressRequired,
                ExcludeForeignAddressRequired = excludeForeignAddressRequired,
                ExcludeLocalAddressRequired = excludeTollFreeAddressRequired,
                Limit = limit,
                PageSize = null
            };
            return await TollFreeResource.ReadAsync(options, client);
        }
    }
}
