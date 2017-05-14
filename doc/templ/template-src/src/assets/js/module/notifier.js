"use strict";
/***************************************************************
 * A helper for displaying notification at the top of the page
 * Usually this is useful in AJAX requests, in order to provide
 * a feedback to users over the request status
 *
 * You can use methods:
 * - app.notifier.showError
 * - app.notifier.showServerError
 * - app.notifier.showSuccess
 *
 * Optionally you can pass a `message` as the first argument
 * in order to provide custom text
 *
 * See https://github.com/sciactive/pnotify for documentation
 ==============================================================*/
var _ = require('lodash');
var PNotify = require('pnotify');

var conf = {
  icon: false,
  text: false,
  title_escape: false,
  addclass: "stack-bar-top",
  cornerclass: "",
  width: "100%",
  stack: {"dir1": "down", "dir2": "right", "push": "top", "spacing1": 0, "spacing2": 0},
  delay: 2000
};

var getTemplate = function (type, message) {
  type = type == 'error' ? 'error' : 'valid';
  var html = '<svg class="notify-icon"><use xlink:href="#icon-' + type + '"></use></svg>' + message;
  return html;
};
exports.showError = function (message) {
  message = message || 'An error occured, please see details below';
  new PNotify(_.merge(conf, {
    title: getTemplate('error', message),
    type: 'error'
  }));
};

exports.showServerError = function (message) {
  message = message || 'Server error occured, please contact website administrator.';
  new PNotify(_.merge(conf, {
    title: getTemplate('error', message),
    type: 'error'
  }));
};

exports.showSuccess = function (message) {
  message = message || 'An error occured, please see details below';
  new PNotify(_.merge(conf, {
    title: getTemplate('success', message),
    type: 'success'
  }));
};

exports.watchNotifications = function (messages) {
  _.each(messages, function (message) {
    if (message.type === 'error') {
      exports.showError(message.message);
    } else {
      exports.showSuccess(message.message);
    }
  });
};
