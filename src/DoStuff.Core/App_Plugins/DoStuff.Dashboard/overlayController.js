(function () {
    'use strict';

    function overlayDashboardController($scope, overlayService) {

        var vm = this;

        vm.openConfirmOverlay = openConfirmOverlay;
        vm.openCustomOverlay = openCustomOverlay;

        function openConfirmOverlay(content, confirmType) {

            var options = {
                title: 'Simple',
                content: content,
                disableBackdropClick: true,
                disableEscKey: true,
                confirmType: confirmType, // type of confirmation.
                submit: function () {
                    overlayService.close();
                }
            };

            overlayService.confirm(options);

        }

        function openCustomOverlay() {


            var options = {
                view: Umbraco.Sys.ServerVariables.umbracoSettings.appPluginsPath + '/DoStuff.Dashboard/overlay/customOverlay.html',
                title: 'Custom overlay',
                description: 'A custom view in an overlay',
                disableBackdropClick: true,
                disableEscKey: true,
                submitButtonLabel: 'Do Things',
                closeButtonLable: 'Close',
                submit: function (model) {

                    // multi-step overlay, will still call the submit
                    // as its the only button, 
                    // but you can use values in the model, to check
                    // if you are ready to close.
                    // simple example, we have a process function 
                    // (in the overlay's controller) that does stuff
                    // and sets complete when done. 

                    // when complete is true, we close the overlay.
                    // until then we keep calling process.

                    if (model.complete) {
                        overlayService.close();
                    }
                    else {
                        model.process();
                    }

                },
                close: function () {
                    overlayService.close();
                }

            }

            overlayService.open(options);

        }


    }

    angular.module('umbraco')
        .controller('doStuffOverlayDashboardController', overlayDashboardController);
})();