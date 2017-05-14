module.exports = function () {

  $('.js-ckeditor').each(function () {
    var nameField = $(this).attr('name');
    CKEDITOR.replace(nameField, {
        width: '100%',
        height: 500,
        filebrowserBrowseUrl: '/browser/browse.php',
        filebrowserUploadUrl: '/uploader/upload.php'
      }
    );
  });

};
