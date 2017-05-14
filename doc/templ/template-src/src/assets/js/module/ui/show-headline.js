"use strict";
module.exports = function () {
  $("[class$='__headline']").on('click', function () {
    $(this).addClass('opened');
  });
};


