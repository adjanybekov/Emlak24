"use strict";
require('leaflet');

exports.addInfoboxMarker = function (map, latlng, title, infoboxHtml, infoboxTheme) {
  var config = require('./config');
  var propertyIcon = L.icon({
    iconUrl: config.assetsPathPrefix + 'img/marker/' + config.colorTheme + '.png',
    iconSize: [34, 47],
    iconAnchor: [0, 0],
    popupAnchor: [25, -25]
  });
  L.marker(latlng, {icon: propertyIcon})
    .addTo(map)
    .bindPopup("<div class='map__infobox map__infobox--" + infoboxTheme + "'>" + infoboxHtml + '</div>');
};
