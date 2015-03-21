function showCommentSanitizeError(data) {
    $('#comment-error>ul>li').hide();
    $('<h4 class="text-danger">' + data.responseJSON.errorMessage + '</h4>')
        .insertBefore('#comment-error')
        .delay(2500)
        .fadeOut();
}

function changeCommentsLabel() {
    $('#comment-error>ul>li').hide();
}