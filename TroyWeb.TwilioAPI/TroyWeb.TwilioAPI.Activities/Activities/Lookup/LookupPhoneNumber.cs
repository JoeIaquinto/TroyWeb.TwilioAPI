using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using TroyWeb.TwilioAPI.Activities.Properties;
using TroyWeb.TwilioAPI.Enums;
using TroyWeb.TwilioAPI.Wrappers.PhoneNumbers;
using Twilio.Clients;
using Twilio.Rest.Lookups.V1;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using UiPath.Shared.Activities.Utilities;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.LookupPhoneNumber_DisplayName))]
    [LocalizedDescription(nameof(Resources.LookupPhoneNumber_Description))]
    public class LookupPhoneNumber : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.LookupPhoneNumber_Number_DisplayName))]
        [LocalizedDescription(nameof(Resources.LookupPhoneNumber_Number_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Number { get; set; }

        [LocalizedDisplayName(nameof(Resources.LookupPhoneNumber_CountryCode_DisplayName))]
        [LocalizedDescription(nameof(Resources.LookupPhoneNumber_CountryCode_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        [TypeConverter(typeof(EnumNameConverter<CountryCode>))]
        public CountryCode? CountryCode { get; set; }

        [LocalizedDisplayName(nameof(Resources.LookupPhoneNumber_IncludeCallerName_DisplayName))]
        [LocalizedDescription(nameof(Resources.LookupPhoneNumber_IncludeCallerName_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<bool> IncludeCallerName { get; set; }

        [LocalizedDisplayName(nameof(Resources.LookupPhoneNumber_IncludeCarrier_DisplayName))]
        [LocalizedDescription(nameof(Resources.LookupPhoneNumber_IncludeCarrier_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<bool> IncludeCarrier { get; set; }

        [LocalizedDisplayName(nameof(Resources.LookupPhoneNumber_AddOns_DisplayName))]
        [LocalizedDescription(nameof(Resources.LookupPhoneNumber_AddOns_Description))]
        [LocalizedCategory(nameof(Resources.Options_Category))]
        public InArgument<List<string>> AddOns { get; set; }

        [LocalizedDisplayName(nameof(Resources.LookupPhoneNumber_AddOnsData_DisplayName))]
        [LocalizedDescription(nameof(Resources.LookupPhoneNumber_AddOnsData_Description))]
        [LocalizedCategory(nameof(Resources.Options_Category))]
        public InArgument<Dictionary<string, object>> AddOnsData { get; set; }

        [LocalizedDisplayName(nameof(Resources.LookupPhoneNumber_PhoneNumber_DisplayName))]
        [LocalizedDescription(nameof(Resources.LookupPhoneNumber_PhoneNumber_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<PhoneNumberResource> PhoneNumber { get; set; }

        #endregion


        #region Constructors

        public LookupPhoneNumber()
        {
            Constraints.Add(ActivityConstraints.HasParentType<LookupPhoneNumber, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            metadata.AddRequiredArgument(Number, nameof(Number));
            metadata.AddRequiredArgument(IncludeCallerName, nameof(IncludeCallerName));
            metadata.AddRequiredArgument(IncludeCarrier, nameof(IncludeCarrier));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var number = Number.Get(context);
            var countrycode = CountryCode;
            var includeCallerName = IncludeCallerName.Get(context);
            var includeCarrier = IncludeCarrier.Get(context);
            var addOns = AddOns.Get(context);
            var addOnsData = AddOnsData.Get(context);

            var lookup = await LookupWrappers.LookupPhoneNumber(objectContainer.Get<ITwilioRestClient>(), number, countrycode,
                includeCallerName, includeCarrier, addOns, addOnsData);

            // Outputs
            return (ctx) => {
                PhoneNumber.Set(ctx, lookup);
            };
        }

        #endregion
    }
}

