using System;
using System.Activities;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using TroyWeb.TwilioAPI.Activities.Properties;
using TroyWeb.TwilioAPI.Wrappers.Fax;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Rest.Fax.V1;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using UiPath.Shared.Activities.Utilities;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetFaxes_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetFaxes_Description))]
    public class GetFaxes : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetFaxes_From_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetFaxes_From_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> From { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetFaxes_To_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetFaxes_To_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> To { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetFaxes_DateCreatedOnOrBefore_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetFaxes_DateCreatedOnOrBefore_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<DateTime?> DateCreatedOnOrBefore { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetFaxes_DateCreatedAfter_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetFaxes_DateCreatedAfter_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<DateTime?> DateCreatedAfter { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetFaxes_Limit_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetFaxes_Limit_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<long?> Limit { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetFaxes_Faxes_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetFaxes_Faxes_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<ResourceSet<FaxResource>> Faxes { get; set; }

        #endregion


        #region Constructors

        public GetFaxes()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetFaxes, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
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
            var from = From.Get(context);
            var to = To.Get(context);
            var datecreatedonorbefore = DateCreatedOnOrBefore.Get(context);
            var datecreatedafter = DateCreatedAfter.Get(context);
            var limit = Limit.Get(context);

            var faxes = await FaxWrappers.GetFaxesAsync(objectContainer.Get<ITwilioRestClient>(), from, to, datecreatedafter,
                datecreatedonorbefore, limit);

            // Outputs
            return (ctx) => {
                Faxes.Set(ctx, faxes);
            };
        }

        #endregion
    }
}

