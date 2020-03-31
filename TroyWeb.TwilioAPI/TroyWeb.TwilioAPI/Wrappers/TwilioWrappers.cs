namespace TroyWeb.TwilioAPI.Wrappers
{
    using System;
    using Twilio.Clients;
    using Twilio.Http;

    public static class TwilioWrappers
    {
        public static ITwilioRestClient GetTwilioRestClient(string accountSid, string authToken, string region, TimeSpan? timeout)
        {
            var clientTimeout = timeout ?? new TimeSpan(0, 5, 0);
            var httpClient = new System.Net.Http.HttpClient
            {
                Timeout = clientTimeout
            };

            var client = new TwilioRestClient(accountSid, authToken, accountSid, region, new SystemNetHttpClient(httpClient));
            return client;
        }
    }
}
