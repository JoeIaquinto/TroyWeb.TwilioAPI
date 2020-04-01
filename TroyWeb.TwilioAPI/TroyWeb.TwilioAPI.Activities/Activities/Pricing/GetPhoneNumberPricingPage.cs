using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using TroyWeb.TwilioAPI.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using UiPath.Shared.Activities.Utilities;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetPhoneNumberPricingPage_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetPhoneNumberPricingPage_Description))]
    public class GetPhoneNumberPricingPage : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetPhoneNumberPricingPage_TargetUrl_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetPhoneNumberPricingPage_TargetUrl_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> TargetUrl { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetPhoneNumberPricingPage_PhoneNumberPricingPage_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetPhoneNumberPricingPage_PhoneNumberPricingPage_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<object> PhoneNumberPricingPage { get; set; }

        #endregion


        #region Constructors

        public GetPhoneNumberPricingPage()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetPhoneNumberPricingPage, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
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
            var targeturl = TargetUrl.Get(context);
    
            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////

            // Outputs
            return (ctx) => {
                PhoneNumberPricingPage.Set(ctx, null);
            };
        }

        #endregion
    }
}
