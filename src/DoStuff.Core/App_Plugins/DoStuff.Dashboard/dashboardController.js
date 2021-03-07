(function () {

    'use strict';

    function dashboardController($scope) {

        var vm = this;

        vm.title = 'Do Stuff with Umbraco';
        vm.description = 'A dashboard';

        vm.navigation = [
            {
                name: 'Default',
                alias: 'default',
                icon: 'icon-defrag',
                view: Umbraco.Sys.ServerVariables.umbracoSettings.appPluginsPath + '/DoStuff.Dashboard/default.html',
                active: true
            },
            {
                name: 'overlay',
                alias: 'overlay',
                icon: 'icon-layout',
                view: Umbraco.Sys.ServerVariables.umbracoSettings.appPluginsPath + '/DoStuff.Dashboard/overlay.html',
            }
        ];
    }

    angular.module('umbraco')
        .controller('doStuffDashboardController', dashboardController);

})();