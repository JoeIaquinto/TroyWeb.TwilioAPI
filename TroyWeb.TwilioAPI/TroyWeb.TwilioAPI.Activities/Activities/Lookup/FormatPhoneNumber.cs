using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using PhoneNumbers;
using TroyWeb.TwilioAPI.Activities.Properties;
using TroyWeb.TwilioAPI.Enums;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.FormatPhoneNumber_DisplayName))]
    [LocalizedDescription(nameof(Resources.FormatPhoneNumber_Description))]
    public class FormatPhoneNumber : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.FormatPhoneNumber_PhoneNumber_DisplayName))]
        [LocalizedDescription(nameof(Resources.FormatPhoneNumber_PhoneNumber_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> PhoneNumber { get; set; }

        [LocalizedDisplayName(nameof(Resources.FormatPhoneNumber_CountryCode_DisplayName))]
        [LocalizedDescription(nameof(Resources.FormatPhoneNumber_CountryCode_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<CountryCode?> CountryCode { get; set; }

        [LocalizedDisplayName(nameof(Resources.FormatPhoneNumber_IsValidNumber_DisplayName))]
        [LocalizedDescription(nameof(Resources.FormatPhoneNumber_IsValidNumber_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<bool> IsValidNumber { get; set; }

        [LocalizedDisplayName(nameof(Resources.FormatPhoneNumber_FormattedNumber_DisplayName))]
        [LocalizedDescription(nameof(Resources.FormatPhoneNumber_FormattedNumber_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<string> FormattedNumber { get; set; }

        #endregion


        #region Constructors

        public FormatPhoneNumber()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (PhoneNumber == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(PhoneNumber)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var phonenumber = PhoneNumber.Get(context);
            var countrycode = CountryCode.Get(context);
            var valid = false;
            string e164 = null;
            var util = PhoneNumberUtil.GetInstance();
            try
            {
                var number = util.Parse(phonenumber, countrycode == null ? null : $"{countrycode:G}");
                valid = util.IsValidNumber(number);
                e164 = util.Format(number, PhoneNumberFormat.E164);
            }
            catch (NumberParseException)
            {
                valid = false;
            }
            // Outputs
            return (ctx) => {
                IsValidNumber.Set(ctx, valid);
                FormattedNumber.Set(ctx, e164);
            };
        }

        #endregion
    }
}

