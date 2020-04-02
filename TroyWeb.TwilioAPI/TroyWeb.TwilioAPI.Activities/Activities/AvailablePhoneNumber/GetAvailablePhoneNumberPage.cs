using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using TroyWeb.TwilioAPI.Activities.Properties;
using TroyWeb.TwilioAPI.Wrappers.PhoneNumbers;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using UiPath.Shared.Activities.Utilities;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetAvailablePhoneNumberPage_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetAvailablePhoneNumberPage_Description))]
    public class GetAvailablePhoneNumberPage : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailablePhoneNumberPage_TargetUrl_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailablePhoneNumberPage_TargetUrl_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> TargetUrl { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailablePhoneNumberPage_AvailablePhoneNumberPage_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailablePhoneNumberPage_AvailablePhoneNumberPage_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<Page<TollFreeResource>> AvailablePhoneNumberPage { get; set; }

        #endregion


        #region Constructors

        public GetAvailablePhoneNumberPage()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetAvailablePhoneNumberPage, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (TargetUrl == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(TargetUrl)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var targeturl = TargetUrl.Get(context);

            var page = AvailablePhoneNumbersWrappers.GetAvailablePhoneNumberPage(
                objectContainer.Get<ITwilioRestClient>(), targeturl);

            // Outputs
            return (ctx) => {
                AvailablePhoneNumberPage.Set(ctx, page);
            };
        }

        #endregion
    }
}

