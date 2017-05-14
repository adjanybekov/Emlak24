"use strict";
/***************************************************************
 * Add support for chosen forms to listen to react
 * to `reset` event
 ==============================================================*/
module.exports = function ($container) {
  var ui = require('./ui');
  ui.dropdownTree($container.find('.js-dtree'));
  $container.find('.js-in-select').select2();
  $container.find("button[type='reset']").on('click', function (e) {
    e.preventDefault();

    var form = $(this).closest('form').get(0);
    form.reset();

    $(form).find('select').each(function (i, v) {
      $(v).trigger('change');
    });
  });
};
