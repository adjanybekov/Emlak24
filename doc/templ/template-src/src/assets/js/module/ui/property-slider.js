require('slick-carousel');
var _ = require('lodash');

module.exports = function (container, options) {
  // slider for property details
  var $root = $(container);
  options = options || {};

  var $currentNumber = $root.find('.js-properties-banner-current');
  var $totalNumber = $root.find('.js-properties-banner-total');
  var totalBannerItems = $root.find('.slider__item').length;

  var slickOptions = _.defaults({
    dots: false,
    infinite: true,
    speed: 300,
    slidesToShow: 1,
    prevArrow: $root.find('.js-banner-prev'),
    nextArrow: $root.find('.js-banner-next')
  }, options);

  $totalNumber.html(totalBannerItems);
  $root.find('.js-slick-items')
    .slick(slickOptions)
    .on('afterChange', function (event, slick, currentSlide) {
      $currentNumber.html(currentSlide + 1 + ' /');
    });
};
