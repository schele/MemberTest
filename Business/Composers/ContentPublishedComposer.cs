using MembersTestUmbraco16.Business.Handlers;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Notifications;

namespace MembersTestUmbraco16.Business.Composers
{
    public class ContentPublishedComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.AddNotificationHandler<ContentPublishedNotification, ContentPublishedNotificationHandler>();
        }
    }
}