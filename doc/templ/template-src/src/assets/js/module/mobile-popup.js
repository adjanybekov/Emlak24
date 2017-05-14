"use strict";
/***************************************************************
 * Helper for improved user experience with maps on devices
 * with small screen.
 *
 * So that, when user loads the map on small-screen device, it
 * is replaced by a button, clicking on it will open full screen
 * popup with the map in it.
 *
 ==============================================================*/
/**
 * @param $mapContainer
 * @param $triggerButton
 * @param loadCallback
 */
exports.wrapContainer = function ($mapContainer, $triggerButton, loadCallback) {
  var gridSize = require('./grid-size');
  var $body = $('body');


  $triggerButton.on('click', function () {
    if (gridSize.get() == 'xs') {
      $.colorbox({
        html: $mapContainer,
        onLoad: function () {
          var winWidth = $(window).width();
          var winHeight = window.innerHeight;
          $mapContainer.css({
            width: winWidth,
            height: winHeight
          });
        },
        onComplete: function () {
          loadCallback();
          $body.css({overflow: 'hidden'});
        },
        onCleanup: function () {
          $body.css({overflow: 'auto'});
        }
      });
    }
  });

  loadCallback();

};
