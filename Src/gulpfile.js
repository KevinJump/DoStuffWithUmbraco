/// <binding ProjectOpened='default' />
const { watch, src, dest } = require('gulp');

//
// Gulp script to copy anyfiles from library project
// App_Plugins folder(s) to the website
// runs on project start, keeps things in sync.
//

const sources = ['DoStuff.Core/App_Plugins'];
const destination = 'DoStuff.Site/App_Plugins/';

function copy(path, base) {
    return src(path, { base: base })
        .pipe(dest(destination));
}

function time() {
    return '[' + new Date().toISOString().slice(11, -5) + ']';
}

exports.default = function () {

    sources.forEach(function (source) {

        var searchPath = source + '/**/*';

        watch(searchPath, { ignoreInitial: false })
            .on('change', function (path, stats) {
                console.log(time(), path, 'changed');
                copy(path, source);
            })
            .on('add', function (path, stats) {
                console.log(time(), path, 'added');
                copy(path, source);
            });
    });
};
    

