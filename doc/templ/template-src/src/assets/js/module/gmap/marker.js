"use strict";
/**
 *
 * @param {Map} map
 * @param {LatLng} latlng
 * @param {string} title
 * @returns {Marker}
 */
var config = require('../config');
var _ = require('lodash');

exports.create = function (map, latlng, title) {
  return exports.createAdvanced({
    position: latlng,
    map: map,
    title: title
  });
};

exports.createAdvanced = function (options) {
  options = _.defaults(options, {
    animation: google.maps.Animation.DROP,
    icon: {
      url: config.assetsPathPrefix + 'img/marker/' + config.colorTheme + '.png',
      origin: new google.maps.Point(0, 0),
      anchor: new google.maps.Point(15, 47)
    }
  });
  return new google.maps.Marker(options);
};
