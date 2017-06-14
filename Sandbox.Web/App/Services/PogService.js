/* Rewrite to use $http service */

(function () {
    "use strict";

    angular.module(APPNAME)
         .factory('pogService', PogServiceFactory);

    PogServiceFactory.$inject = ['$baseService', '$sabio'];
    
    function PogsServiceFactory($baseService, $sabio) {
        var newService = $baseService.merge(true, {}, sabio.services.pogs, $baseService);
        return newService;
    }
})();