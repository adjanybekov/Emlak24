"use strict";
exports.create = function ($mapContainer, $mobilePopupTrigger, onLoad) {
  var mobilePopup = require('./mobile-popup');
  var gridSize = require('./grid-size');
  var _ = require('lodash');

  onLoad = onLoad || $.noop;

  if ($mobilePopupTrigger) {
    mobilePopup.wrapContainer($mapContainer, $mobilePopupTrigger, loadMap);
  } else {
    loadMap();
  }

  function loadMap() {

    onLoad();
  }

  var initLgMap = _.debounce(function() {
    if (gridSize.get() !== 'xs') {
      $('.map__wrap').html($($mapContainer[0]).detach().css({
        width: '100%',
        height: 'auto'
      }));

      google.maps.event.trigger($mapContainer[0], 'resize');
    }
  }, 500);

  $(window).resize(initLgMap);
};
