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
    [LocalizedDisplayName(nameof(Resources.GetAlphaSender_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetAlphaSender_Description))]
    public class GetAlphaSender : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAlphaSender_ServiceSid_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAlphaSender_ServiceSid_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> ServiceSid { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAlphaSender_AlphaSenderSid_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAlphaSender_AlphaSenderSid_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> AlphaSenderSid { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAlphaSender_AlphaSender_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAlphaSender_AlphaSender_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<object> AlphaSender { get; set; }

        #endregion


        #region Constructors

        public GetAlphaSender()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetAlphaSender, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
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
            var servicesid = ServiceSid.Get(context);
            var alphasendersid = AlphaSenderSid.Get(context);
    
            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////

            // Outputs
            return (ctx) => {
                AlphaSender.Set(ctx, null);
            };
        }

        #endregion
    }
}

