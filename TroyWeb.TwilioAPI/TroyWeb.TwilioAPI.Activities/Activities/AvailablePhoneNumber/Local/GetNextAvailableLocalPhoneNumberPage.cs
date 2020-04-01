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
    [LocalizedDisplayName(nameof(Resources.GetNextAvailableLocalPhoneNumberPage_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetNextAvailableLocalPhoneNumberPage_Description))]
    public class GetNextAvailableLocalPhoneNumberPage : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetNextAvailableLocalPhoneNumberPage_Page_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetNextAvailableLocalPhoneNumberPage_Page_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Page { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetNextAvailableLocalPhoneNumberPage_AvailableLocalPhoneNumberPage_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetNextAvailableLocalPhoneNumberPage_AvailableLocalPhoneNumberPage_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<object> AvailableLocalPhoneNumberPage { get; set; }

        #endregion


        #region Constructors

        public GetNextAvailableLocalPhoneNumberPage()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetNextAvailableLocalPhoneNumberPage, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (Page == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(Page)));
            if (AvailableLocalPhoneNumberPage == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(AvailableLocalPhoneNumberPage)));
            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var page = Page.Get(context);
    
            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////

            // Outputs
            return (ctx) => {
                AvailableLocalPhoneNumberPage.Set(ctx, null);
            };
        }

        #endregion
    }
}

