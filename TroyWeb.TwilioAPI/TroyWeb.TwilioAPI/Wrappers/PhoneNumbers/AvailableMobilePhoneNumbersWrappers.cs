namespace TroyWeb.TwilioAPI.Wrappers.PhoneNumbers
{
    using System.Threading.Tasks;
    using TroyWeb.TwilioAPI.Enums;
    using Twilio.Base;
    using Twilio.Clients;
    using Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry;
    using Twilio.Types;

    public static class AvailableMobilePhoneNumbersWrappers
    {
        public static async Task<ResourceSet<MobileResource>> GetAvailableMobilePhoneNumberAsync(ITwilioRestClient client, CountryCode countryCode, string accountSid = null, int? areaCode = null, bool? smsEnabled = null, bool? mmsEnabled = null, bool? faxEnabled = null, bool? voiceEnabled = null, bool? beta = null, string containsPattern = null, string lata = null, string latLong = null, PhoneNumber nearNumber = null, int? distance = null, string locality = null, string postalCode = null, string rateCenter = null, string region = null, bool? excludeAllAddressRequired = null, bool? excludeForeignAddressRequired = null, bool? excludeMobileAddressRequired = null, long? limit = null)
        {
            var options = new ReadMobileOptions($"{countryCode:G}")
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
                ExcludeLocalAddressRequired = excludeMobileAddressRequired,
                Limit = limit,
                PageSize = null
            };
            return await MobileResource.ReadAsync(options, client);
        }

        public static Page<MobileResource> GetAvailableMobilePhoneNumberPage(ITwilioRestClient client, string targetUrl)
        {
            return MobileResource.GetPage(targetUrl, client);
        }

        public static Page<MobileResource> GetNextAvailableMobilePhoneNumberPage(ITwilioRestClient client, Page<MobileResource> page)
        {
            return MobileResource.NextPage(page, client);
        }

        public static Page<MobileResource> GetPreviousAvailableMobilePhoneNumberPage(ITwilioRestClient client, Page<MobileResource> page)
        {
            return MobileResource.PreviousPage(page, client);
        }
    }
}
