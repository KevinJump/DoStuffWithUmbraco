# DoStuff Client.

This is the DoStuff client for the Umbraco backoffice, it contains the typescript files that are used to build the javascript files that live in the `app_plugins/dostuff` folder

the best way to edit and use this client library is to open this folder in visual studio code (visual studio is good for the backoffice, code is better for the typescript/lit/vite stuff.)

## Watch for changes

if you run `npm run watch' while developing, then

- Anything you save will be built by the typescript/vite commands and placed in the `app_plugins` folder of the client project.
- Because the client project is a Razor Class Library this also means that the website project will detect these changes
- If you have the "browser link" feature enabled in visual studio this will trigger a reload of your web-browser.
- If you have the web-browser inspect window open with 'disable cache' checked, then your changes will be included in the re-load.

So with all the bits lined up, save a file, see the change in the web-browser
