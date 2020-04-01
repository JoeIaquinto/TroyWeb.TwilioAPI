using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using TroyWeb.TwilioAPI.Activities.Properties;
using TroyWeb.TwilioAPI.Wrappers.SMS;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using UiPath.Shared.Activities.Utilities;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetMessages_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetMessages_Description))]
    public class GetMessages : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetMessages_From_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetMessages_From_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> From { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetMessages_To_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetMessages_To_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> To { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetMessages_DateSent_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetMessages_DateSent_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<DateTime?> DateSent { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetMessages_DateSentBefore_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetMessages_DateSentBefore_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<DateTime?> DateSentBefore { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetMessages_DateSentAfter_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetMessages_DateSentAfter_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<DateTime?> DateSentAfter { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetMessages_AccountSid_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetMessages_AccountSid_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> AccountSid { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetMessages_Limit_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetMessages_Limit_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<long?> Limit { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetMessages_Messages_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetMessages_Messages_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<ResourceSet<MessageResource>> Messages { get; set; }

        #endregion


        #region Constructors

        public GetMessages()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetMessages, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var from = From.Get(context);
            var to = To.Get(context);
            var datesent = DateSent.Get(context);
            var datesentbefore = DateSentBefore.Get(context);
            var datesentafter = DateSentAfter.Get(context);
            var accountsid = AccountSid.Get(context);
            var limit = Limit.Get(context);

            var messages = await MessageWrappers.GetMessagesAsync(objectContainer.Get<ITwilioRestClient>(), from, to, accountsid, datesent, datesentafter, datesentbefore, limit);

            // Outputs
            return (ctx) => {
                Messages.Set(ctx, messages);
            };
        }

        #endregion
    }
}

