var darragh = {
    layout: {}
    , page: {
        handlers: {
        }
        , startUp: null
    }
    , services: {}
    , ui: {}
};

// moduleOptions is only used by angular
darragh.moduleOptions = {
    APPNAME: APPNAME
        , extraModuleDependencies: []
        , runners: []
        , appNamespace: darragh //we need this object here for later use
}

darragh.layout.startUp = function () {
    if (darragh.page.startUp) {
        darragh.page.startUp();
    }
};

// Only used by jQuery
$(document).ready(darragh.layout.startUp);