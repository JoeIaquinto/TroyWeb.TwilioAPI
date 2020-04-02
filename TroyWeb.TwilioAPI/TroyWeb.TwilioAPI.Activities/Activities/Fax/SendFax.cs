using System;
using System.Activities;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using TroyWeb.TwilioAPI.Activities.Properties;
using TroyWeb.TwilioAPI.Enums;
using TroyWeb.TwilioAPI.Wrappers.Fax;
using Twilio.Clients;
using Twilio.Rest.Fax.V1;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using UiPath.Shared.Activities.Utilities;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.SendFax_DisplayName))]
    [LocalizedDescription(nameof(Resources.SendFax_Description))]
    public class SendFax : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendFax_To_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendFax_To_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> To { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendFax_MediaUrl_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendFax_MediaUrl_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> MediaUrl { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendFax_From_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendFax_From_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> From { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendFax_Quality_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendFax_Quality_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        [TypeConverter(typeof(FaxQuality))]
        public InArgument<FaxQuality?> Quality { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendFax_StoreMedia_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendFax_StoreMedia_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<bool?> StoreMedia { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendFax_MinutesToSend_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendFax_MinutesToSend_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<int?> MinutesToSend { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendFax_SipAuthUsername_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendFax_SipAuthUsername_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> SipAuthUsername { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendFax_SipAuthPassword_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendFax_SipAuthPassword_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> SipAuthPassword { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendFax_StatusCallback_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendFax_StatusCallback_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> StatusCallback { get; set; }

        [LocalizedDisplayName(nameof(Resources.SendFax_Fax_DisplayName))]
        [LocalizedDescription(nameof(Resources.SendFax_Fax_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<FaxResource> Fax { get; set; }

        #endregion


        #region Constructors

        public SendFax()
        {
            Constraints.Add(ActivityConstraints.HasParentType<SendFax, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (To == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(To)));
            if (MediaUrl == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(MediaUrl)));
            if (From == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(From)));
            if (Quality == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(Quality)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var to = To.Get(context);
            var mediaurl = MediaUrl.Get(context);
            var from = From.Get(context);
            var quality = Quality.Get(context);
            var storemedia = StoreMedia.Get(context);
            var minutestosend = MinutesToSend.Get(context);
            var sipauthusername = SipAuthUsername.Get(context);
            var sipauthpassword = SipAuthPassword.Get(context);
            var statuscallback = StatusCallback.Get(context);
            var twilioQuality = quality == FaxQuality.Fine ? FaxResource.QualityEnum.Fine :
                quality == FaxQuality.SuperFine ? FaxResource.QualityEnum.Superfine :
                FaxResource.QualityEnum.Standard;
            
            var sent = await FaxWrappers.SendFaxAsync(objectContainer.Get<ITwilioRestClient>(), from, to, new Uri(mediaurl),
                twilioQuality, sipauthusername, sipauthpassword, new Uri(statuscallback), storemedia, minutestosend);

            // Outputs
            return (ctx) => {
                Fax.Set(ctx, sent);
            };
        }

        #endregion
    }
}

