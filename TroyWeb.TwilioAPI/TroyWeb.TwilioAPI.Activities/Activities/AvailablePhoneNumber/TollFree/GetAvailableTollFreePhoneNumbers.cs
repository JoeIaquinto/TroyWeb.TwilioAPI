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
    [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_Description))]
    public class GetAvailableTollFreePhoneNumbers : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_CountryCode_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_CountryCode_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> CountryCode { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_AccountSid_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_AccountSid_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> AccountSid { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_AreaCode_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_AreaCode_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> AreaCode { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_SmsEnabled_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_SmsEnabled_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> SmsEnabled { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_MmsEnabled_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_MmsEnabled_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> MmsEnabled { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_VoiceEnabled_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_VoiceEnabled_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> VoiceEnabled { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_FaxEnabled_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_FaxEnabled_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> FaxEnabled { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_Contains_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_Contains_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Contains { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_Beta_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_Beta_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Beta { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_NearNumber_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_NearNumber_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> NearNumber { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_NearLatLong_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_NearLatLong_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> NearLatLong { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_Distance_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_Distance_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Distance { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_InPostalCode_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_InPostalCode_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> InPostalCode { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_InRegion_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_InRegion_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> InRegion { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_InRateCenter_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_InRateCenter_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> InRateCenter { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_InLata_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_InLata_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> InLata { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_InLocality_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_InLocality_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> InLocality { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_ExcludeAllAddressRequired_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_ExcludeAllAddressRequired_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> ExcludeAllAddressRequired { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_ExcludeLocalAddressRequired_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_ExcludeLocalAddressRequired_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> ExcludeLocalAddressRequired { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_ExcludeForeignAddressRequired_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_ExcludeForeignAddressRequired_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> ExcludeForeignAddressRequired { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_Limit_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_Limit_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Limit { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableTollFreePhoneNumbers_PhoneNumbers_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableTollFreePhoneNumbers_PhoneNumbers_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<object> PhoneNumbers { get; set; }

        #endregion


        #region Constructors

        public GetAvailableTollFreePhoneNumbers()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetAvailableTollFreePhoneNumbers, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (CountryCode == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(CountryCode)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Object Container: Use objectContainer.Get<T>() to retrieve objects from the scope
            var objectContainer = context.GetFromContext<IObjectContainer>(TwilioApiScope.ParentContainerPropertyTag);

            // Inputs
            var countrycode = CountryCode.Get(context);
            var accountsid = AccountSid.Get(context);
            var areacode = AreaCode.Get(context);
            var smsenabled = SmsEnabled.Get(context);
            var mmsenabled = MmsEnabled.Get(context);
            var voiceenabled = VoiceEnabled.Get(context);
            var faxenabled = FaxEnabled.Get(context);
            var contains = Contains.Get(context);
            var beta = Beta.Get(context);
            var nearnumber = NearNumber.Get(context);
            var nearlatlong = NearLatLong.Get(context);
            var distance = Distance.Get(context);
            var inpostalcode = InPostalCode.Get(context);
            var inregion = InRegion.Get(context);
            var inratecenter = InRateCenter.Get(context);
            var inlata = InLata.Get(context);
            var inlocality = InLocality.Get(context);
            var excludealladdressrequired = ExcludeAllAddressRequired.Get(context);
            var excludelocaladdressrequired = ExcludeLocalAddressRequired.Get(context);
            var excludeforeignaddressrequired = ExcludeForeignAddressRequired.Get(context);
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

