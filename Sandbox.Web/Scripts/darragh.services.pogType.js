darragh.services.pogType = darragh.services.pogType || {};

darragh.services.pogType.getAll = function (onGetAllSuccess, onGetAllError) {
        var url = "/api/pogTypes";
        
        var settings = {
            cache: false
                , dataType: "json"
                , success: onGetAllSuccess
                , error: onGetAllError
                , type: "GET"
        };
        $.ajax(url, settings);
}

darragh.services.pogType.getById = function (id, onGetByIdSuccess, onGetByIdError) {
    var url = "/api/pogTypes/" + id;
    var settings = {
        cache: false
            , dataType: "json"
            , success: onGetByIdSuccess
            , error: onGetByIdError
            , type: "GET"
    };
    $.ajax(url, settings);
}


darragh.services.pogType.postJq = function (data, onPostSuccess, onPostError) {
    var url = "/api/pogTypes";
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

darragh.services.pogType.putJq = function (id, data, onPutSuccess, onPutError) {
    var url = "/api/pogTypes/" + id;
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

darragh.services.pogType.delete = function (id, onDeleteSuccess, onDeleteError) {
    var url = "/api/pogTypes/" + id;
    var settings = {
        cache: false
            , dataType: "json"
            , success: onDeleteSuccess
            , error: onDeleteError
            , type: "DELETE"
    };
    $.ajax(url, settings);
}

darragh.services.pogType.post = function (data, onPostSuccess, onPostError) {
    var url = "/api/pogTypes";
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

darragh.services.pogType.put = function (id, data, onPutSuccess, onPutError) {
    var url = "/api/pogTypes/" + id;
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