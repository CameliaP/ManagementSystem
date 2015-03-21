$(document).ready(function () {
    $('.datetimepicker').datetimepicker({
        format: 'MM/DD/YYYY'
    });
    $('.edit-comment').click(function () {
        var commentContentDiv = $(this).parent().prev()
            .find('.content').first();
        commentContentDiv.hide();
    })
})

function showCommentSanitizeError(data) {
    $('#comment-error>ul>li').hide();
    $('<h4 class="text-danger">' + data.responseJSON.errorMessage + '</h4>')
        .insertBefore('#comment-error')
        .delay(2500)
        .fadeOut();
}

function successAddedComment() {
    $('#comment-error>ul>li').hide();
    $('#comment-content').val('');
}

function successDeleteComment(data) {
    $(data).parents('.comment').remove();
}