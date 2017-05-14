"use strict";
module.exports = function () {
  var ScrollReveal = require('scrollreveal');
  var gridSize = require('../grid-size');
  var $body = $('body');

  var callbacks = {
    countUp: require('./count-up')
  };
  var initReveal = function () {
    if ($body.hasClass('scroll-animation')) {
      if (gridSize.get() === 'lg') {
        window.sr = new ScrollReveal({
            enter:    'bottom',
            move:     '8px',
            over:     '0.6s',
            wait:     '0s',
            easing:   'ease',

            scale:    { direction: 'up', power: '0' },
            rotate:   { x: 0, y: 0, z: 0 },
            vFactor:  0.9,
            opacity:  0,
            complete: function(el){
              var animateClass = $(el).data('animate-end');
              var animateCallback = $(el).data('animate-callback');
              if(animateClass) $(el).addClass('animated ' + animateClass);
              if(animateCallback) callbacks[animateCallback](el, 'scroll-reveal');
            }
          }
        );
      } else {
        $body.removeClass('scroll-animation');
      }
    }

  };

  initReveal();

};
