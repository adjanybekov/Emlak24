"use strict";
/***************************************************************
 * Browser workarounds for providing a better experience
 * on some browsers in certain edge cases
 ==============================================================*/
module.exports = function () {
  $(function () {
    var nua = navigator.userAgent;
    var isAndroid = (nua.indexOf('Mozilla/5.0') > -1 && nua.indexOf('Android ') > -1 && nua.indexOf('AppleWebKit') > -1 && nua.indexOf('Chrome') === -1);
    if (isAndroid) {
      $('select.form-control').removeClass('form-control search__form-control search__form-control--select').css('width', '100%')
    }
  });

  if (navigator.userAgent.match(/IEMobile\/10\.0/)) {
    var msViewportStyle = document.createElement('style')
    msViewportStyle.appendChild(
      document.createTextNode(
        '@-ms-viewport{width:auto!important}'
      )
    )
    document.querySelector('head').appendChild(msViewportStyle)
  }
};
