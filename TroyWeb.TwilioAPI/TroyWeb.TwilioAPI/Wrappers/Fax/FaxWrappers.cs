namespace TroyWeb.TwilioAPI.Wrappers.Fax
{
    using System;
    using System.Threading.Tasks;
    using Twilio.Base;
    using Twilio.Clients;
    using Twilio.Rest.Fax.V1;

    public static class FaxWrappers
    {
        public static async Task<FaxResource> SendFaxAsync(ITwilioRestClient client, string from, string to, Uri mediaUrl, FaxResource.QualityEnum quality = null, string sipAuthUsername = null, string sipAuthPassword = null, Uri statusCallback = null, bool? storeMedia = null, int? minutesToSend = null)
        {
            var options = new CreateFaxOptions(to, mediaUrl)
            {
                From = from,
                Quality = quality ?? FaxResource.QualityEnum.Standard,
                SipAuthUsername = sipAuthUsername,
                SipAuthPassword = sipAuthPassword,
                StatusCallback = statusCallback,
                StoreMedia = storeMedia,
                Ttl = minutesToSend
            };
            return await FaxResource.CreateAsync(options, client);
        }

        public static async Task<FaxResource> CancelFaxAsync(ITwilioRestClient client, string faxSid, string accountSid = null)
        {
            var options = new UpdateFaxOptions(faxSid)
            {
                Status = FaxResource.UpdateStatusEnum.Canceled
            };
            return await FaxResource.UpdateAsync(options, client);
        }

        public static async Task<bool> DeleteFaxAsync(ITwilioRestClient client,
            string faxSid)
        {
            var options = new DeleteFaxOptions(faxSid);
            return await FaxResource.DeleteAsync(options, client);
        }

        public static async Task<FaxResource> GetFaxAsync(ITwilioRestClient client, string faxSid)
        {
            var options = new FetchFaxOptions(faxSid);
            return await FaxResource.FetchAsync(options, client);
        }

        public static async Task<ResourceSet<FaxResource>> GetFaxesAsync(ITwilioRestClient client, string from = null, string to = null, DateTime? dateCreatedAfter = null, DateTime? dateCreatedOnOrBefore = null, long? limit = null, int? pageSize = null)
        {
            var options = new ReadFaxOptions
            {
                DateCreatedAfter = dateCreatedAfter,
                DateCreatedOnOrBefore = dateCreatedOnOrBefore,
                From = from,
                To = to,
                Limit = limit,
                PageSize = pageSize
            };
            return await FaxResource.ReadAsync(options, client);
        }

        public static Page<FaxResource> GetFaxPage(ITwilioRestClient client, string targetUrl)
        {
            return FaxResource.GetPage(targetUrl, client);
        }

        public static Page<FaxResource> GetNextFaxPage(ITwilioRestClient client, Page<FaxResource> page)
        {
            return FaxResource.NextPage(page, client);
        }

        public static Page<FaxResource> GetPreviousFaxPage(ITwilioRestClient client, Page<FaxResource> page)
        {
            return FaxResource.PreviousPage(page, client);
        }
    }
}
