"use strict";
function HashTable() {
  var keys = [], values = [];

  return {
    put: function (key, value) {
      var index = keys.indexOf(key);
      if (index == -1) {
        keys.push(key);
        values.push(value);
      }
      else {
        values[index] = value;
      }
    },
    get: function (key) {
      return values[keys.indexOf(key)];
    }
  };
}

var infoboxInstances = new HashTable();
var markers = new HashTable();

exports.create = function (map, latlng, title, infoboxHtml, infoboxTheme) {
  var Infobox;
  var config = require('../config');
  var infoboxBuilder = require('./infobox');
  var markerBuilder = require('./marker');

  var marker = markerBuilder.create(map, latlng, title);
  markers.put(marker, {content: infoboxHtml, theme: infoboxTheme});

  Infobox = infoboxInstances.get(map);
  if (!Infobox) {
    Infobox = infoboxBuilder.create(infoboxHtml, infoboxTheme);
    infoboxInstances.put(map, Infobox);
  }

  google.maps.event.addListener(marker, 'click', function () {
    var infoboxData = markers.get(marker);
    Infobox.close();
    infoboxBuilder.setContent(Infobox, infoboxData.content, infoboxData.theme);
    Infobox.open(map, marker);
    Infobox.setVisible(true);
  });

  google.maps.event.addListener(map, 'click', function () {
    if (Infobox) {
      Infobox.setVisible(false);
    }
  });

  return marker;
};
