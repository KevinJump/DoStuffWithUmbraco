/**
 * @ngdoc
 * @name doStuffSignalRService
 * @requires $http
 * 
 * @description an angular service, it is best practice to seperate
 *              off the things that call other things into a service
 *              it also makes the code less messy when it comes to 
 *              doing callbacks etc. 
 *              
 *              this isn't required for using SignalR, (you can call
 *              the hub) but if you want to intergrate signalR into
 *              you api calls, this is part of that.
 */
(function () {
    'use strict';

    function doStuffSignalRService($http) {


        // service root, you should use ServerVariables_Parsing in your
        // componet to define this path, incase umbraco isn't installed
        // as the root app.
        var serviceRoot = 'umbraco/backoffice/api/DoStuffSignalRApi/';

        // methods exposed by this service
        return {
            myMessageMethod: myMessageMethod
        };

        //////////

        /// a API call that will make signalR fire. 
        function myMessageMethod(message, clientId) {
            $http.post(serviceRoot + '/myMessageMethod', {
                message: message,
                clientId: clientId
            });
        }
    }

    // register with angular.
    angular.module('umbraco.services')
        .factory('doStuffSignalRService', doStuffSignalRService);
})();