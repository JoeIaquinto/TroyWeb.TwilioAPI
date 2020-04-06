namespace TroyWeb.TwilioAPI.Wrappers.Fax
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Twilio.Base;
    using Twilio.Clients;
    using Twilio.Rest.Fax.V1;
    using Twilio.Rest.Fax.V1.Fax;
    using Twilio.TwiML.Voice;

    public static class FaxMediaWrappers
    {
        public static async Task<bool> DeleteFaxMediaAsync(ITwilioRestClient client,
            string faxSid, string faxMediaSid)
        {
            var options = new DeleteFaxMediaOptions(faxSid, faxMediaSid);
            return await FaxMediaResource.DeleteAsync(options, client);
        }

        public static async Task<FaxMediaResource> GetFaxMediaAsync(ITwilioRestClient client, string faxSid, string faxMediaSid)
        {
            var options = new FetchFaxMediaOptions(faxSid, faxMediaSid);
            return await FaxMediaResource.FetchAsync(options, client);
        }

        public static async Task<ResourceSet<FaxMediaResource>> GetFaxMediasAsync(ITwilioRestClient client, string faxSid, long? limit = null)
        {
            var options = new ReadFaxMediaOptions(faxSid)
            {
                Limit = limit,
                PageSize = null
            };
            return await FaxMediaResource.ReadAsync(options, client);
        }

        public static Page<FaxMediaResource> GetFaxMediaPage(ITwilioRestClient client, string targetUrl)
        {
            return FaxMediaResource.GetPage(targetUrl, client);
        }

        public static Page<FaxMediaResource> GetNextFaxMediaPage(ITwilioRestClient client, Page<FaxMediaResource> page)
        {
            return FaxMediaResource.NextPage(page, client);
        }

        public static Page<FaxMediaResource> GetPreviousFaxMediaPage(ITwilioRestClient client, Page<FaxMediaResource> page)
        {
            return FaxMediaResource.PreviousPage(page, client);
        }
    }
}
