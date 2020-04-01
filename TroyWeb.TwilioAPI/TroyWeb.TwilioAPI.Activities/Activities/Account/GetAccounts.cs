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
    [LocalizedDisplayName(nameof(Resources.GetAccounts_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetAccounts_Description))]
    public class GetAccounts : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAccounts_FriendlyName_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAccounts_FriendlyName_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> FriendlyName { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAccounts_Status_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAccounts_Status_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Status { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAccounts_Limit_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAccounts_Limit_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Limit { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAccounts_Accounts_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAccounts_Accounts_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<object> Accounts { get; set; }

        #endregion


        #region Constructors

        public GetAccounts()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetAccounts, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
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
            var friendlyname = FriendlyName.Get(context);
            var status = Status.Get(context);
            var limit = Limit.Get(context);
    
            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////

            // Outputs
            return (ctx) => {
                Accounts.Set(ctx, null);
            };
        }

        #endregion
    }
}

