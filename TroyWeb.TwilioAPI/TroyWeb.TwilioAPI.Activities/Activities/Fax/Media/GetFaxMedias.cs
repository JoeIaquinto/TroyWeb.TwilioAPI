using System;
using System.Activities;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using TroyWeb.TwilioAPI.Activities.Properties;
using TroyWeb.TwilioAPI.Wrappers.Fax;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Rest.Fax.V1.Fax;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using UiPath.Shared.Activities.Utilities;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetFaxMedia_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetFaxMedia_Description))]
    public class GetFaxMedias : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetFaxMedia_FaxSid_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetFaxMedia_FaxSid_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> FaxSid { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetFaxMedia_Limit_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetFaxMedia_Limit_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<long?> Limit { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetFaxMedia_FaxMedia_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetFaxMedia_FaxMedia_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<ResourceSet<FaxMediaResource>> FaxMedia { get; set; }

        #endregion


        #region Constructors

        public GetFaxMedias()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetFaxMedias, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
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
            var limit = Limit.Get(context);

            var media = await FaxMediaWrappers.GetFaxMediasAsync(objectContainer.Get<ITwilioRestClient>(), faxsid,
                limit);

            // Outputs
            return (ctx) => {
                FaxMedia.Set(ctx, media);
            };
        }

        #endregion
    }
}

