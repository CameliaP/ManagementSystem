$(document).ready(function () {
    $('.datetimepicker').datetimepicker({
        format: 'MM/DD/YYYY'
    });

    $('.edit-comment').click(function () {
        var commentContentDiv = $(this).parent().prev()
            .find('.content').first();
        commentContentDiv.hide();
    })

    $('a').click(function () {
        var href = $(this).attr('href');

        // Redirect only after 500 milliseconds
        if (!$(this).data('timer')) {
            $(this).data('timer', setTimeout(function () {
                window.location = href;
            }, 500));
        }
        return false; // Prevent default action (redirecting)
    });

    $('a').dblclick(function () {
        clearTimeout($(this).data('timer'));
        $(this).data('timer', null);

        return false;
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
    $('#comments-label').html('');
}

function successDeleteComment(data) {
    $(data).parents('.comment').remove();
}