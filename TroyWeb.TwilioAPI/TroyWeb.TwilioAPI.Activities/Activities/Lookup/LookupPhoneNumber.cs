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
        public InArgument<string> CountryCode { get; set; }

        [LocalizedDisplayName(nameof(Resources.LookupPhoneNumber_IncludeCallerName_DisplayName))]
        [LocalizedDescription(nameof(Resources.LookupPhoneNumber_IncludeCallerName_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> IncludeCallerName { get; set; }

        [LocalizedDisplayName(nameof(Resources.LookupPhoneNumber_IncludeCarrier_DisplayName))]
        [LocalizedDescription(nameof(Resources.LookupPhoneNumber_IncludeCarrier_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> IncludeCarrier { get; set; }

        [LocalizedDisplayName(nameof(Resources.LookupPhoneNumber_AddOns_DisplayName))]
        [LocalizedDescription(nameof(Resources.LookupPhoneNumber_AddOns_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> AddOns { get; set; }

        [LocalizedDisplayName(nameof(Resources.LookupPhoneNumber_AddOnsData_DisplayName))]
        [LocalizedDescription(nameof(Resources.LookupPhoneNumber_AddOnsData_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> AddOnsData { get; set; }

        [LocalizedDisplayName(nameof(Resources.LookupPhoneNumber_PhoneNumber_DisplayName))]
        [LocalizedDescription(nameof(Resources.LookupPhoneNumber_PhoneNumber_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<object> PhoneNumber { get; set; }

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
            if (Number == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(Number)));
            if (IncludeCallerName == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(IncludeCallerName)));
            if (IncludeCarrier == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(IncludeCarrier)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var number = Number.Get(context);
            var countrycode = CountryCode.Get(context);
            var includecallername = IncludeCallerName.Get(context);
            var includecarrier = IncludeCarrier.Get(context);
            var addons = AddOns.Get(context);
            var addonsdata = AddOnsData.Get(context);
    
            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////

            // Outputs
            return (ctx) => {
                PhoneNumber.Set(ctx, null);
            };
        }

        #endregion
    }
}

