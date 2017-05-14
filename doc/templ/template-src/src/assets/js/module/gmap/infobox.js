"use strict";
/**
 * Creates a infobox window for google maps
 *
 * @param {string} content
 * @param {string} theme - "dark" or "white"
 * @returns {InfoBox} Infobox object
 */

exports.create = function (content, theme) {
  var config = require('../config');
  var infoboxBuilder = require('google-maps-infobox');
  theme = theme || 'white';
  return new infoboxBuilder({
    content: generateContent(content, theme),
    boxStyle: {
      background: "none",
      opacity: 1,
      width: "355px"
    },
    pixelOffset: new google.maps.Size(-17, -77),
    closeBoxMargin: "7px 7px 2px 2px",
    closeBoxURL: "",
    infoBoxClearance: new google.maps.Size(1, 1),
    visible: true,
    pane: "floatPane",
    enableEventPropagation: false
  });
};

exports.setContent = function (Infobox, content, theme) {
  Infobox.setContent(generateContent(content, theme));
};

function generateContent(content, theme) {
  return "<div class='map__infobox map__infobox--" + theme + "'>" + content + "</div>";
}
