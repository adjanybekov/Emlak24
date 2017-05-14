"use strict";
/**
 *
 * @param {Map} map
 * @param {Marker[]} markers - Array of markers
 * @returns {Marker}
 */
exports.create = function (map, markers) {
  var config = require('../config');
  var MarkerClusterer = require('google-marker-clusterer-plus');
  return new MarkerClusterer(map, markers, {
    maxZoom: 11,
    gridSize: 100,
    styles: [{
      url: config.assetsPathPrefix + 'img/marker/' + config.colorTheme + '.png',
      width: 34,
      height: 47,
      anchorText: [-7, 18],
      anchorIcon: [15, 47],
      textColor: '#fff',
      textSize: 10
    }]
  });
};
