using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DoStuff.Core.Sections;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Actions;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Models.Trees;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Trees;
using Umbraco.Cms.Web.BackOffice.Trees;
using Umbraco.Cms.Web.Common.Attributes;
using Umbraco.Cms.Web.Common.ModelBinders;

namespace DoStuff.Core.Trees
{
    /// <summary>
    ///  Tree Controller 
    /// </summary>
    /// <remarks>
    ///  Unlike most things in v8 tree controllers don't need registering 
    ///  in a composer/component - they use the attribute data to build 
    ///  the tree and put it in the right section.
    /// </remarks>
    [Tree(CustomSection.SectionAlias, "CustomTree",
        TreeGroup = "CustomGroup",
        TreeTitle = "MyCustomTree",
        SortOrder = 10)]
    [PluginController("DoStuffTree")]
    public class MyCustomTreeController : TreeController
    {
        private readonly IMenuItemCollectionFactory _menuItemCollectionFactory;

        public MyCustomTreeController(
            ILocalizedTextService localizedTextService,
            UmbracoApiControllerTypeCollection umbracoApiControllerTypeCollection,
            IEventAggregator eventAggregator,
            IMenuItemCollectionFactory menuItemCollectionFactory) :
            base(localizedTextService, umbracoApiControllerTypeCollection, eventAggregator)
        {
            _menuItemCollectionFactory = menuItemCollectionFactory;
        }

        protected override ActionResult<MenuItemCollection> GetMenuForNode(string id, [ModelBinder(typeof(HttpQueryStringModelBinder))] FormCollection queryStrings)
        {
            var menu = _menuItemCollectionFactory.Create();               

            switch (id)
            {
                case "-1": // root node 
                    break;
                default: // something we add to all non-root nodes

                    var item = new MenuItem(ActionNew.ActionAlias, this.LocalizedTextService)
                    {
                        Icon = "add",
                    };
                    menu.Items.Add(item);
                    break;
            }

            // all nodes get a refresh (because we want to)
            menu.Items.Add(new RefreshNode(this.LocalizedTextService, true));
            return menu;
        }

        protected override ActionResult<TreeNodeCollection> GetTreeNodes(string id, [ModelBinder(typeof(HttpQueryStringModelBinder))] FormCollection queryStrings)
        {
            var tree = new TreeNodeCollection();

            if (id == "-1")
            {
                // for this example build some top level nodes 
                for (int x = 0; x < 10; x++)
                {
                    tree.Add(CreateTreeNode(x.ToString(), id, queryStrings, $"Child {x}", "icon-cloud"));
                }
            }

            return tree;
        }
    }
}
