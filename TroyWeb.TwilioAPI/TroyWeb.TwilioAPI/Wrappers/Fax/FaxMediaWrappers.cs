namespace TroyWeb.TwilioAPI.Wrappers.Fax
{
    using System.Threading.Tasks;
    using Twilio.Base;
    using Twilio.Clients;
    using Twilio.Rest.Fax.V1.Fax;

    public static class FaxMediaMediaWrappers
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

        public static async Task<ResourceSet<FaxMediaResource>> GetFaxMediumAsync(ITwilioRestClient client, string faxSid, long? limit = null, int? pageSize = null)
        {
            var options = new ReadFaxMediaOptions(faxSid)
            {
                Limit = limit,
                PageSize = pageSize
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
