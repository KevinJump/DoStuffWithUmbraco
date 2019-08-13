/*
 * following the angularJs styleguide https://github.com/johnpapa/angular-styleguide/blob/master/a1/README.md
 *
 * Using Immediately Invoked Function Expression (IIFE) as it helps reduct conflict and isolates our code
 * from others. 
 * https://github.com/johnpapa/angular-styleguide/blob/master/a1/README.md
 */

(function () {

    'use strict';

    function dashboardController($scope,
        notificationsService, Upload) {

        var vm = this;

        vm.buttonState = 'init';
        vm.doThing = doThing;

        /////////////// file upload

        vm.handleFiles = handleFiles;
        vm.upload = upload;

        function upload(file) {
            vm.buttonState = 'busy';
            Upload.upload({
                url: Umbraco.Sys.ServerVariables.doStuffFileUpload.uploadService + 'UploadFile',
                fields: {
                    'someId': 1234
                },
                file: file
            }).success(function (data, status, headers, config) {
                vm.buttonState = 'success';
                notificationsService.success('Uploaded', data);
            }).error(function (data, status, headers, config) {
                vm.buttonState = 'error';
                notificationsService.error('Upload Failed', data);
            });
        }


        function handleFiles(files, event) {
            if (files && files.length > 0) {
                vm.file = files[0];
            }
        }

        ///////////////

        //////// 

        function doThing() {
            notificationsService.success('Done', 'The thing has been done');
            vm.buttonState = 'success';
        }
    }

    angular.module('umbraco')
        .controller('doStuffDashboardController', dashboardController);

})();