using System;
using System.Activities;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using TroyWeb.TwilioAPI.Activities.Properties;
using TroyWeb.TwilioAPI.Enums;
using TroyWeb.TwilioAPI.Wrappers.Pricing;
using Twilio.Clients;
using Twilio.Rest.Pricing.V1.PhoneNumber;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using UiPath.Shared.Activities.Utilities;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetPhoneNumberPricing_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetPhoneNumberPricing_Description))]
    public class GetPhoneNumberPricing : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetPhoneNumberPricing_CountryCode_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetPhoneNumberPricing_CountryCode_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        [TypeConverter(typeof(EnumNameConverter<CountryCode>))]
        public CountryCode CountryCode { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetPhoneNumberPricing_CountryResource_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetPhoneNumberPricing_CountryResource_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<CountryResource> CountryResource { get; set; }

        #endregion


        #region Constructors

        public GetPhoneNumberPricing()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetPhoneNumberPricing, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
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
            var countrycode = CountryCode;

            var pricing =
                await PhoneNumberPricingWrappers.GetPhoneNumberPricingAsync(objectContainer.Get<ITwilioRestClient>(),
                    countrycode);

            // Outputs
            return (ctx) => {
                CountryResource.Set(ctx, pricing);
            };
        }

        #endregion
    }
}

