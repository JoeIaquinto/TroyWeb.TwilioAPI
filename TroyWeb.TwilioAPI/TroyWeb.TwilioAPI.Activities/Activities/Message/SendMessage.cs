using System;
using System.Activities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TroyWeb.TwilioAPI.Activities.Properties;
using TroyWeb.TwilioAPI.Wrappers.SMS;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using UiPath.Shared.Activities.Utilities;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.SendMessage_DisplayName))]
    [LocalizedDescription(nameof(Resources.SendMessage_Description))]
    public class SendMessage : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendMessage_To_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendMessage_To_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> To { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendMessage_From_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendMessage_From_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> From { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendMessage_Body_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendMessage_Body_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Body { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendMessage_MediaUrl_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendMessage_MediaUrl_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<List<Uri>> MediaUrls { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendMessage_AccountSid_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendMessage_AccountSid_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> AccountSid { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendMessage_MessagingServiceSid_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendMessage_MessagingServiceSid_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> MessagingServiceSid { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendMessage_ApplicationSid_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendMessage_ApplicationSid_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> ApplicationSid { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendMessage_StatusCallback_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendMessage_StatusCallback_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<Uri> StatusCallback { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendMessage_ProvideFeedback_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendMessage_ProvideFeedback_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<bool?> ProvideFeedback { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendMessage_MaxPrice_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendMessage_MaxPrice_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<decimal?> MaxPrice { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendMessage_ValidityPeriod_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendMessage_ValidityPeriod_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<int?> ValidityPeriod { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendMessage_SmartEncoded_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendMessage_SmartEncoded_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<bool?> SmartEncoded { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendMessage_Message_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendMessage_Message_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<MessageResource> Message { get; set; }

        #endregion


        #region Constructors

        public SendMessage()
        {
            Constraints.Add(ActivityConstraints.HasParentType<SendMessage, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            metadata.AddRequiredArgument(To, nameof(To));
            metadata.AddMutuallyExclusiveArguments(Body, nameof(Body), MediaUrls, nameof(MediaUrls));
            metadata.AddMutuallyExclusiveArguments(From, nameof(From), MessagingServiceSid, nameof(MessagingServiceSid));
            metadata.AddMutuallyExclusiveArguments(ApplicationSid, nameof(ApplicationSid), StatusCallback, nameof(StatusCallback));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var to = To.Get(context);
            var from = From.Get(context);
            var body = Body.Get(context);
            var mediaurls = MediaUrls.Get(context);
            var accountsid = AccountSid.Get(context);
            var messagingservicesid = MessagingServiceSid.Get(context);
            var applicationsid = ApplicationSid.Get(context);
            var statuscallback = StatusCallback.Get(context);
            var providefeedback = ProvideFeedback.Get(context);
            var maxprice = MaxPrice.Get(context);
            var validityperiod = ValidityPeriod.Get(context);
            var smartencoded = SmartEncoded.Get(context);

            var message = await MessageWrappers.SendMessageAsync(objectContainer.Get<ITwilioRestClient>(), from, to, body, mediaurls, maxprice, validityperiod, smartencoded, accountsid, applicationsid, messagingservicesid, providefeedback, statuscallback);

            // Outputs
            return (ctx) => {
                Message.Set(ctx, message);
            };
        }

        #endregion
    }
}

