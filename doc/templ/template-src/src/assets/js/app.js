"use strict";
window.InfoBox = require('google-maps-infobox');
var config = require('./module/config');

/**
 * @global
 * @type {{init: Function, activateHeaderSpy: (*|exports|module.exports), activateScrollToTopSpy: (*|exports|module.exports), activateUIPanel: (*|exports|module.exports)}}
 */
module.exports = {
  /**
   * @param {Object} [options]
   * @param {string} options[].urlPrefix - path that is appended to images,
   */
  initTheme: function (options) {

    var _ = require('lodash');
    if (options) {
      _.each(options, function (value, key) {
        config[key] = value;
      });
    }

    if (config.loadSvgWithAjax === true) {
      $(document.body).prepend($('<div>').load(config.assetsPathPrefix + 'img/sprite-inline.svg'));
    }

    require('jquery');
    require('slick-carousel/slick/slick.js');
    require('select2');
    require('bootstrap-sass');
    require('ion-rangeslider');
    require('jquery-bonsai');
    require('jquery-qubit');
    require('./module/parsley-bootstrap')();
    require('parsleyjs');
    require('jquery-colorbox');
    require('pnotify');
    require('google-maps-infobox');
    require('google-marker-clusterer-plus');
    require('plyr');
    require('photoswipe/dist/photoswipe');
    require('photoswipe/dist/photoswipe-ui-default');
    require('smoothscroll-for-websites');
    require('bootstrap-daterangepicker');
    require('dragscroll');
    require('dropzone');

    require('./module/workarounds')();
    require('./module/grid-size').watch();
    require('./module/ui/auth-btn')();
    require('./module/ui/navbar-toggle')();
    require('./module/ui/show-hide-btn')();
    require('./module/ui/show-headline')();
    require('./module/ui/show-form')();
    require('./module/ui/comments')();
    require('./module/ui/uncollapser')();
    require('./module/css-class-helper').initParsleyHelper();
    require('./module/data-api/datetime')();
    require('./module/ui/range-input').initRangeInput();
    require('./module/ui/properties-listing')();
    require('./module/ui/properties-table')();
    require('./module/ui/chart-current-balance')();
    require('./module/data-api/ckeditor')();
    require('./module/ui/tags-favorites')();
    require('./module/ui/favorites')();
    require('./module/ui/form-property')();
    require('./module/ui/chart-profile-statistics')();
    require('./module/ui/chart-property-statistics')();
    //require('./module/ui/plan')();
    require('./module/ui/map-fullscreen')();
  },
  activateHeaderSpy: require('./module/ui/header-scroll-spy'),
  activateScrollToTopSpy: require('./module/ui/scrollup-spy'),
  activateUIPanel: require('./demo/ui-panel'),
  config: config,
  gridSize: require('./module/grid-size'),
  createMap: require('./module//map').create,
  geolocation: require('./module/gmap/geolocation'),
  createGmapMarker: require('./module/gmap/marker'),
  createGmapInfoboxMarker: require('./module/gmap/infobox-marker').create,
  createGmapClustering: require('./module/gmap/clusterer').create,
  createLeafletInfoboxMarker: require('./module/leaflet').addInfoboxMarker,
  notifier: require('./module/notifier'),
  createPhotoSwipe: require('./module/ui/photo-swipe').init,
  scrollAnimation: require('./module/ui/scroll-animation'),
  Vivus: require('vivus'),
  CountUp: require('countup'),
  utils: require('./module/utils'),
  rangeInputInteraction: require('./module/ui/range-input').rangeInputInteraction
};
