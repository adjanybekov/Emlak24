"use strict";
module.exports = function () {
  $(".js-form-title").on('click', function () {
    var $this = $(this),
      $rel = $($this.data('rel')),
      $map;
    $rel.toggleClass('opened');
    $this.toggleClass('active');
    $map = $rel.find('.js-map');
    if ($map.length) {
      google.maps.event.trigger($map[0], 'resize');
    }
  });
};


