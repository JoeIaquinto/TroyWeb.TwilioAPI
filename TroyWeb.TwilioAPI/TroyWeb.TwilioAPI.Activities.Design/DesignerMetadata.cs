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

            #endregion Setup



            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
