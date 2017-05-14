"use strict";
/***************************************************************
 * Module for rendering the dropdown tree in the filter block
 ==============================================================*/
exports.dropdownTree = function ($container) {
  var $openBtn = $container.find('.js-dtree-btn');
  var $acceptBtn = $container.find('.js-dtree-btn-accept');
  var $resetBtn = $container.find('.js-dtree-btn-reset');
  var $list = $container.find('.js-dtree-list');
  var $form = $container.closest('form');
  var placeholder = $openBtn.text();
  var isOpen = false;

  var closeOutside = require('./utils').closeOutside;

  var toggleDropdownState = function () {
    $container.toggleClass('open');
    isOpen = !isOpen;
  };

  var updateSelectedString = function () {
    var location = [];
    $list.find(':checked').each(function () {
      var name = $(this).next('label').text();
      location.push(name);
    });
    if (!location.length) {
      $openBtn.html(placeholder);
    } else {
      $openBtn.html(location.join(', '));
    }
  };

  var reset = function () {
    $list.find('input[type=checkbox]').prop({
      checked: false,
      indeterminate: false
    });
    updateSelectedString();
  };

  closeOutside($container, function () {
    if (isOpen) {
      toggleDropdownState();
    }
  });

  $list.bonsai();
  $list.qubit();

  $list.on('change', '.in-checkbox', function () {
    updateSelectedString();
  });

  $openBtn.add($acceptBtn).on('click', function () {
    toggleDropdownState();
  });

  $resetBtn.on('click', function () {
    reset();
  });

  if ($form.length) {
    $form.on('reset', function () {
      reset();
    });
  }
};
