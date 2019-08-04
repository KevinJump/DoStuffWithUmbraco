using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Trees;
using DoStuff.Core.Sections;
using Umbraco.Web.Mvc;
using System.Net.Http.Formatting;
using System.Web.Http.ModelBinding;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.WebApi.Filters;
using Umbraco.Web.Actions;

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
        protected override MenuItemCollection GetMenuForNode(string id, [ModelBinder(typeof(HttpQueryStringModelBinder))] FormDataCollection queryStrings)
        {
            var menu = new MenuItemCollection();

            switch(id)
            {
                case "-1": // root node 
                    break;
                default: // something we add to all non-root nodes

                    var item = new MenuItem(ActionNew.ActionAlias, Services.TextService)
                    {
                        Icon = "add",
                    };
                    menu.Items.Add(item);
                    break;
            }

            // all nodes get a refresh (because we want to)
            menu.Items.Add(new RefreshNode(Services.TextService, true));
            return menu;
        }

        protected override TreeNodeCollection GetTreeNodes(string id, [ModelBinder(typeof(HttpQueryStringModelBinder))] FormDataCollection queryStrings)
        {
            var tree = new TreeNodeCollection();

            if (id == "-1")
            {
                // for this example build some top level nodes 
                for(int x = 0; x < 10; x++)
                {
                    tree.Add(CreateTreeNode(x.ToString(), id, queryStrings, $"Child {x}", "icon-cloud"));
                }
            }

            return tree;
        }
    }
}
