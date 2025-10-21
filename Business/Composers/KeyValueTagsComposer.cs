using MembersTestUmbraco16.Business.Converters;

namespace MembersTestUmbraco16.Business.Composers
{
    public class KeyValueTagsComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.PropertyValueConverters().Append<KeyValueTagsValueConverter>();
        }
    }
}