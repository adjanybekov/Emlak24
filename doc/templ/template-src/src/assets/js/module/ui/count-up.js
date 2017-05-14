'use strict';
module.exports = function (el, params) {
  var CountUp = require('countup');
  if(params === 'scroll-reveal') {
    var $counter = $(el).find('.js-count-up');
    var $counterValueEnd = $counter.data('count-end') || 0;
    var $counterValueStart= $counter.data('count-start') || 0;
    var $counterValueDuration= $counter.data('count-duration') || 2;
    var options = {
      useEasing : true,
      useGrouping : true,
      separator : ' ',
      decimal : '.',
      prefix : '',
      suffix : ''
    };

    var counterAnim = new CountUp($counter[0], $counterValueStart, $counterValueEnd, 0, $counterValueDuration, options);
    counterAnim.start();
  }
};
