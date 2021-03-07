using System.Collections.Generic;
using System.Linq;

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Routing;
using Umbraco.Extensions;

namespace DoStuff.Core
{
    /// <summary>
    ///  some constants, just so we only change things in one place. 
    /// </summary>
    /// <remarks>
    ///  you probibly would have a central constants class, with this
    ///  and other ones in so things are consistant across your whole 
    ///  app.
    /// </remarks>
    internal class CustomContentAppConstants
    {
        // plugin base, doing this means it works when umbraco isn't installed
        // in the root 
        private static string PluginBase = "/App_Plugins/DoStuff.ContentApp/";


        internal const string Alias = "customContentApp";
        internal const string Name = "CustomApp";
        internal const string Icon = "icon-cloud";
        internal static string AppView = PluginBase + "ContentApp.html";
    }

    /// <summary>
    ///  Composer to register our content app 
    /// </summary>
    public class CustomContentAppComposer : IUserComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.ContentApps().Append<CustomContentApp>();
        }
    }

    public class CustomContentApp : IContentAppFactory
    {
        private readonly string _contentAppView;

        public CustomContentApp(UriUtility uriUtility)
        {
            _contentAppView = uriUtility.ToAbsolute(CustomContentAppConstants.AppView);
        }

        public ContentApp GetContentAppFor(object source, IEnumerable<IReadOnlyUserGroup> userGroups)
        {
            if (source is IContent content)
            {
                // this item a content item, our app works 
                // for content items 
                if (ShowApp(content, userGroups))
                {
                    return new ContentApp()
                    {
                        Alias = CustomContentAppConstants.Alias,
                        Name = CustomContentAppConstants.Name,
                        Icon = CustomContentAppConstants.Icon,
                        View = _contentAppView
                    };
                }
            }

            return null;
        }

        /// <summary>
        ///  Should we show the app to the user?
        /// </summary>
        /// <remarks>
        ///  one benefit of doing this in code vs the manifest is you
        ///  can run custom code to work out if the user should see the 
        ///  app. here we are just checking groups, but you could do 
        ///  anything (like check your own tables)
        /// </remarks>
        private bool ShowApp(IContent content, IEnumerable<IReadOnlyUserGroup> groups)
        {
            if (groups.Any(x => x.Alias.InvariantEquals("admin"))) return true;

            // a permersion check ? 
            // this one is send to translate permission 
            // if (groups.Any(x => x.Permissions.Contains('5'))) return true;

            return false;
        }
    }
}
