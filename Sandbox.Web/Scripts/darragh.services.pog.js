// create darragh.services.pogs if it does not exist
darragh.services.pog = darragh.services.pog || {};

darragh.services.pog.search = function (name,
    fromInstant, toInstant, currentPage, itemsPerPage,
    onGetAllSuccess, onGetAllError) {
    var url = "/api/pogs?";
    if (name)
    {
        url += 'name=' + name + '&';
    }
    if (fromInstant) {
        url += 'fromInstant=' + fromInstant.toString() + '&';
    }
    if (toInstant) {
        url += 'toInstant=' + toInstant.toString() + '&';
    }
    if (currentPage) {
        url += 'currentPage=' + currentPage.toString() + '&';
    }
    if (itemsPerPage) {
        url += 'itemsPerPage=' + itemsPerPage.toString() + '&';
    }
    var settings = {
        cache: false
            , dataType: "json"
            , success: onGetAllSuccess
            , error: onGetAllError
            , type: "GET"
    };
    $.ajax(url, settings);
}

// For backward compatibility
darragh.services.pog.getAll = function (onGetAllSuccess, onGetAllError) {
    darragh.services.pog.search(null, null, null, 1, 10000, onGetAllSuccess, onGetAllError);
}

darragh.services.pog.getById = function (id, onGetByIdSuccess, onGetByIdError) {
    var url = "/api/pogs/" + id;
    var settings = {
        cache: false
            , dataType: "json"
            , success: onGetByIdSuccess
            , error: onGetByIdError
            , type: "GET"
    };
    $.ajax(url, settings);
}


darragh.services.pog.postJq = function (data, onPostSuccess, onPostError) {
    var url = "/api/pogs";
    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: data
        , dataType: "json"
        , success: onPostSuccess
        , error: onPostError
        , type: "POST"
    };
    $.ajax(url, settings);
}

darragh.services.pog.putJq = function (id, data, onPutSuccess, onPutError) {
    var url = "/api/pogs/" + id;
    var settings = {
        cache: false
        , contentType: 'application/x-www-form-urlencoded; charset=UTF-8'
        , data: data
        , dataType: "json"
        , success: onPutSuccess
        , error: onPutError
        , type: "PUT"
    };
    $.ajax(url, settings);
}





darragh.services.pog.delete = function (id, onDeleteSuccess, onDeleteError) {
    var url = "/api/pogs/" + id;
    var settings = {
        cache: false
            , dataType: "json"
            , success: onDeleteSuccess
            , error: onDeleteError
            , type: "DELETE"
    };
    $.ajax(url, settings);
}

darragh.services.pog.post = function (data, onPostSuccess, onPostError) {
    var url = "/api/pogs";
    var settings = {
        cache: false
        , contentType: "application/json; charset=UTF-8"
        , data: JSON.stringify(data)
        , dataType: "json"
        , success: onPostSuccess
        , error: onPostError
        , type: "POST"
    };
    $.ajax(url, settings);
}

darragh.services.pog.put = function (id, data, onPutSuccess, onPutError) {
    var url = "/api/pogs/" + id;
    var settings = {
        cache: false
        , contentType: 'application/json; charset=UTF-8'
        , data: JSON.stringify(data)
        , dataType: "json"
        , success: onPutSuccess
        , error: onPutError
        , type: "PUT"
    };
    $.ajax(url, settings);
}