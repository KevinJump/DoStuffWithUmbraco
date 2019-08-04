# Custom Trees

Most things are organised in a tree in umbraco, and you can add your own
either to an existing section or a custom section you have made. 

## Code
A tree has two parts 

### Tree Controller 
This sets up the tree and defines where in umbraco it lives and 
what nodes it has. The tree controller also defines what items 
appear in the actions menu for an item in the tree.

- [Tree Controller](MyCustomTreeController.cs)

### Tree JS/Html
there are usally a number of angular elements that make up a tree
by default Umbraco looks in `/App_Plugins/PluginName/BackOffice/TreeName/[Action].html` 
for the view. (e.g edit.html)

- [Custom Tree App_Plugin Folder](../App_Plugins/DoStuffTree/backoffice/CustomTree/)


# See Also
https://our.umbraco.com/Documentation/Extending/Section-Trees/trees