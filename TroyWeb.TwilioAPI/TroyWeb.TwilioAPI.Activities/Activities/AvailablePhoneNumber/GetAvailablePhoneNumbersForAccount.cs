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
    [LocalizedDisplayName(nameof(Resources.GetAvailablePhoneNumbersForAccount_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetAvailablePhoneNumbersForAccount_Description))]
    public class GetAvailablePhoneNumbersForAccount : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailablePhoneNumbersForAccount_AccountSid_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailablePhoneNumbersForAccount_AccountSid_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> AccountSid { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailablePhoneNumbersForAccount_Limit_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailablePhoneNumbersForAccount_Limit_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Limit { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailablePhoneNumbersForAccount_PhoneNumbers_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailablePhoneNumbersForAccount_PhoneNumbers_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<object> PhoneNumbers { get; set; }

        #endregion


        #region Constructors

        public GetAvailablePhoneNumbersForAccount()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetAvailablePhoneNumbersForAccount, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (AccountSid == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(AccountSid)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var accountsid = AccountSid.Get(context);
            var limit = Limit.Get(context);
    
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

