
function deleteImage(id) {
    $.post("/Admin/News/DeleteMedia/" + id, null, function (result) {
        if (result) {
            $('#image-' + id).remove();
        } else {
            alert("مشکلی پیش آمده لطفا بعدا تلاش کنید");
        }
    });
}