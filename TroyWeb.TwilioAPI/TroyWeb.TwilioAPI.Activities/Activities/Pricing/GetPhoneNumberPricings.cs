using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using TroyWeb.TwilioAPI.Activities.Properties;
using TroyWeb.TwilioAPI.Wrappers.Pricing;
using Twilio.Clients;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using UiPath.Shared.Activities.Utilities;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetPhoneNumberPricings_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetPhoneNumberPricings_Description))]
    public class GetPhoneNumberPricings : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetPhoneNumberPricings_Limit_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetPhoneNumberPricings_Limit_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<long?> Limit { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetPhoneNumberPricings_CountryResources_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetPhoneNumberPricings_CountryResources_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<object> CountryResources { get; set; }

        #endregion


        #region Constructors

        public GetPhoneNumberPricings()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetPhoneNumberPricings, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
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
            var limit = Limit.Get(context);

            var pricings =
                await PhoneNumberPricingWrappers.GetPhoneNumberPricingAsync(objectContainer.Get<ITwilioRestClient>(), limit);

            // Outputs
            return (ctx) => {
                CountryResources.Set(ctx, pricings);
            };
        }

        #endregion
    }
}

