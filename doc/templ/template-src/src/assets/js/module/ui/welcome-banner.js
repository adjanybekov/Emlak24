"use strict";
module.exports = function ($container, lineIdPrefix) {
  var Vivus = require('vivus');
  lineIdPrefix = lineIdPrefix || '';
  /***************************************************************
   * Initialize banner animation
   * Just add class start animation on document ready
   ==============================================================*/

  $container.addClass('banner--play');

  /***************************************************************
   * Initialize line animation
   * See https://github.com/maxwellito/vivus for more options
   ==============================================================*/
  new Vivus(lineIdPrefix + 'banner-line', {type: 'async', duration: 50}, function () {
    $container.find('.js-arrow-end').css({opacity: 1});
    $container.find('.js-search-form').addClass('search--anim');
  });
};
