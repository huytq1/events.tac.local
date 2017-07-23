function createCommentItem(form, path) {
    var service = new ItemService({ url: "/sitecore/api/ssc/item" });
    var obj = {
        ItemName: 'comment - ' + form.name.value,
        TemplateID: '{F8CD1BEA-296A-4101-A1E6-27C05F713D8E}',
        Name: form.name.value,
        Comment: form.comment.value
    };   
    service.create(obj)
        .path(path)
        .execute()
        .then(function (item) {
            form.name.value = form.comment.value = '';
            window.alert('thanks');
        })
        .fail(function (err) {
            window.alert(err);
        });
    event.preventDefault();
    return false;
}