"use strict";
/***************************************************************
 * UI Module for opening collapsed blocks on small screens
 ==============================================================*/
module.exports = function () {
  var $toggleBtn = $('.js-goto-btn');

  $toggleBtn.on('click', function () {
    var $btn = $(this);
    var $target = $($btn.data('goto-target'));
    var $targetWidget = $target.closest('.js-widget');

    var offsetTop = $targetWidget.offset().top;
    var time = 800 + (offsetTop / 10);
    $('html, body').animate({scrollTop: offsetTop}, time, 'linear', function () {
      $targetWidget.addClass('widget--opened');
    });

  });


  $('.sidebar .js-widget-btn, .widget--collapsing .js-widget-btn').on('click', function(){
    var $widget = $(this).closest('.js-widget');
    $widget.addClass('widget--opened');
  });


};
