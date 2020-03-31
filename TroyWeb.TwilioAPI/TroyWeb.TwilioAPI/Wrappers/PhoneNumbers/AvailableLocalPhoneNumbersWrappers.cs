namespace TroyWeb.TwilioAPI.Wrappers.PhoneNumbers
{
    using System.Threading.Tasks;
    using TroyWeb.TwilioAPI.Enums;
    using Twilio.Base;
    using Twilio.Clients;
    using Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry;
    using Twilio.Types;

    public static class AvailableLocalPhoneNumbersWrappers
    {
        public static async Task<ResourceSet<LocalResource>> GetAvailableLocalPhoneNumberAsync(ITwilioRestClient client, CountryCode countryCode, string accountSid = null, int? areaCode = null, bool? smsEnabled = null, bool? mmsEnabled = null, bool? faxEnabled = null, bool? voiceEnabled = null, bool? beta = null, string containsPattern = null, string lata = null, string latLong = null, string nearNumber = null, int? distance = null, string locality = null, string postalCode = null, string rateCenter = null, string region = null, bool? excludeAllAddressRequired = null, bool? excludeForeignAddressRequired = null, bool? excludeLocalAddressRequired = null, long? limit = null, int? pageSize = null)
        {
            var nearPhoneNumber = nearNumber != null ? new PhoneNumber(nearNumber) : null;
            var options = new ReadLocalOptions($"{countryCode:G}")
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
                NearNumber = nearPhoneNumber,
                Distance = distance,
                InLocality = locality,
                InPostalCode = postalCode,
                InRateCenter = rateCenter,
                InRegion = region,
                ExcludeAllAddressRequired = excludeAllAddressRequired,
                ExcludeForeignAddressRequired = excludeForeignAddressRequired,
                ExcludeLocalAddressRequired = excludeLocalAddressRequired,
                Limit = limit,
                PageSize = pageSize
            };
            return await LocalResource.ReadAsync(options, client);
        }

        public static Page<LocalResource> GetAvailableLocalPhoneNumberPage(ITwilioRestClient client, string targetUrl)
        {
            return LocalResource.GetPage(targetUrl, client);
        }

        public static Page<LocalResource> GetNextAvailableLocalPhoneNumberPage(ITwilioRestClient client, Page<LocalResource> page)
        {
            return LocalResource.NextPage(page, client);
        }

        public static Page<LocalResource> GetPreviousAvailableLocalPhoneNumberPage(ITwilioRestClient client, Page<LocalResource> page)
        {
            return LocalResource.PreviousPage(page, client);
        }
    }
}
