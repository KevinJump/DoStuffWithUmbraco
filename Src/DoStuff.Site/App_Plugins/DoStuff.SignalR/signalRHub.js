(function () {
    'use strict';

    function signalRHub($rootScope, $q, assetsService) {

        // the scripts required for signalR (you can't just add them to your manifest ... see below)
        var scripts = [
            Umbraco.Sys.ServerVariables.umbracoSettings.umbracoPath + '/lib/signalr/jquery.signalR.js',
            Umbraco.Sys.ServerVariables.umbracoSettings.umbracoPath + '/backoffice/signalr/hubs'];

        var starting = false;
        var callbacks = [];

        return {
            initHub: initHub
        }

        ////////////

        // Initialize the signalR hub
        function initHub(callback) {

            // its possible more than one thing could try to 
            // intialize the hub at the same time, so we have
            // to queue the callbacks untill we are finished
            callbacks.push(callback);


            if (!starting) {
                if ($.connection === undefined) {
                    // if $.connection is null, signalR is not loaded

                    starting = true;

                    var promises = [];
                    scripts.forEach(function (script) {
                        promises.push(assetsService.loadJs(script));
                    })

                    $q.all(promises)
                        .then(function () {
                            processCallbacks();
                        });
                }
                else {
                    processCallbacks();
                    starting = false;
                }
            }
        }

        // go through our queue of callbacks,
        // and setup the hubs
        function processCallbacks() {
            while (callbacks.length) {
                var cb = callbacks.pop();
                setupHub(cb);
            }
        }



        function setupHub(callback) {

            // this is our hub class from c# code
            var hubProxy = $.connection.doStuffHub;

            var hub = {
                // start the hub connection
                start: function () {

                    if ($.connection.hub.state !== $.connection.connectionState.disconnected) {
                        // if the hub is in any other state than disconnected
                        // then we stop it

                        // we do this because you have to have declared your 
                        // events before a hub is started, and if something
                        // else in Umbraco has already started the hub, then
                        // when your page loads your events won't be registered

                        // true, true is do this syncronsly, and tell the server we are stopping
                        $.connection.hub.stop(true, true)
                    }

                    $.connection.hub.start();
                },

                // event raised when signalr sends something
                on: function (eventName, callback) {

                    hubProxy.on(eventName, function (result) {

                        // we have to call $apply, because 
                        // the event is outside of angular
                        // and we need to fire angulars internal
                        // updates to ensure things on the page 
                        // change when we do things.
                        $rootScope.$apply(function () {
                            if (callback) {
                                callback(result);
                            }
                        });
                    });
                },

                // call a signalR method.
                // this method would exist in your c# 
                // Hub class.
                invoke: function (methodName, args, callback) {
                    hubProxy.invoke(methodName, args)
                        .done(function (result) {
                            // result from the Hub function
                            $rootScope.$apply(function () {
                                if (callback) {
                                    callback(result);
                                }
                            });
                        });
                },

                // The client if for the current connection
                // you might want to pass this to ApiController methods 
                // that use the hub to signal progress etc, as 
                // you need the ID to only send the message back to 
                // this single user.
                clientId: function () {
                    if ($.connection !== undefined && $.connection.hub !== undefined) {
                        return $.connection.hub.id;
                    }
                    return "";
                }
               
            }

            return callback(hub);
        }
    }

    angular.module('umbraco.resources')
        .factory('doStuffHub', signalRHub);
})();