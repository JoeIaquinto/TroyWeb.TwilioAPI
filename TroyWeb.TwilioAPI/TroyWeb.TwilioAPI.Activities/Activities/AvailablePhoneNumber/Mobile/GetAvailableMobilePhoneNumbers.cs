using System;
using System.Activities;
using System.ComponentModel;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using TroyWeb.TwilioAPI.Activities.Properties;
using TroyWeb.TwilioAPI.Enums;
using TroyWeb.TwilioAPI.Wrappers.PhoneNumbers;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using UiPath.Shared.Activities.Utilities;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_DisplayName))]
    [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_Description))]
    public class GetAvailableMobilePhoneNumbers : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_CountryCode_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_CountryCode_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        [TypeConverter(typeof(EnumNameConverter<CountryCode>))]
        public CountryCode CountryCode { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_AccountSid_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_AccountSid_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> AccountSid { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_AreaCode_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_AreaCode_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<int?> AreaCode { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_SmsEnabled_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_SmsEnabled_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<bool?> SmsEnabled { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_MmsEnabled_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_MmsEnabled_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<bool?> MmsEnabled { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_VoiceEnabled_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_VoiceEnabled_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<bool?> VoiceEnabled { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_FaxEnabled_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_FaxEnabled_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<bool?> FaxEnabled { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_Contains_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_Contains_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Contains { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_Beta_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_Beta_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<bool?> Beta { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_NearNumber_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_NearNumber_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> NearNumber { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_NearLatLong_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_NearLatLong_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> NearLatLong { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_Distance_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_Distance_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<int?> Distance { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_InPostalCode_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_InPostalCode_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> InPostalCode { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_InRegion_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_InRegion_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> InRegion { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_InRateCenter_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_InRateCenter_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> InRateCenter { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_InLata_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_InLata_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> InLata { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_InLocality_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_InLocality_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> InLocality { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_ExcludeAllAddressRequired_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_ExcludeAllAddressRequired_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<bool?> ExcludeAllAddressRequired { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_ExcludeLocalAddressRequired_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_ExcludeLocalAddressRequired_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<bool?> ExcludeLocalAddressRequired { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_ExcludeForeignAddressRequired_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_ExcludeForeignAddressRequired_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<bool?> ExcludeForeignAddressRequired { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_Limit_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_Limit_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<long?> Limit { get; set; }

        [LocalizedDisplayName(nameof(Resources.GetAvailableMobilePhoneNumbers_PhoneNumbers_DisplayName))]
        [LocalizedDescription(nameof(Resources.GetAvailableMobilePhoneNumbers_PhoneNumbers_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<ResourceSet<MobileResource>> PhoneNumbers { get; set; }

        #endregion


        #region Constructors

        public GetAvailableMobilePhoneNumbers()
        {
            Constraints.Add(ActivityConstraints.HasParentType<GetAvailableMobilePhoneNumbers, TwilioApiScope>(string.Format(Resources.ValidationScope_Error, Resources.TwilioApiScope_DisplayName)));
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
            var countrycode = CountryCode;
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
    
            var numbers = await AvailableMobilePhoneNumbersWrappers.GetAvailableMobilePhoneNumberAsync(
                objectContainer.Get<ITwilioRestClient>(), countrycode, accountsid, areacode, smsenabled, mmsenabled,
                faxenabled, voiceenabled, beta, contains, inlata, nearlatlong, nearnumber, distance, inlocality,
                inpostalcode, inratecenter, inregion, excludealladdressrequired, excludeforeignaddressrequired,
                excludelocaladdressrequired, limit);

            // Outputs
            return (ctx) => {
                PhoneNumbers.Set(ctx, numbers);
            };
        }

        #endregion
    }
}

