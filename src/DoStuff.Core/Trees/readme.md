# Custom Trees

Most things are organized in a tree in umbraco, and you can add your own
either to an existing section or a custom section you have made. 

## Changes from v8 to NetCore
> **Some** : Dependency injection and factory models.

1. You now have to inject methods into the tree controller to be able to use them
2. Only the `ILocalizedTextService` is avalible by default (not via `Services` collection as in v8)
3. Menus need to use the `IMenuItemCollectionFactory` to create the menu collection.


## Code
A tree has two parts 

### Tree Controller 
This sets up the tree and defines where in umbraco it lives and 
what nodes it has. The tree controller also defines what items 
appear in the actions menu for an item in the tree.

- [Tree Controller](MyCustomTreeController.cs)

### Tree JS/Html
There are usually a number of angular elements that make up a tree
by default Umbraco looks in `/App_Plugins/PluginName/BackOffice/TreeName/[Action].html` 
for the view. (e.g edit.html)

- [Custom Tree App_Plugin Folder](../App_Plugins/DoStuffTree/backoffice/CustomTree/)


# See Also
https://our.umbraco.com/Documentation/Extending/Section-Trees/trees