
//post hhtp request to controller

function postRequest(url, data,  arr ) {
    $.ajaxSetup({ async: false });
    return $.post(url, data, function (result, status, xhr) {
        arr(result);
    }).done(() => {
    }).fail((xhr, status, message) => {
    });
}




//function postReqArr(url, data, constr, arr, fnClear = null, redir = null) {
//    $.ajaxSetup({ async: false });
//    $('#loader').css('display', 'flex');
//    return $.post(url, data, function (result, status, xhr) {
//        // console.log(xhr.status);
//        var res = JSON.parse(result);
//        if (res.HasError)
//            jAlert(res.Message, "Warning!", redir);
//        else {
//            if (!arr) {
//                jAlert(res.Message, "Success!", redir);
//            } else if (constr) {
//                try {
//                    arr(res.ResponseData.map(x => new constr(x)));
//                } catch (e) {
//                    arr(new constr(res.ResponseData));
//                }
//            } else {
//                if (res.Message) {
//                    jAlert(res.Message, 'Success!', redir);
//                }
//                arr(res.ResponseData);
//            }
//            if (fnClear) fnClear();
//        }
//    }).done(() => {
//        $('#loader').hide();
//    }).fail((xhr, status, message) => {
//        jAlert(message, status);
//        $('#loader').hide();
//    });
//}
