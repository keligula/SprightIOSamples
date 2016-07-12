if (!sabio.services.cms)
    sabio.services.cms = {}

// POST
sabio.services.cms.addPage = function (payload, onAddPageSuccess, onAddPageError) {
    $.ajax({
        type: 'POST',
        url: '/api/cms/pages',
        data: payload,
        dataType: 'json',
        success: onAddPageSuccess,
        error: onAddPageError
    });
}

// POST
sabio.services.cms.addPageWithWebsiteId = function (payload, onAddPageSuccess, onAddPageError) {
    $.ajax({
        type: 'POST',
        url: '/api/cms/websiteId',
        data: payload,
        dataType: 'json',
        success: onAddPageSuccess,
        error: onAddPageError
    });
}


// PUT
sabio.services.cms.updatePages = function (payload, pagesId, onUpdatePageSuccess, onUpdatePageError) {
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
sabio.services.cms.loadJson = function (onAjaxSuccess, onAjaxError) {
    $.ajax({
        type: 'GET',
        url: '/api/cms/',
        dataType: 'json',
        success: onAjaxSuccess,
        error: onAjaxError
    });
}

// GET ALL PAGES, INDEX
sabio.services.cms.loadWithWebsiteId = function (websiteId, onAjaxSuccess, onAjaxError) {
    $.ajax({
        type: 'GET',
        url: '/api/cms/website/'+ websiteId,
        dataType: 'json',
        success: onAjaxSuccess,
        error: onAjaxError
    });
}

// GET BY PAGE ID
sabio.services.cms.getPageById = function (pagesId, onGetPageSuccess, onGetPageError) {
    $.ajax({
        type: 'GET',
        url: '/api/cms/' + pagesId,
        dataType: 'json',
        success: onGetPageSuccess,
        error: onGetPageError
    });
}

// DELETE BY ID
sabio.services.cms.deletePagesById = function (pagesId, onDeleteSuccess, onDeleteError) {
        $.ajax({
            type: 'DELETE',
            url: '/api/cms/' + pagesId,
            success: onDeleteSuccess,
            error: onDeleteError
        });
    }


sabio.services.cms.checkSlug = function (payload, onGetPageSuccess, onGetPageError) {
    $.ajax({
        type: 'GET',
        url: '/api/cms/checkSlug/',
        data: payload,
        dataType: 'json',
        success: onGetPageSuccess,
        error: onGetPageError
    });
}

