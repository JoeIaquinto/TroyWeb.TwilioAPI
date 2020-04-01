using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using TroyWeb.TwilioAPI.Activities.Properties;
using TroyWeb.TwilioAPI.Wrappers.SMS;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account.Message;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using UiPath.Shared.Activities.Utilities;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetNextMessageMediaPage_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetNextMessageMediaPage_Description))]
    public class GetNextMessageMediaPage : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetNextMessageMediaPage_Page_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetNextMessageMediaPage_Page_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<Page<MediaResource>> Page { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetNextMessageMediaPage_MessageMediaPage_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetNextMessageMediaPage_MessageMediaPage_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<Page<MediaResource>> MessageMediaPage { get; set; }

        #endregion


        #region Constructors

        public GetNextMessageMediaPage()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetNextMessageMediaPage, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (Page == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(Page)));
            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var page = Page.Get(context);

            var nextPage = MessageMediaWrappers.GetNextSMSMediaPage(objectContainer.Get<ITwilioRestClient>(), page);

            // Outputs
            return (ctx) => {
                MessageMediaPage.Set(ctx, nextPage);
            };
        }

        #endregion
    }
}

