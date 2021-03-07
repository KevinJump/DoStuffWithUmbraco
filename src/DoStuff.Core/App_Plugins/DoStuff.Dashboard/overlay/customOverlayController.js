(function () {
    'use strict';

    function customOverlayController($scope) {

        var vm = this;
        $scope.model.complete = false;

        vm.step = 1;

        vm.icon = 'icon-box';

        vm.content = 'A custom overlay.'

        // add method to model, so we can call it from parent 
        $scope.model.process =  process;

        function process() {

            vm.step++;
            $scope.model.description = 'Step ' + vm.step;

            switch (vm.step) {
                case 2:
                    vm.icon = 'icon-sprout';
                    vm.content = 'Do another thing';
                    $scope.model.submitButtonLabel = 'One last thing';
                    break;
                case 3:
                    vm.icon = 'icon-check color-green';
                    vm.content = 'We are done now';
                    $scope.model.submitButtonLabel = 'Finish';
                    $scope.model.complete = true;
                    break;
            }


        }
    }

    angular.module('umbraco')
        .controller('doStuffCustomOverlayController', customOverlayController);
})();