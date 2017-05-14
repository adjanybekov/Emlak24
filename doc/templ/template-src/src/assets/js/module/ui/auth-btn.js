"use strict";
module.exports = function () {
  function closeMenu(event) {
    var clickover = $(event.target);
    var _opened = $(".navbar-collapse").hasClass("collapse in");
    if (_opened === true && !clickover.hasClass("js-navbar-toggle")) {
      $(".js-navbar-toggle").click();
    }
  }

  function openDropdown(event, dropdown) {
    closeMenu(event);
    $('.auth__nav-item').removeClass('open');
    $(dropdown).closest('li').addClass('open');
  }

  $(document).on('click', function () {
    $('.js-restore-form').closest('li').removeClass('open');
  });

  $('.js-user-login-btn').on('click', function (event) {
    closeMenu(event);
    $('.auth__nav-item').removeClass('open');
    if ($(this).hasClass('active')) {
      $(this).removeClass('active')
    } else {
      $(this).addClass('active');
      $('.js-login-form').closest('li').addClass('open');
    }
    return false;
  });

  $('.js-user-logged-btn').on('click', function (event) {
    closeMenu(event);
    $('.auth__nav-item').removeClass('open');
    if ($(this).hasClass('active')) {
      $(this).removeClass('active')
    } else {
      $(this).addClass('active');
      $('.js-user-logged-in').closest('li').addClass('open');
    }
    return false;
  });

  $('.js-user-register').on('click', function (event) {
    openDropdown(event, '.js-register-form');
  });
  $('.js-user-restore').on('click', function (event) {
    openDropdown(event, '.js-restore-form');
  });
  $('.js-restore-form').on('click', function (event) {
    event.stopPropagation();
  });
  $('.js-user-login').on('click', function (event) {
    openDropdown(event, '.js-login-form');
  });
};
