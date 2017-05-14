"use strict";
module.exports = function () {
  var $form,
    $btnReplay = $('.js-comment-reply');
  $btnReplay.on('click', function () {
    if (!$form) $form = $($('.js-form-comment-wrap')[0]).clone();
    $('.js-form-comment-wrap').remove();
    $btnReplay.show();
    $(this)
      .hide()
      .closest('.js-comment-item')
      .append($form);
  });
};
