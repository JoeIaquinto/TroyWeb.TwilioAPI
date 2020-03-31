namespace TroyWeb.TwilioAPI.Wrappers
{
    using System.Threading.Tasks;
    using Twilio.Base;
    using Twilio.Clients;
    using Twilio.Rest.Api.V2010;

    public static class AccountWrappers
    {
        public static async Task<AccountResource> CreateAccountAsync(ITwilioRestClient client, string friendlyName)
        {
            var options = new CreateAccountOptions()
            {
                FriendlyName = friendlyName
            };
            return await AccountResource.CreateAsync(options, client);
        }

        public static async Task<AccountResource> UpdateAccountAsync(ITwilioRestClient client, string accountSid, string friendlyName, AccountResource.StatusEnum status)
        {
            var options = new UpdateAccountOptions
            {
                Status = status,
                FriendlyName = friendlyName,
                PathSid = accountSid
            };
            return await AccountResource.UpdateAsync(options, client);
        }

        public static async Task<AccountResource> GetAccountAsync(ITwilioRestClient client, string accountSid)
        {
            var options = new FetchAccountOptions
            {
                PathSid = accountSid
            };
            return await AccountResource.FetchAsync(options, client);
        }

        public static async Task<ResourceSet<AccountResource>> GetAccountsAsync(ITwilioRestClient client, string friendlyName = null, AccountResource.StatusEnum status = null, long? limit = null, int? pageSize = null)
        {
            var options = new ReadAccountOptions
            {
                FriendlyName = friendlyName,
                Status = status,
                Limit = limit,
                PageSize = pageSize
            };
            return await AccountResource.ReadAsync(options, client);
        }

        public static Page<AccountResource> GetAccountPage(ITwilioRestClient client, string targetUrl)
        {
            return AccountResource.GetPage(targetUrl, client);
        }

        public static Page<AccountResource> GetNextAccountPage(ITwilioRestClient client, Page<AccountResource> page)
        {
            return AccountResource.NextPage(page, client);
        }

        public static Page<AccountResource> GetPreviousAccountPage(ITwilioRestClient client, Page<AccountResource> page)
        {
            return AccountResource.PreviousPage(page, client);
        }
    }
}
