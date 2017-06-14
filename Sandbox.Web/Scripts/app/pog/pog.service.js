(function () {
    "use strict";

    angular.module(APPNAME)
         .factory('pogService', PogServiceFactory);

    // $darragh is a reference to the darragh namespace which is created in darragh.js
    PogServiceFactory.$inject = ['$darragh'];

    function PogServiceFactory($darragh) {
        return $darragh.services.pog;
    }
})();