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
    [LocalizedDisplayName(nameof(Resources.GetPreviousMessageMediaPage_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetPreviousMessageMediaPage_Description))]
    public class GetPreviousMessageMediaPage : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetPreviousMessageMediaPage_Page_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetPreviousMessageMediaPage_Page_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<Page<MediaResource>> Page { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetPreviousMessageMediaPage_MessageMediaPage_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetPreviousMessageMediaPage_MessageMediaPage_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<Page<MediaResource>> MessageMediaPage { get; set; }

        #endregion


        #region Constructors

        public GetPreviousMessageMediaPage()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetPreviousMessageMediaPage, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
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
            var page = Page.Get(context);

            var lastPage = MessageMediaWrappers.GetPreviousSMSMediaPage(objectContainer.Get<ITwilioRestClient>(), page);

            // Outputs
            return (ctx) => {
                MessageMediaPage.Set(ctx, lastPage);
            };
        }

        #endregion
    }
}

