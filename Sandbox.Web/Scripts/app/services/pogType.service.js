(function () {
    "use strict";
    angular.module(APPNAME)
         .factory('pogTypeService', PogTypeService);

    function PogTypeService() {
        return darragh.services.pogType;
    }

})();