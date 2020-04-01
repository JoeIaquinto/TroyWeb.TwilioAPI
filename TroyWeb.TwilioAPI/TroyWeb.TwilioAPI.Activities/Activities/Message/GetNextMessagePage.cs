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
    [LocalizedDisplayName(nameof(Resources.GetNextMessagePage_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetNextMessagePage_Description))]
    public class GetNextMessagePage : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetNextMessagePage_Page_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetNextMessagePage_Page_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<Page<MessageResource>> CurrentPage { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetNextMessagePage_MessagePage_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetNextMessagePage_MessagePage_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<Page<MessageResource>> MessagePage { get; set; }

        #endregion


        #region Constructors

        public GetNextMessagePage()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetNextMessagePage, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (CurrentPage == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(CurrentPage)));
            if (MessagePage == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(MessagePage)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var page = CurrentPage.Get(context);

            var newPage = MessageWrappers.GetNextMessagePage(objectContainer.Get<ITwilioRestClient>(), page);

            // Outputs
            return (ctx) => {
                MessagePage.Set(ctx, newPage);
            };
        }

        #endregion
    }
}

