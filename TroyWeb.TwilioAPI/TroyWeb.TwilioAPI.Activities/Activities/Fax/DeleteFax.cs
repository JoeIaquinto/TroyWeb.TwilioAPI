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
    [LocalizedDisplayName(nameof(Resources.DeleteFax_DisplayName))]
    [LocalizedDescription(nameof(Resources.DeleteFax_Description))]
    public class DeleteFax : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.DeleteFax_FaxSid_DisplayName))]
        [LocalizedDescription(nameof(Resources.DeleteFax_FaxSid_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> FaxSid { get; set; }

        [LocalizedDisplayName(nameof(Resources.DeleteFax_Success_DisplayName))]
        [LocalizedDescription(nameof(Resources.DeleteFax_Success_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<object> Success { get; set; }

        #endregion


        #region Constructors

        public DeleteFax()
        {
            Constraints.Add(ActivityConstraints.HasParentType<DeleteFax, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (FaxSid == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(FaxSid)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var faxsid = FaxSid.Get(context);
    
            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////

            // Outputs
            return (ctx) => {
                Success.Set(ctx, null);
            };
        }

        #endregion
    }
}

