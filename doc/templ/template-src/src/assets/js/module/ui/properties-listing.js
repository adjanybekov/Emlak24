"use strict";
module.exports = function () {
  var _ = require('lodash');
  var $btnMore = $('.js-properties-more');
  if(!$btnMore.length) return;
  var counter = 0;
  var $list = $('.js-properties-list');


  var insertItems = _.debounce(function () {
    $btnMore.addClass('button--loading');
    setTimeout(function () {
      var $demoItems = $list.find('.listing__item:lt(10)').clone();
      $list.append($demoItems);
      $btnMore.removeClass('button--loading');
      counter++;
    }, 1500);
  }, 150);

  $(window).scroll(function(){
    if( counter > 1 ) return;
    if ($(window).scrollTop() > $btnMore.offset().top - $(window).height() - 500){
      insertItems();
    }
  });
};
