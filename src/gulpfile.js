/// <binding ProjectOpened='default' />
//
const { watch, src, dest, on } = require('gulp');
var config = require('./paths.json');

/*
 * app_plugin and build script.
 */

const appPluginPath = 'App_Plugins/' + config.pluginFolder;

/*
 * Copies files from app_plugins folder in a library
 * project into a test site.
 * 
 * Your paths.config should look like: 
 * 
 * {
 *    "library": "myPackage.LibraryName",
 *    "pluginFolder": "MyPackageFolder",
 *    "site" : "../Sandbox.Site"
 * }
 * 
 * This will run in the background, so you don't need
 * to rebuild your project when working on script files.
 */

function copy(path, baseFolder, target) {

    console.log('[\x1b[90m%s\x1b[0m\x1b[37m]\x1b[90m copy \x1b[36m%s\x1b[90m to \x1b[32m%s\x1b[0m', new Date().toLocaleTimeString(), path, target);  

    return src(path, { base: baseFolder })
        .pipe(dest(target));
}


function watchAppPlugins() {

    console.log()

    config.plugins.forEach(function(plugin) {
        
        let src =  plugin.library + "/App_Plugins/" + plugin.pluginFolder;
        let dest = config.site + '/App_Plugins/' + plugin.pluginFolder;

        watch(src + "/**/*", { ignoreInitial: false })
            .on('change', function (path, stats) {
                copy(path, src + '/', dest)
            })
            .on('add', function (path, stats) {
                copy(path, src + '/', dest)
            });
    })

    /*
    watch(appPlugin.source, { ignoreInitial: false })
        .on('change', function (path, stats) {
            copy(path, appPlugin.src, appPlugin.dest)
        })
        .on('add', function (path, stats) {
            copy(path, appPlugin.src, appPlugin.dest)
        });*/
}

exports.default = function () {
    watchAppPlugins();
};