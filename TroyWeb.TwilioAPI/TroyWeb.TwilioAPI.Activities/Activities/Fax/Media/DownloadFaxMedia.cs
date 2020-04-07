using System;
using System.Activities;
using System.IO;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using TroyWeb.TwilioAPI.Activities.Properties;
using TroyWeb.TwilioAPI.Wrappers.Fax;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Rest.Fax.V1;
using Twilio.Rest.Fax.V1.Fax;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using UiPath.Shared.Activities.Utilities;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.DownloadFaxMedia_DisplayName))]
    [LocalizedDescription(nameof(Resources.DownloadFaxMedia_Description))]
    public class DownloadFaxMedia : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.DownloadFaxMedia_Fax_DisplayName))]
        [LocalizedDescription(nameof(Resources.DownloadFaxMedia_Fax_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<FaxResource> Fax { get; set; }

        [LocalizedDisplayName(nameof(Resources.DownloadFaxMedia_Path_DisplayName))]
        [LocalizedDescription(nameof(Resources.DownloadFaxMedia_Path_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Path { get; set; }

        [LocalizedDisplayName(nameof(Resources.DownloadFaxMedia_FaxMediaPDF_DisplayName))]
        [LocalizedDescription(nameof(Resources.DownloadFaxMedia_FaxMediaPDF_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<FileInfo> FaxMediaPDF { get; set; }

        #endregion


        #region Constructors

        public DownloadFaxMedia()
        {
            Constraints.Add(ActivityConstraints.HasParentType<DownloadFaxMedia, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            metadata.AddRequiredArgument(Fax, nameof(Fax));
            metadata.AddRequiredArgument(Path, nameof(Path));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var fax = Fax.Get(context);
            var path = Path.Get(context);

            var media = await FaxWrappers.DownloadFaxMediaAsync(objectContainer.Get<ITwilioRestClient>(), fax, path);

            // Outputs
            return (ctx) => {
                FaxMediaPDF.Set(ctx, media);
            };
        }

        #endregion
    }
}

