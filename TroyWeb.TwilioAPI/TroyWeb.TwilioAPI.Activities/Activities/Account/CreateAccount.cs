using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using TroyWeb.TwilioAPI.Activities.Properties;
using TroyWeb.TwilioAPI.Wrappers;
using Twilio.Clients;
using Twilio.Rest.Api.V2010;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using UiPath.Shared.Activities.Utilities;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.CreateAccount_DisplayName))]
    [LocalizedDescription(nameof(Resources.CreateAccount_Description))]
    public class CreateAccount : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.CreateAccount_FriendlyName_DisplayName))]
        [LocalizedDescription(nameof(Resources.CreateAccount_FriendlyName_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> FriendlyName { get; set; }

        [LocalizedDisplayName(nameof(Resources.CreateAccount_Account_DisplayName))]
        [LocalizedDescription(nameof(Resources.CreateAccount_Account_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<AccountResource> Account { get; set; }

        #endregion


        #region Constructors

        public CreateAccount()
        {
            Constraints.Add(ActivityConstraints.HasParentType<CreateAccount, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (FriendlyName == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(FriendlyName)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var friendlyname = FriendlyName.Get(context);

            var account =
                await AccountWrappers.CreateAccountAsync(objectContainer.Get<ITwilioRestClient>(), friendlyname);

            // Outputs
            return (ctx) => {
                Account.Set(ctx, account);
            };
        }

        #endregion
    }
}

