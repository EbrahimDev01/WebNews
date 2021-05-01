let take = 5;



function ShowComment(id) {
    take += 5;
    GetComment(id);
}

function GetComment(id, commentId, type) {
    $.ajax({
        url: "/Comment/ShowComments",
        data: { id: id, take: take },
        method: "POST"
    }).done(function (result) {
        if (take > 5 && result.trim().length == 0) {
            take--;
        }
        else {
            $('#section-comment').html(result);

            setTimeout(function () {
                if (type) {
                    window.location.hash = "comment-item-" + commentId;
                }
                else {
                    window.location.hash = "section-comment";
                }

            }, 500);
        }
    });
}

function Hidencomment(id) {

    if (take > 5) {

        take = 5;

        GetComment(id);
    }

}


$("#AddEditComment_Title").focusout(function () {
    ValidationTitile($("#AddEditComment_Title").val().trim());
});

$("#AddEditComment_Body").focusout(function () {
    ValidationBody($("#AddEditComment_Body").val().trim());
});

function ValidationTitile(commentTitle) {
    if (commentTitle.length < 4) {
        $("[data-valmsg-for='AddEditComment.Title']").html("عنوان باید بیشتر از 4 کارکتر باشد");
        return false;
    }

    else if (commentTitle.length > 160) {
        $("[data-valmsg-for='AddEditComment.Title']").html("عنوان باید کمتر از 160 کارکتر باشد");
        return false;
    }

    $("[data-valmsg-for='AddEditComment.Title']").html("");
    return true;
}


function ValidationBody(commentBody) {
    if (commentBody.length < 10) {
        $("[data-valmsg-for='AddEditComment.Body']").html("نظر باید بیشتر از 10 کارکتر باشد");
        return false;
    }

    else if (commentBody.length > 650) {
        $("[data-valmsg-for='AddEditComment.Title']").html("نظر باید کمتر از 650 کارکتر باشد");
        return false;
    }

    $("[data-valmsg-for='AddEditComment.Body']").html("");
    return true;
}


function DeleteComment(id) {
    if (id > 0) {

        $.ajax({

            url: "/Comment/DeleteComment",
            data: { id: id },
            method: "Post"

        }).done(
            function (resutl) {

                if (resutl) {
                    $('#comment-item-' + id).remove();
                }
                else {
                    alert("مشکلی پیش آمده بعدا تلاش کنید")
                }
            }
        );
    }
}

function ClearInputs() {
    $("#AddEditComment_Body").val("");
    $("#AddEditComment_Title").val("");
    $('#AddEditComment_CommentId').attr('value', '0');

    $('#btn-add-edit-comment').html('ثبت دیدگاه ارزشمند شما');
}


function SwithToEdit(id) {

    getDatEditComment(id);
}



function SnedComment(id) {
    let comment = {
        "Body": $("#AddEditComment_Body").val().trim(),
        "Title": $("#AddEditComment_Title").val().trim(),
        "NewsId": id,
        "CommentId": $('#AddEditComment_CommentId').val()
    }

    if (ValidationTitile(comment["Title"]) && ValidationBody(comment["Body"])) {

        let typeComment = "AddComment";

        if (comment["CommentId"] != null && comment["CommentId"] > 0)
            typeComment = "EditComment";

        $.ajax({

            url: "/Comment/" + typeComment,
            data: { comment: comment, id: id },
            method: "Post"

        }).done(
            function (resutl) {
                if (resutl == true) {
                    ClearInputs();
                    GetComment(id, comment["CommentId"], typeComment == 'EditComment');

                    


                }
                else {
                    $("#comment-error-summary").html(result);
                }
            }
        );

    }
}


function getDatEditComment(id) {
    $.get("/Comment/EditComment", { id: id }, function (result) {

        if (result != false) {
            $("#AddEditComment_Body").val(result["body"]);
            $("#AddEditComment_Title").val(result["title"]);

            window.location.hash = "send-comment";


            $('#AddEditComment_CommentId').attr('value', id);

            $('#btn-add-edit-comment').html('ویرایش دیدگاه ارزشمند شما');

        } else {
            alert("مشکلی پیش آمده لطفا بعدا تلاش کنید");
        }

    });
}