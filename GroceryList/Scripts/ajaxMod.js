var AjaxMod = (function () {

    function makePostCall(url, objParams, dataType, doneFunc, arrElems, name) {

        dataType = (dataType) ? dataType : "json";//If no value is present , then default to json

        var deferred = $.ajax({
            type: "POST",
            url: url,
            async: true,
            data: JSON.stringify(objParams),
            contentType: "application/json; charset=utf-8",
            dataType: dataType
        }).done(function (data) {
            try {
                if (doneFunc) { doneFunc(data, arrElems); } // execute callback function if exists
            }
            catch (ex) {                
                console.log(ex);              
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (textStatus != "abort") errorHandler(jqXHR, textStatus, errorThrown, name); // log error if user did not abort
        });
        return deferred;
    }

    function makeGetCall(url, objParams, dataType, doneFunc, arrElems, name) {
        
        if (!url) { console.log("URL not available"); }

        dataType = (dataType) ? dataType : "json";//If no value is present , then default to json

        var deferred = $.ajax({
            type: "GET",
            url: url,
            async: true,
            data: objParams,
            contentType: "application/json; charset=utf-8",
            dataType: dataType
        }).done(function (data) {
            try {
                if (doneFunc) { doneFunc(data, arrElems); } // execute callback function if exists
            }
            catch (ex) {
                console.log(ex);
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.log("url: " + url);            
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
            console.log(objParams);
            console.log(doneFunc);
            if (textStatus != "abort") errorHandler(jqXHR, textStatus, errorThrown, name); // log error if user did not abort
        });
        return deferred;
    }

    function errorHandler(jqXHR, textStatus, errorThrown, request, name) { // handle ajax error
        var error = "ajax Error on '" + request + "'";
        if (name) error += ' - ' + name;
        //pageMod.handleError(10, error, JSON.stringify(jqXHR), pageMod.errModalElem, pageMod.errListElem); // log & display
    }

    $(document).ready(function () {
        $(document).ajaxComplete(function (event, xhr, settings) {
           
        });
    });

    return {
        POST: makePostCall,
        GET: makeGetCall
    }

})();