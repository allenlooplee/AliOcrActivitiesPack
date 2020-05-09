using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using Ali.Ocr.Activities.Design.Designers;
using Ali.Ocr.Activities.Design.Properties;

namespace Ali.Ocr.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var categoryAttribute = new CategoryAttribute($"{Resources.Category}");

            builder.AddCustomAttributes(typeof(AliOcrClientActivity), categoryAttribute);
            builder.AddCustomAttributes(typeof(AliOcrClientActivity), new DesignerAttribute(typeof(AliOcrClientActivityDesigner)));
            builder.AddCustomAttributes(typeof(AliOcrClientActivity), new HelpKeywordAttribute(""));


            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
