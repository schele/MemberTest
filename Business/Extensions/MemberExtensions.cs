using System.Text.Json;
using Umbraco.Cms.Core.Models;

namespace MembersTestUmbraco16.Business.Extensions
{
    public static class MemberExtensions
    {
        public static string? ImageUrl(this IMember member, string alias, Umbraco.Cms.Web.Common.UmbracoHelper umbraco)
        {
            if (member == null || umbraco == null) return null;

            var json = member.GetValue<string>(alias);

            if (string.IsNullOrWhiteSpace(json)) return null;

            try
            {
                var doc = JsonDocument.Parse(json);

                if (doc.RootElement.GetArrayLength() == 0) return null;

                var mediaKey = doc.RootElement[0].GetProperty("mediaKey").GetGuid();
                var mediaItem = umbraco.Media(mediaKey);

                return mediaItem?.Url();
            }
            catch
            {
                return null;
            }
        }
    }
}