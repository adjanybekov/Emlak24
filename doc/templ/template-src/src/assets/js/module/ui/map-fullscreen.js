"use strict";
/***************************************************************
 * Fullscreen map, set height
 ==============================================================*/
module.exports = function () {
  var $mapCanvas = $('.js-map-canvas-fullscreen');
  if(!$mapCanvas.length) return;
  console.log($mapCanvas);

  var winHeight = $(window).height(),
    headerHeight = $('.header').height(),
    headerNavHeight = $('#header-nav').height(),
    map = $('.js-map'),
    mapHeight = map.height(),
    diff;


  var gridSize = require('../grid-size').get();
  if (gridSize !== 'lg') return;

  diff = winHeight - headerHeight - headerNavHeight;
  if (mapHeight < diff) {
    map.animate({height: diff}, 1000, function () {
      if ($mapCanvas.length) {
        google.maps.event.trigger($mapCanvas[0], 'resize');
      }
    });
  }
};
