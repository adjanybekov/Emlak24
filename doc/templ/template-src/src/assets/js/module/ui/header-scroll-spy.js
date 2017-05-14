"use strict";
/***************************************************************
 * Enables fixed menu
 * Enables fixed search bar in mobile view
 ==============================================================*/
module.exports = function () {
  var _ = require('lodash');
  var gridSize = require('../grid-size');
  var $header = $('.header'),
    $headerNav = $('#header-nav'),
    $headerNavOffset = $('#header-nav-offset'),
    $navbarCollapse = $('#navbar-collapse-1'),
    setCssClass = '',
    lgOffset = $headerNav.offset().top + 2000,
    _cssClass = null;

  // set height for placeholder only if the navbar has not positioned absolute
  if (!$headerNav.hasClass('navbar--overlay')) $headerNavOffset.height($headerNav.height());

  var setHeaderClass = function () {
    var offsetTop = $(window).scrollTop();
    if (offsetTop > lgOffset) {
      setCssClass = 'header-fixed';
    } else {
      setCssClass = '';
    }
    if (gridSize.get() !== 'xs') {
      if (setCssClass !== _cssClass) {
        $header.removeClass('header-fixed').addClass(setCssClass);
        $headerNav.removeClass('header-fixed').addClass(setCssClass);
        $headerNavOffset.removeClass('header-fixed').addClass(setCssClass);
        $navbarCollapse.removeClass('header-fixed').addClass(setCssClass);
        _cssClass = setCssClass;
      }

    }
  };

  $(window).on('scroll', _.debounce(setHeaderClass, 10));
};
