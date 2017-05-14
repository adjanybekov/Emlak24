"use strict";
//exports.centerElementInViewport = function (DOMElement) {
//    require('jquery-smooth-scroll');
//    var elementHeight,
//        elementOffset,
//        windowHeight,
//        offset,
//        $element;
//
//    $(window).on('DOMContentLoaded load', function () {
//        if (!exports.isElementInViewport(DOMElement)) {
//            $element = $(DOMElement);
//            elementOffset = $element.offset().top;
//            elementHeight = $element.height();
//            windowHeight = $(window).height();
//
//            if (elementHeight < windowHeight) {
//                offset = elementOffset - ((windowHeight / 2) - (elementHeight / 2));
//            }
//            else {
//                offset = elementOffset;
//            }
//            $.smoothScroll({speed: 500}, offset);
//        }
//    });
//};

exports.isElementInViewport = function (DOMElement) {
  var rect = DOMElement.getBoundingClientRect();
  var windowHeight = (window.innerHeight || document.documentElement.clientHeight);
  var windowWidth = (window.innerWidth || document.documentElement.clientWidth);

  return (
    (rect.left >= 0)
    && (rect.top >= 0)
    && ((rect.left + rect.width) <= windowWidth)
    && ((rect.top + rect.height) <= windowHeight)
  );
};

exports.focusInputOnLoad = function (inputName) {
  var element = document.getElementsByName(inputName)[0];
  if (element) {
    element.focus();
    exports.centerElementInViewport(element);
  }
};

exports.setFormProcessingState = function ($form, promise, noValidator) {
  if (noValidator === undefined) {
    noValidator = true;
  }

  exports.setProcessingState($form.find(':submit'), promise, $form);
};

exports.setProcessingState = function ($clickableElement, promise, $secondaryElement) {
  var $htmlHelper = false;
  if (!$clickableElement.hasClass('button--loading') && promise.state() === 'pending') {
    $clickableElement.addClass('button__default--reset button--loading');

    if ($secondaryElement) {
      $secondaryElement.wrap('<div class="loading-overlay"></div>');
      $htmlHelper = $('<div class="loading"></div>').appendTo($secondaryElement.parent());
    }


    $clickableElement.on('click.blocker', function (event) {
      if (promise.state() === 'pending') {
        event.stopImmediatePropagation();
        alert('please wait');
        return false;
      } else {
        $clickableElement.off('click.blocker');
      }
    });

    promise.always(function () {
      $clickableElement.removeClass('button__default--reset button--loading');
      if ($secondaryElement) {
        $secondaryElement.unwrap();
        $htmlHelper.remove();
      }
      $clickableElement.off('click.blocker');
    });
  }
};

exports.closeOutside = function ($element, eventCallback) {
  var notH = 1,
    $pop = $element.on('hover', function () {
      notH ^= 1;
    });

  $(document).on('mousedown keydown', function (e) {
    if (notH || e.which == 27) {
      eventCallback();
    }
  });
};

exports.abbreviateNumber = function (number) {
  // 2 decimal places => 100, 3 => 1000, etc
  var decPlaces = Math.pow(10, 0);

  // Enumerate number abbreviations
  var abbrev = ["k", "m", "b", "t"];

  // Go through the array backwards, so we do the largest first
  for (var i = abbrev.length - 1; i >= 0; i--) {

    // Convert array index to "1000", "1000000", etc
    var size = Math.pow(10, (i + 1) * 3);

    // If the number is bigger or equal do the abbreviation
    if (size <= number) {
      // Here, we multiply by decPlaces, round, and then divide by decPlaces.
      // This gives us nice rounding to a particular decimal place.
      number = Math.round(number * decPlaces / size) / decPlaces;

      // Handle special case where we round up to the next abbreviation
      if ((number == 1000) && (i < abbrev.length - 1)) {
        number = 1;
        i++;
      }

      // Add the letter for the abbreviation
      number += abbrev[i];

      // We are done... stop
      break;
    }
  }

  return number;
};

exports.loadSvgWithAjax = function () {
  var config = require('./config');
  $(document.body).prepend($('<div>').load(config.assetsPathPrefix + 'img/sprite-inline.svg'));
};
