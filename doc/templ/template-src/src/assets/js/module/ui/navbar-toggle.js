"use strict";

module.exports = function () {
  /**
   * Display language bar in responsive mode
   */

  var $navBar = $('#navbar-collapse-1'),
    $siteWrap = $('.js-site-wrap'),
    $navbarRow = $('.js-navbar-row'),
    $navbarToggle = $('.js-navbar-toggle'),
    $header = $('.header'),
    $navBarClone;

  var gridSize = require('../grid-size');

  var xDown = null;
  var yDown = null;

  function handleTouchStart(evt) {
    xDown = evt.touches[0].clientX;
    yDown = evt.touches[0].clientY;
  }

  function handleTouchMove(evt) {
    if (!xDown || !yDown || !evt) {
      return;
    }

    var xUp = evt.touches[0].clientX;
    var yUp = evt.touches[0].clientY;

    var xDiff = xDown - xUp;
    var yDiff = yDown - yUp;

    if (Math.abs(xDiff) > Math.abs(yDiff)) {/*most significant*/
      if (xDiff > 0) {
        /* left swipe */
      } else {
        /* right swipe */
        if ($siteWrap.hasClass('site-wrap--move')) {
          requestAnimationFrame(function () {
            $siteWrap.removeClass('site-wrap--move');
            $navbarToggle.removeClass('collapsed');
            $header.removeClass('header--mob-opened');
          });
        }
      }
    } else {
      if (yDiff > 0) {
        /* up swipe */
      } else {
        /* down swipe */
      }
    }
    /* reset values */
    xDown = null;
    yDown = null;
  }

  function moveMenu (mobile) {
    $navBarClone = $navBar.detach();
    if(mobile) {
      $siteWrap.before($navBarClone);
      $navBarClone.addClass('navbar__wrap--init');
    } else {
      $navbarRow.append($navBarClone);
      $navBarClone.removeClass('navbar__wrap--init');
      $siteWrap.removeClass('site-wrap--move');
      $navbarToggle.removeClass('js-navbar-toggle');
    }
  }

  function initMenu () {
    if (gridSize.get() === 'xs') {
      document.addEventListener('touchstart', handleTouchStart, false);
      document.addEventListener('touchmove', handleTouchMove, false);
      handleTouchMove();
      moveMenu(true);
    } else {
      // feature check direction where open dropdown menu
      $('.js-dropdown').each(function (i, item) {
        var $dropdown = $(item).find('.js-dropdown-menu');
        var offsetLeft = $(item).offset().left;
        var offsetRight = ($(window).width() - ($(item).offset().left + $(item).outerWidth()));
        if (offsetLeft < $dropdown.width() ) {
          $dropdown.removeClass('navbar__dropdown--left').removeClass('navbar__dropdown--right').addClass('navbar__dropdown--left');
        } else if (offsetRight < $dropdown.width() ){
          $dropdown.removeClass('navbar__dropdown--left').removeClass('navbar__dropdown--right').addClass('navbar__dropdown--right');
        }
      });

      moveMenu(false);
    }
  }

  $navbarToggle.on('click', function () {
    var $this = $(this);
    requestAnimationFrame(function () {
      $this.toggleClass('collapsed');
      requestAnimationFrame(function () {
        $siteWrap.toggleClass('site-wrap--move');
        $header.toggleClass('header--mob-opened');
      });
    });
  });

  $('.js-dropdown > a').on('click', function () {
    var $dropdown = $(this).closest('.js-dropdown');
    if ($dropdown.hasClass('open')) {
      $dropdown.removeClass('open');
    } else {
      if (gridSize.get() === 'xs') {
        $('html, body').scrollTop(0);
      }
      $dropdown.addClass('open');
    }
  });

  $('.js-navbar-sublink')
    .on('click', function () {
      var parentItem = $(this).closest('li');
      parentItem.addClass('open');
    });

  $('.js-navbar-submenu-back').on('click', function () {
    var parentItem = $(this).closest('.js-dropdown');
    parentItem.removeClass('open');
  });

  initMenu();

  var throttledNavMove = _.throttle(initMenu, 500);
  $(window).resize(throttledNavMove);
};
