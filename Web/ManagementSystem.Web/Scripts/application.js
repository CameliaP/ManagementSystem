$(document).ready(function () {
    $('body').on('focus',".datetimepicker", function(){
        $(this).datetimepicker({
            format: 'MM/DD/YYYY'
        })
    });

    $(document).on('click', '.btn-edit-comment', function () {
        var commentContentDiv = $(this).parent().parent().prev()
            .find('.content').first();
        commentContentDiv.hide();
    })

    $(document).on('click', '.edit-cancel', function () {
        var commentContentDiv = ($(this).parent().parent().parent().parent().parent()).prev();
        var commentId = commentContentDiv.attr('id').split('-')[2];
        var editForm = ($(this).parent().parent().parent().parent().parent())
        commentContentDiv.show();
        $('<div id="comment-content-edit-' + commentId + '"></div>').insertAfter(commentContentDiv);
        editForm.remove();
    })

    $(document).on('dbclick', '.task-in-list', function () {
        var taskId = $(this).attr('id').split('-')[1];
        window.location.href = '/Tasks/Details/' + taskId;
    });
})

function showCommentSanitizeError(data) {
    $('#comment-error>ul>li').hide();
    $('<h4 class="text-danger">' + data.responseJSON.errorMessage + '</h4>')
        .insertBefore('#comment-error')
        .delay(2500)
        .fadeOut();
}

function successAddedComment(data) {
    var newReminderDate = $(data).find('#ReminderDate').val();
    $('#comment-next-action-date').text(newReminderDate);
    $('#comment-error>ul>li').hide();
    $('#comment-content').val('');
    $('#ReminderDate').val('');
    $('#comments-label').html('');
}

function successDeleteComment(data) {
    $(data).parents('.comment').remove();
}