if (!spright.services.cms)
    spright.services.cms = {}

// POST
spright.services.cms.addPage = function (payload, onAddPageSuccess, onAddPageError) {
    $.ajax({
        type: 'POST',
        url: '/api/cms/pages',
        data: payload,
        dataType: 'json',
        success: onAddPageSuccess,
        error: onAddPageError
    });
}

// PUT
spright.services.cms.updatePages = function (payload, pagesId, onUpdatePageSuccess, onUpdatePageError) {
    $.ajax({
        type: 'PUT',
        url: '/api/cms/' + pagesId,
        data:payload,
        dataType: 'json',
        success: onUpdatePageSuccess,
        error: onUpdatePageError
    });
}

// GET ALL PAGES, INDEX
spright.services.cms.loadJson = function (onAjaxSuccess, onAjaxError) {
    $.ajax({
        type: 'GET',
        url: '/api/cms/',
        dataType: 'json',
        success: onAjaxSuccess,
        error: onAjaxError
    });
}

// GET BY PAGE ID
spright.services.cms.getPageById = function (pagesId, onGetPageSuccess, onGetPageError) {
    $.ajax({
        type: 'GET',
        url: '/api/cms/' + pagesId,
        dataType: 'json',
        success: onGetPageSuccess,
        error: onGetPageError
    });
}

// DELETE BY PAGE ID
spright.services.cms.deletePagesById = function (pagesId, onDeleteSuccess, onDeleteError) {
        $.ajax({
            type: 'DELETE',
            url: '/api/cms/' + pagesId,
            success: onDeleteSuccess,
            error: onDeleteError
        });
    }
