(function () {
    "use strict";

    angular.module(APPNAME)
    .factory('$baseService', BaseServiceFactory);

    BaseServiceFactory.$inject = ['$window', '$location'];

    function BaseServiceFactory($window, $location) {
        /*
            when this function is invoked by Angular, Angular wants an instance of the Service object.         
        */
        function getChangeNotifier($scopeFromController) {
            /*
            will be called when there is an event outside Angular that has modified
            our data and we need to let Angular know about it.
            */

            function NotifyConstructor($s) {
                var self = this;

                self.scope = $s;

                return function (fx) {
                    self.scope.$apply(fx);//this is the magic right here that cause ng to re-evaluate bindings
                }

            }

            return new NotifyConstructor($scopeFromController);


        }

        var baseService = {
            $window: $window
            , getNotifier: getChangeNotifier
            , $location: $location
            , merge: $.extend
        };

        return baseService;
    }

})();