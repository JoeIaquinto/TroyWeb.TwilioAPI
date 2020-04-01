using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using TroyWeb.TwilioAPI.Activities.Design.Designers;
using TroyWeb.TwilioAPI.Activities.Design.Properties;

namespace TroyWeb.TwilioAPI.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            #region Setup

            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var categoryAttribute = new CategoryAttribute($"{Resources.Category}");
            var faxcategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.FaxCategory}");
            var faxcmediaategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.FaxCategory}.{Resources.MediaCategory}");
            var localphonecategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.PhoneCategory}.{Resources.LocalPhoneCategory}");
            var mobilephonecategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.PhoneCategory}.{Resources.MobilePhoneCategory}");
            var tollFreephonecategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.PhoneCategory}.{Resources.TollFreePhoneCategory}");
            var phonecategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.PhoneCategory}");
            var pricingcategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.PricingCategory}");
            var VoicepricingcategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.PricingCategory}.{Resources.VoiceCategory}");
            var MessagingpricingcategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.PricingCategory}.{Resources.MessagingCategory}");
            var PhoneNumberpricingcategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.PricingCategory}.{Resources.PhoneCategory}");
            var SMScategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.SMSCategory}");
            var SMSmediacategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.SMSCategory}.{Resources.MediaCategory}");
            var AlphaSendercategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.SMSCategory}.{Resources.AlphaSenderCategory}");
            var ShortCodecategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.SMSCategory}.{Resources.ShortCodeCategory}");
            var accountcategoryAttribute = new CategoryAttribute($"{Resources.Category}.{Resources.AccountCategory}");

            #endregion Setup


            builder.AddCustomAttributes(typeof(TwilioApiScope), categoryAttribute);
            builder.AddCustomAttributes(typeof(TwilioApiScope), new DesignerAttribute(typeof(TwilioApiScopeDesigner)));
            builder.AddCustomAttributes(typeof(TwilioApiScope), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(CreateAccount), accountcategoryAttribute);
            builder.AddCustomAttributes(typeof(CreateAccount), new DesignerAttribute(typeof(CreateAccountDesigner)));
            builder.AddCustomAttributes(typeof(CreateAccount), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(UpdateAccount), accountcategoryAttribute);
            builder.AddCustomAttributes(typeof(UpdateAccount), new DesignerAttribute(typeof(UpdateAccountDesigner)));
            builder.AddCustomAttributes(typeof(UpdateAccount), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAccounts), accountcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAccounts), new DesignerAttribute(typeof(GetAccountsDesigner)));
            builder.AddCustomAttributes(typeof(GetAccounts), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAccount), accountcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAccount), new DesignerAttribute(typeof(GetAccountDesigner)));
            builder.AddCustomAttributes(typeof(GetAccount), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAccountPage), accountcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAccountPage), new DesignerAttribute(typeof(GetAccountPageDesigner)));
            builder.AddCustomAttributes(typeof(GetAccountPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetNextAccountPage), accountcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetNextAccountPage), new DesignerAttribute(typeof(GetNextAccountPageDesigner)));
            builder.AddCustomAttributes(typeof(GetNextAccountPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPreviousAccountPage), accountcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPreviousAccountPage), new DesignerAttribute(typeof(GetPreviousAccountPageDesigner)));
            builder.AddCustomAttributes(typeof(GetPreviousAccountPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetMessagePage), SMScategoryAttribute);
            builder.AddCustomAttributes(typeof(GetMessagePage), new DesignerAttribute(typeof(GetMessagePageDesigner)));
            builder.AddCustomAttributes(typeof(GetMessagePage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetNextMessagePage), SMScategoryAttribute);
            builder.AddCustomAttributes(typeof(GetNextMessagePage), new DesignerAttribute(typeof(GetNextMessagePageDesigner)));
            builder.AddCustomAttributes(typeof(GetNextMessagePage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPreviousMessagePage), SMScategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPreviousMessagePage), new DesignerAttribute(typeof(GetPreviousMessagePageDesigner)));
            builder.AddCustomAttributes(typeof(GetPreviousMessagePage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetMessageMediaPage), SMSmediacategoryAttribute);
            builder.AddCustomAttributes(typeof(GetMessageMediaPage), new DesignerAttribute(typeof(GetMessageMediaPageDesigner)));
            builder.AddCustomAttributes(typeof(GetMessageMediaPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetNextMessageMediaPage), SMSmediacategoryAttribute);
            builder.AddCustomAttributes(typeof(GetNextMessageMediaPage), new DesignerAttribute(typeof(GetNextMessageMediaPageDesigner)));
            builder.AddCustomAttributes(typeof(GetNextMessageMediaPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPreviousMessageMediaPage), SMSmediacategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPreviousMessageMediaPage), new DesignerAttribute(typeof(GetPreviousMessageMediaPageDesigner)));
            builder.AddCustomAttributes(typeof(GetPreviousMessageMediaPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAlphaSenderPage), AlphaSendercategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAlphaSenderPage), new DesignerAttribute(typeof(GetAlphaSenderPageDesigner)));
            builder.AddCustomAttributes(typeof(GetAlphaSenderPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetNextAlphaSenderPage), AlphaSendercategoryAttribute);
            builder.AddCustomAttributes(typeof(GetNextAlphaSenderPage), new DesignerAttribute(typeof(GetNextAlphaSenderPageDesigner)));
            builder.AddCustomAttributes(typeof(GetNextAlphaSenderPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPreviousAlphaSenderPage), AlphaSendercategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPreviousAlphaSenderPage), new DesignerAttribute(typeof(GetPreviousAlphaSenderPageDesigner)));
            builder.AddCustomAttributes(typeof(GetPreviousAlphaSenderPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetShortCodePage), ShortCodecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetShortCodePage), new DesignerAttribute(typeof(GetShortCodePageDesigner)));
            builder.AddCustomAttributes(typeof(GetShortCodePage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetNextShortCodePage), ShortCodecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetNextShortCodePage), new DesignerAttribute(typeof(GetNextShortCodePageDesigner)));
            builder.AddCustomAttributes(typeof(GetNextShortCodePage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPreviousShortCodePage), ShortCodecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPreviousShortCodePage), new DesignerAttribute(typeof(GetPreviousShortCodePageDesigner)));
            builder.AddCustomAttributes(typeof(GetPreviousShortCodePage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetVoicePricingPage), VoicepricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetVoicePricingPage), new DesignerAttribute(typeof(GetVoicePricingPageDesigner)));
            builder.AddCustomAttributes(typeof(GetVoicePricingPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetNextVoicePricingPage), VoicepricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetNextVoicePricingPage), new DesignerAttribute(typeof(GetNextVoicePricingPageDesigner)));
            builder.AddCustomAttributes(typeof(GetNextVoicePricingPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPreviousVoicePricingPage), VoicepricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPreviousVoicePricingPage), new DesignerAttribute(typeof(GetPreviousVoicePricingPageDesigner)));
            builder.AddCustomAttributes(typeof(GetPreviousVoicePricingPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPhoneNumberPricingPage), PhoneNumberpricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPhoneNumberPricingPage), new DesignerAttribute(typeof(GetPhoneNumberPricingPageDesigner)));
            builder.AddCustomAttributes(typeof(GetPhoneNumberPricingPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetNextPhoneNumberPricingPage), PhoneNumberpricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetNextPhoneNumberPricingPage), new DesignerAttribute(typeof(GetNextPhoneNumberPricingPageDesigner)));
            builder.AddCustomAttributes(typeof(GetNextPhoneNumberPricingPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPreviousPhoneNumberPricingPage), PhoneNumberpricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPreviousPhoneNumberPricingPage), new DesignerAttribute(typeof(GetPreviousPhoneNumberPricingPageDesigner)));
            builder.AddCustomAttributes(typeof(GetPreviousPhoneNumberPricingPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetMessagingPricingPage), MessagingpricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetMessagingPricingPage), new DesignerAttribute(typeof(GetMessagingPricingPageDesigner)));
            builder.AddCustomAttributes(typeof(GetMessagingPricingPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetNextMessagingPricingPage), MessagingpricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetNextMessagingPricingPage), new DesignerAttribute(typeof(GetNextMessagingPricingPageDesigner)));
            builder.AddCustomAttributes(typeof(GetNextMessagingPricingPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPreviousMessagingPricingPage), MessagingpricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPreviousMessagingPricingPage), new DesignerAttribute(typeof(GetPreviousMessagingPricingPageDesigner)));
            builder.AddCustomAttributes(typeof(GetPreviousMessagingPricingPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAvailableTollFreePhoneNumberPage), tollFreephonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAvailableTollFreePhoneNumberPage), new DesignerAttribute(typeof(GetAvailableTollFreePhoneNumberPageDesigner)));
            builder.AddCustomAttributes(typeof(GetAvailableTollFreePhoneNumberPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetNextAvailableTollFreePhoneNumberPage), tollFreephonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetNextAvailableTollFreePhoneNumberPage), new DesignerAttribute(typeof(GetNextAvailableTollFreePhoneNumberPageDesigner)));
            builder.AddCustomAttributes(typeof(GetNextAvailableTollFreePhoneNumberPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPreviousAvailableTollFreePhoneNumberPage), tollFreephonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPreviousAvailableTollFreePhoneNumberPage), new DesignerAttribute(typeof(GetPreviousAvailableTollFreePhoneNumberPageDesigner)));
            builder.AddCustomAttributes(typeof(GetPreviousAvailableTollFreePhoneNumberPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAvailablePhoneNumberPage), phonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAvailablePhoneNumberPage), new DesignerAttribute(typeof(GetAvailablePhoneNumberPageDesigner)));
            builder.AddCustomAttributes(typeof(GetAvailablePhoneNumberPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetNextAvailablePhoneNumberPage), phonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetNextAvailablePhoneNumberPage), new DesignerAttribute(typeof(GetNextAvailablePhoneNumberPageDesigner)));
            builder.AddCustomAttributes(typeof(GetNextAvailablePhoneNumberPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPreviousAvailablePhoneNumberPage), phonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPreviousAvailablePhoneNumberPage), new DesignerAttribute(typeof(GetPreviousAvailablePhoneNumberPageDesigner)));
            builder.AddCustomAttributes(typeof(GetPreviousAvailablePhoneNumberPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAvailableMobilePhoneNumberPage), mobilephonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAvailableMobilePhoneNumberPage), new DesignerAttribute(typeof(GetAvailableMobilePhoneNumberPageDesigner)));
            builder.AddCustomAttributes(typeof(GetAvailableMobilePhoneNumberPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetNextAvailableMobilePhoneNumberPage), mobilephonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetNextAvailableMobilePhoneNumberPage), new DesignerAttribute(typeof(GetNextAvailableMobilePhoneNumberPageDesigner)));
            builder.AddCustomAttributes(typeof(GetNextAvailableMobilePhoneNumberPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPreviousAvailableMobilePhoneNumberPage), mobilephonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPreviousAvailableMobilePhoneNumberPage), new DesignerAttribute(typeof(GetPreviousAvailableMobilePhoneNumberPageDesigner)));
            builder.AddCustomAttributes(typeof(GetPreviousAvailableMobilePhoneNumberPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAvailableLocalPhoneNumberPage), localphonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAvailableLocalPhoneNumberPage), new DesignerAttribute(typeof(GetAvailableLocalPhoneNumberPageDesigner)));
            builder.AddCustomAttributes(typeof(GetAvailableLocalPhoneNumberPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetNextAvailableLocalPhoneNumberPage), localphonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetNextAvailableLocalPhoneNumberPage), new DesignerAttribute(typeof(GetNextAvailableLocalPhoneNumberPageDesigner)));
            builder.AddCustomAttributes(typeof(GetNextAvailableLocalPhoneNumberPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPreviousAvailableLocalPhoneNumberPage), localphonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPreviousAvailableLocalPhoneNumberPage), new DesignerAttribute(typeof(GetPreviousAvailableLocalPhoneNumberPageDesigner)));
            builder.AddCustomAttributes(typeof(GetPreviousAvailableLocalPhoneNumberPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetFaxPage), faxcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetFaxPage), new DesignerAttribute(typeof(GetFaxPageDesigner)));
            builder.AddCustomAttributes(typeof(GetFaxPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetNextFaxPage), faxcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetNextFaxPage), new DesignerAttribute(typeof(GetNextFaxPageDesigner)));
            builder.AddCustomAttributes(typeof(GetNextFaxPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPreviousFaxPage), faxcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPreviousFaxPage), new DesignerAttribute(typeof(GetPreviousFaxPageDesigner)));
            builder.AddCustomAttributes(typeof(GetPreviousFaxPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetFaxMediaPage), faxcmediaategoryAttribute);
            builder.AddCustomAttributes(typeof(GetFaxMediaPage), new DesignerAttribute(typeof(GetFaxMediaPageDesigner)));
            builder.AddCustomAttributes(typeof(GetFaxMediaPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetNextFaxMediaPage), faxcmediaategoryAttribute);
            builder.AddCustomAttributes(typeof(GetNextFaxMediaPage), new DesignerAttribute(typeof(GetNextFaxMediaPageDesigner)));
            builder.AddCustomAttributes(typeof(GetNextFaxMediaPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPreviousFaxMediaPage), faxcmediaategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPreviousFaxMediaPage), new DesignerAttribute(typeof(GetPreviousFaxMediaPageDesigner)));
            builder.AddCustomAttributes(typeof(GetPreviousFaxMediaPage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetFax), faxcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetFax), new DesignerAttribute(typeof(GetFaxDesigner)));
            builder.AddCustomAttributes(typeof(GetFax), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetFaxMedia), faxcmediaategoryAttribute);
            builder.AddCustomAttributes(typeof(GetFaxMedia), new DesignerAttribute(typeof(GetFaxMediaDesigner)));
            builder.AddCustomAttributes(typeof(GetFaxMedia), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetMessage), SMScategoryAttribute);
            builder.AddCustomAttributes(typeof(GetMessage), new DesignerAttribute(typeof(GetMessageDesigner)));
            builder.AddCustomAttributes(typeof(GetMessage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetMessageMedia), SMSmediacategoryAttribute);
            builder.AddCustomAttributes(typeof(GetMessageMedia), new DesignerAttribute(typeof(GetMessageMediaDesigner)));
            builder.AddCustomAttributes(typeof(GetMessageMedia), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAlphaSender), AlphaSendercategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAlphaSender), new DesignerAttribute(typeof(GetAlphaSenderDesigner)));
            builder.AddCustomAttributes(typeof(GetAlphaSender), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetShortCode), ShortCodecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetShortCode), new DesignerAttribute(typeof(GetShortCodeDesigner)));
            builder.AddCustomAttributes(typeof(GetShortCode), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAccount), accountcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAccount), new DesignerAttribute(typeof(GetAccountDesigner)));
            builder.AddCustomAttributes(typeof(GetAccount), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetVoicePricing), VoicepricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetVoicePricing), new DesignerAttribute(typeof(GetVoicePricingDesigner)));
            builder.AddCustomAttributes(typeof(GetVoicePricing), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetMessagingPricing), MessagingpricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetMessagingPricing), new DesignerAttribute(typeof(GetMessagingPricingDesigner)));
            builder.AddCustomAttributes(typeof(GetMessagingPricing), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPhoneNumberPricing), PhoneNumberpricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPhoneNumberPricing), new DesignerAttribute(typeof(GetPhoneNumberPricingDesigner)));
            builder.AddCustomAttributes(typeof(GetPhoneNumberPricing), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetPhoneNumberPricings), PhoneNumberpricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetPhoneNumberPricings), new DesignerAttribute(typeof(GetPhoneNumberPricingsDesigner)));
            builder.AddCustomAttributes(typeof(GetPhoneNumberPricings), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetMessagingPricings), MessagingpricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetMessagingPricings), new DesignerAttribute(typeof(GetMessagingPricingsDesigner)));
            builder.AddCustomAttributes(typeof(GetMessagingPricings), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetVoicePricings), VoicepricingcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetVoicePricings), new DesignerAttribute(typeof(GetVoicePricingsDesigner)));
            builder.AddCustomAttributes(typeof(GetVoicePricings), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAvailablePhoneNumbers), phonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAvailablePhoneNumbers), new DesignerAttribute(typeof(GetAvailablePhoneNumbersDesigner)));
            builder.AddCustomAttributes(typeof(GetAvailablePhoneNumbers), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAvailablePhoneNumbersForAccount), phonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAvailablePhoneNumbersForAccount), new DesignerAttribute(typeof(GetAvailablePhoneNumbersForAccountDesigner)));
            builder.AddCustomAttributes(typeof(GetAvailablePhoneNumbersForAccount), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAvailableLocalPhoneNumbers), localphonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAvailableLocalPhoneNumbers), new DesignerAttribute(typeof(GetAvailableLocalPhoneNumbersDesigner)));
            builder.AddCustomAttributes(typeof(GetAvailableLocalPhoneNumbers), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAvailableMobilePhoneNumbers), mobilephonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAvailableMobilePhoneNumbers), new DesignerAttribute(typeof(GetAvailableMobilePhoneNumbersDesigner)));
            builder.AddCustomAttributes(typeof(GetAvailableMobilePhoneNumbers), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetAvailableTollFreePhoneNumbers), tollFreephonecategoryAttribute);
            builder.AddCustomAttributes(typeof(GetAvailableTollFreePhoneNumbers), new DesignerAttribute(typeof(GetAvailableTollFreePhoneNumbersDesigner)));
            builder.AddCustomAttributes(typeof(GetAvailableTollFreePhoneNumbers), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(LookupPhoneNumber), phonecategoryAttribute);
            builder.AddCustomAttributes(typeof(LookupPhoneNumber), new DesignerAttribute(typeof(LookupPhoneNumberDesigner)));
            builder.AddCustomAttributes(typeof(LookupPhoneNumber), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(SendFax), faxcategoryAttribute);
            builder.AddCustomAttributes(typeof(SendFax), new DesignerAttribute(typeof(SendFaxDesigner)));
            builder.AddCustomAttributes(typeof(SendFax), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(CancelFax), faxcategoryAttribute);
            builder.AddCustomAttributes(typeof(CancelFax), new DesignerAttribute(typeof(CancelFaxDesigner)));
            builder.AddCustomAttributes(typeof(CancelFax), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(DeleteFax), faxcategoryAttribute);
            builder.AddCustomAttributes(typeof(DeleteFax), new DesignerAttribute(typeof(DeleteFaxDesigner)));
            builder.AddCustomAttributes(typeof(DeleteFax), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetFaxMedia), faxcmediaategoryAttribute);
            builder.AddCustomAttributes(typeof(GetFaxMedia), new DesignerAttribute(typeof(GetFaxMediaDesigner)));
            builder.AddCustomAttributes(typeof(GetFaxMedia), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetFaxMedia), faxcmediaategoryAttribute);
            builder.AddCustomAttributes(typeof(GetFaxMedia), new DesignerAttribute(typeof(GetFaxMediaDesigner)));
            builder.AddCustomAttributes(typeof(GetFaxMedia), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(DeleteFaxMedia), faxcmediaategoryAttribute);
            builder.AddCustomAttributes(typeof(DeleteFaxMedia), new DesignerAttribute(typeof(DeleteFaxMediaDesigner)));
            builder.AddCustomAttributes(typeof(DeleteFaxMedia), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetFax), faxcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetFax), new DesignerAttribute(typeof(GetFaxDesigner)));
            builder.AddCustomAttributes(typeof(GetFax), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetFaxes), faxcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetFaxes), new DesignerAttribute(typeof(GetFaxesDesigner)));
            builder.AddCustomAttributes(typeof(GetFaxes), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(SendMessage), SMScategoryAttribute);
            builder.AddCustomAttributes(typeof(SendMessage), new DesignerAttribute(typeof(SendMessageDesigner)));
            builder.AddCustomAttributes(typeof(SendMessage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(CancelMessage), SMScategoryAttribute);
            builder.AddCustomAttributes(typeof(CancelMessage), new DesignerAttribute(typeof(CancelMessageDesigner)));
            builder.AddCustomAttributes(typeof(CancelMessage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(UpdateMessage), SMScategoryAttribute);
            builder.AddCustomAttributes(typeof(UpdateMessage), new DesignerAttribute(typeof(UpdateMessageDesigner)));
            builder.AddCustomAttributes(typeof(UpdateMessage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(DeleteMessage), SMScategoryAttribute);
            builder.AddCustomAttributes(typeof(DeleteMessage), new DesignerAttribute(typeof(DeleteMessageDesigner)));
            builder.AddCustomAttributes(typeof(DeleteMessage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetMessage), SMScategoryAttribute);
            builder.AddCustomAttributes(typeof(GetMessage), new DesignerAttribute(typeof(GetMessageDesigner)));
            builder.AddCustomAttributes(typeof(GetMessage), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetMessages), SMScategoryAttribute);
            builder.AddCustomAttributes(typeof(GetMessages), new DesignerAttribute(typeof(GetMessagesDesigner)));
            builder.AddCustomAttributes(typeof(GetMessages), new HelpKeywordAttribute(""));


            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
