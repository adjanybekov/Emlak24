"use strict";
/**
 * @param {Map} map Google Map Object
 * @param {Object} options
 * @param {String} options.buttonTrigger
 * @param {Function} options.onSuccess
 */
module.exports.activate = function (map, options) {
  var notifier = require('../notifier');
  var _ = require('lodash');
  options = _.defaults(options, {
    buttonTrigger: false,
    onSuccess: function () {
    }
  });

  if (options.buttonTrigger) {
    $(options.buttonTrigger).on('click', initialize);
  } else {
    google.maps.event.addDomListener(window, 'load', initialize);
  }


  function initialize() {
    // Try HTML5 geolocation
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        function (position) {
          var pos = new google.maps.LatLng(
            position.coords.latitude,
            position.coords.longitude
          );
          map.setCenter(pos);
          options.onSuccess(pos);
        }, function () {
          handleNoGeolocation(true);
        }
      );
    } else {
      // Browser doesn't support Geolocation
      handleNoGeolocation(false);
    }
  }

  function handleNoGeolocation(errorFlag) {
    if (errorFlag) {
      notifier.showError('Error: The Geolocation service failed.');
    } else {
      notifier.showError('Error: Your browser doesn\'t support geolocation.');
    }
  }

};
