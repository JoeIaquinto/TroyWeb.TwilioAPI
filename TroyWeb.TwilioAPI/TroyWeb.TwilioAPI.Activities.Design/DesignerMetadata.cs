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

            builder.AddCustomAttributes(typeof(GetFax), faxcategoryAttribute);
            builder.AddCustomAttributes(typeof(GetFax), new DesignerAttribute(typeof(GetFaxDesigner)));
            builder.AddCustomAttributes(typeof(GetFax), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(GetFaxMedias), faxcmediaategoryAttribute);
            builder.AddCustomAttributes(typeof(GetFaxMedias), new DesignerAttribute(typeof(GetFaxMediaDesigner)));
            builder.AddCustomAttributes(typeof(GetFaxMedias), new HelpKeywordAttribute(""));

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

            builder.AddCustomAttributes(typeof(GetFaxMedias), faxcmediaategoryAttribute);
            builder.AddCustomAttributes(typeof(GetFaxMedias), new DesignerAttribute(typeof(GetFaxMediasDesigner)));
            builder.AddCustomAttributes(typeof(GetFaxMedias), new HelpKeywordAttribute(""));

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

            builder.AddCustomAttributes(typeof(DownloadFaxMedia), faxcmediaategoryAttribute);
            builder.AddCustomAttributes(typeof(DownloadFaxMedia), new DesignerAttribute(typeof(DownloadFaxMediaDesigner)));
            builder.AddCustomAttributes(typeof(DownloadFaxMedia), new HelpKeywordAttribute(""));

            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
