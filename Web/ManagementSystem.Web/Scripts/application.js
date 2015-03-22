$(document).ready(function () {
    $('.datetimepicker').datetimepicker({
        format: 'MM/DD/YYYY'
    });

    $('.edit-comment').click(function () {
        var commentContentDiv = $(this).parent().prev()
            .find('.content').first();
        commentContentDiv.hide();
    })

    $('.task-in-list').dblclick(function () {
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