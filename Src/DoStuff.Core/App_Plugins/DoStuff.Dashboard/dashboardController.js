/*
 * following the angularJs styleguide https://github.com/johnpapa/angular-styleguide/blob/master/a1/README.md
 *
 * Using Immediately Invoked Function Expression (IIFE) as it helps reduct conflict and isolates our code
 * from others. 
 * https://github.com/johnpapa/angular-styleguide/blob/master/a1/README.md
 */

(function () {

    'use strict';

    function dashboardController($scope, notificationsService) {

        var vm = this;

        vm.buttonState = 'init';
        vm.doThing = doThing;

        //////// 

        function doThing() {
            notificationsService.success('Done', 'The thing has been done');
            vm.buttonState = 'success';
        }
    }

    angular.module('umbraco')
        .controller('doStuffDashboardController', dashboardController);

})();