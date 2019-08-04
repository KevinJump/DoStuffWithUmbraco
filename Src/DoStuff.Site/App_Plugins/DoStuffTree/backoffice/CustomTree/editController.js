(function () {
    'use strict';

    function editController($scope, $routeParams, notificationsService) {
        var vm = this;
        vm.loading = true;
        vm.buttonState = 'init';

        vm.page = {
            title: 'Something ' + $routeParams.id,
            description: 'A thing we want to edit'
        };

        // functions
        vm.save = save; 

        // startup
        init($routeParams.id); 

        /////////////
        function save() {
            notificationsService.success('Save', 'Things saved?');
            vm.buttonState = 'success';
        }


        function init(id) {

            // id would be our id for the item, 


            // do things you want to happen first
            vm.loading = false; 
        }

    }

    angular.module('umbraco')
        .controller('doStuffCustomTreeEditController', editController);
})();