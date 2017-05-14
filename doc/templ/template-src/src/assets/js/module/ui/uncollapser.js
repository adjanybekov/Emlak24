/***************************************************************
 * Code that adds supports for collapsing some blocks on
 * small displays and replacing them with buttons, clicking
 * which, would reveal the hidden block.
 *
 * This is done for saving limited screen space
 * on small displays and improving UX.
 ==============================================================*/

module.exports = function () {
  $('.js-box').on('click', '.js-unhide', function () {
    var $btn = $(this);
    var $target = $btn.data('target');
    var type = $btn.data('type') || 'widget';

    if ($target === undefined) {
      $target = $btn.prev();
      type = 'simple';
      if (!$target.hasClass('js-unhide-block')) {
        $target = $btn.closest('.js-unhide-block');
        type = 'widget';
      }
    } else {
      $target = $('.' + $target);
    }

    if (!$target.length) {
      throw 'Invalid element target';
    }

    switch (type) {
      case 'widget':
        $target.addClass('opened');
        break;

      case 'simple':
        $target.show();
        break;
    }

    $btn.hide();
  });
};