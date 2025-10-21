using Umbraco.Cms.Core.PropertyEditors;

namespace MembersTestUmbraco16.Business.Editors
{
    [DataEditor(
        alias: "My.PropertyEditorUi.KeyValueTags",
        ValueType = ValueTypes.Json,
        ValueEditorIsReusable = true
    )]
    public class KeyValueTagsDataEditor : DataEditor
    {
        public KeyValueTagsDataEditor(IDataValueEditorFactory dataValueEditorFactory) : base(dataValueEditorFactory)
        {
        }
    }
}