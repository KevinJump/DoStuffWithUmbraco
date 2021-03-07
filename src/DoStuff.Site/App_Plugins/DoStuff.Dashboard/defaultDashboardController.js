/*
 * following the angularJs styleguide https://github.com/johnpapa/angular-styleguide/blob/master/a1/README.md
 *
 * Using Immediately Invoked Function Expression (IIFE) as it helps reduct conflict and isolates our code
 * from others. 
 * https://github.com/johnpapa/angular-styleguide/blob/master/a1/README.md
 */

(function () {

    'use strict';

    function defaultDashboardController($scope,
        notificationsService, Upload,
        umbRequestHelper,
        // doStuffHub, 
        // doStuffSignalRService
        ) {

        var vm = this;

        vm.buttonState = 'init';
        vm.doThing = doThing;
        vm.callAnEndPoint = callAnEndPoint;

        // Setup the SignalR Hub
        setupHub();

        /////////////// file upload

        vm.handleFiles = handleFiles;
        vm.upload = upload;
        vm.download = download;

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

        //////// 

        ///////////// file download 

        function download() {

            var message = 'Hello from here';
            var count = 100;

            vm.buttonState = 'busy';

            var url = Umbraco.Sys.ServerVariables.doStuffFileDownload.downloadService + 'DownloadText' + "?message=" + message + "&count=" + count;

            umbRequestHelper.downloadFile(url)
                .then(function (result) {
                    vm.buttonState = 'success';
                    notificationsService.success('Downloaded', 'File downloaded');
                }, function (error) {
                    vm.buttonState = 'error';
                    notificationsService.error('Error', 'Failed to download');
                });
        }



        ////////

        function doThing() {

            // invoking a signalR method on our hub
            //  this method broadcasts to all clients
            vm.hub.invoke('hello', "this is our message",
                function (result) {
                    notificationsService.success('Done', 'The thing has been done');
                    vm.buttonState = 'success';
                });

        }

        /////////////// SignalR 
        vm.message = '';

        function setupHub() { console.log('signalR sample not yet done');}
        function callAnEndPoint() { console.log('signalR sample not yet done');}

        // SignlaR - Initialization
        /*
        function setupHub() {

            doStuffHub.initHub(function (hub) {

                // set hub as part of controller 
                // (makes it easier to get to in other methods)
                vm.hub = hub;

                // register the events you want to do things for
                vm.hub.on('hello', function (data) {
                    vm.message = data;
                    console.log(data);
                });

                // start the hub connection
                vm.hub.start();
            })
        }


        // calling an enpoint with the signalR client id from the hub
        // so only we get the messages back. 
        function callAnEndPoint() {

            doStuffSignalRService.myMessageMethod("Calling", vm.hub.clientId())
                .then(function (result) {
                    console.log(result.data);
                    notificationsService.success('Done', 'The thing has been done');
                });

        }
        */


    }

    angular.module('umbraco')
        .controller('doStuffDefaultDashboardController', defaultDashboardController);

})();