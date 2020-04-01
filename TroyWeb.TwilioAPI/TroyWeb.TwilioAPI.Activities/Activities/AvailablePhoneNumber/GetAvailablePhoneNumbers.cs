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
    [LocalizedDisplayName(nameof(Resources.GetAvailablePhoneNumbers_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetAvailablePhoneNumbers_Description))]
    public class GetAvailablePhoneNumbers : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailablePhoneNumbers_CountryCode_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailablePhoneNumbers_CountryCode_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> CountryCode { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailablePhoneNumbers_PhoneNumbers_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailablePhoneNumbers_PhoneNumbers_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<object> PhoneNumbers { get; set; }

        #endregion


        #region Constructors

        public GetAvailablePhoneNumbers()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetAvailablePhoneNumbers, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (CountryCode == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(CountryCode)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var countrycode = CountryCode.Get(context);
    
            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////

            // Outputs
            return (ctx) => {
                PhoneNumbers.Set(ctx, null);
            };
        }

        #endregion
    }
}

