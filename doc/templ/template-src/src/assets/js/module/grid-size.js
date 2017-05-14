"use strict";
/***************************************************************
 * JS helper for improving responsive experience
 ==============================================================*/
var currentGridSize = null;

exports.get = function () {
  return currentGridSize;
};

exports.watch = function () {
  var winWidth = window.innerWidth,
    screenList = ['xs', 'sm', 'md', 'lg'],
    $body = $('body');

  function checkScreen(width) {
    currentGridSize = screenList[0];

    if (width < 767) currentGridSize = screenList[0];
    if (width >= 767) currentGridSize = screenList[1];
    if (width > 992) currentGridSize = screenList[2];
    if (width > 1200) currentGridSize = screenList[3];

    $body.removeClass(screenList.join(' '));
    $body.addClass(currentGridSize);
  }

  checkScreen(winWidth);

  $(window).resize(function () {
    checkScreen(window.innerWidth);
  });
};
