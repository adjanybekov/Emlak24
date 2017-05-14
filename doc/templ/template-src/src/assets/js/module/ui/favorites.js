"use strict";
module.exports = function () {
  var $listingSelect = $('.js-listing-select');
  if (!$listingSelect.length) return;

  $listingSelect.on('click', function () {
    var $btn = $(this);
    var $item = $btn.closest('.js-listing-item');
    $item.toggleClass('listing__item--selected');
    $btn.toggleClass('active');

  });
};
