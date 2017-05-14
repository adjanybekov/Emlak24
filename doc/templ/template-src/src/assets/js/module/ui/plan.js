"use strict";
module.exports = function () {

  var gridSize = require('../grid-size');
  var $body = $('body');
  var $plan = $('.js-plan');
  var $planHead = $('.js-plan-head');
  var $planHeadWrap = $('.js-plan-head-wrap');
  var $planNumber = $('.js-plan-number');
  var $planNumberWrap = $('.js-plan-number-wrap');
  var $planWrap = $('.js-plan-wrap');
  var $planNav = $('.js-plan-nav');
  var $planNavOverview = $('.js-plan-nav-overview');
  var $planBody = $('.js-plan-body');
  var $planBlockEmpty = $('.plan__heading--empty');
  var $planModal = $('#modal-plan-detail');
  var $planSliderWrap = $('.js-slick-plan');
  var $planSlider = $planSliderWrap.find('.js-slick-slider');
  var $planSliderTotal = $planSliderWrap.find('.js-slick-total');
  var $planSliderCurrent = $planSliderWrap.find('.js-slick-current');

  var stateLevel = false;
  var stateMousemove = false;
  var cellWidth = 35;
  var cellHeigth = 15;
  var cellWidthBig = gridSize.get() === 'xs' ? 60 : 90;
  var cellHeigthBig =  gridSize.get() === 'xs' ? 60 : 35;
  var currentChart = 0;
  var planBodyTables = [];


  var initChart = function () {
    $planBody.each(function (i, table) {
      planBodyTables.push($(table).detach());
    });
    $planBody.remove();
  };

  var openChart = function (chart) {
    $planNumberWrap.hide();
    $planHeadWrap.hide();
    $($planNumberWrap[chart]).show();
    $($planHeadWrap[chart]).show();
    $planWrap.html(planBodyTables[chart]);
  };

  var setWidthContainers = function (chart, cellWidth) {
    var cellCount = $($planBody[chart]).data('cell-count');
    var width = cellWidth * cellCount;
    $($planBody[chart]).width(width);
    $($planHeadWrap[chart]).width(width);
  };

  var onClickWrap = function (evt) {
    var $cell = $(evt.target).hasClass('js-plan-cell') ? $(evt.target) : $(evt.target).closest('.js-plan-cell');
    var row = $cell.data('row');
    var cell = $cell.data('cell');

    if (!stateLevel) {
      $plan.addClass('plan--level');

      var scrLeft = cell * cellWidthBig;
      var scrTop = (row-3) * cellHeigthBig;

      $planWrap
        .scrollLeft(scrLeft)
        .scrollTop(scrTop);

      setWidthContainers(currentChart, cellWidthBig);
      openChart(currentChart);

      stateLevel = true;
      $planNavOverview.removeClass('active');
    } else {
      if ($cell.hasClass('plan__cell--empty')) return;

      $planModal
        .modal('show')
        .on('shown.bs.modal', function () {
          $body.removeClass('modal-open').css({paddingRight: 0});
          $planSlider.slick('slickRemove', true, true, true);
          $planSlider.slick('slickAdd', '<div class="slider__item">' +
            '<div class="slider__img">' +
            '<img data-lazy="assets/media-demo/properties/1740x960/02.jpg" src="assets/img/lazy-image.jpg" alt=""></div>' +
            '</div><div class="slider__item">' +
            '<div class="slider__img"><img data-lazy="assets/media-demo/properties/1740x960/03.jpg" src="assets/img/lazy-image.jpg" alt=""></div>' +
            '</div>' +
            '<div class="slider__item">' +
            '<div class="slider__img"><img data-lazy="assets/media-demo/properties/1740x960/11.jpg" src="assets/img/lazy-image.jpg" alt=""></div>' +
            '</div>' +
            '<div class="slider__item">' +
            '<div class="slider__img"><img data-lazy="assets/media-demo/properties/1740x960/11.jpg" src="assets/img/lazy-image.jpg" alt=""></div>' +
            '</div>' +
            '<div class="slider__item">' +
            '<div class="slider__img"><img data-lazy="assets/media-demo/properties/1740x960/11.jpg" src="assets/img/lazy-image.jpg" alt=""></div>' +
            '</div>'
          );

          $planSliderTotal.text(5);
          $planSliderCurrent.text('1 /');

        });
    }
  };

  initChart();
  setWidthContainers(currentChart, cellWidth);
  openChart(currentChart);



  $planWrap
    .on('scroll', function () {
      var scrLeft = $planWrap.scrollLeft();
      var scrTop = $planWrap.scrollTop();

      $planHead.scrollLeft(scrLeft);
      $planNumber.scrollTop(scrTop);
    })
    .on('mousedown', function (evt) {
      $planWrap.on('mouseup mousemove', function handler(evt) {
        if (evt.type === 'mouseup') {
          // click
          onClickWrap(evt);
        } else {
          // drag
          console.log('drag');
          stateMousemove = true;
        }
        $planWrap.off('mouseup mousemove', handler);
      });
    })
    .on('mouseup', function (evt) {
      console.log('mouseup');
      stateMousemove = false;
    });

  $planNavOverview.on('click', function () {
    $(this).toggleClass('active');
    $plan.toggleClass('plan--level');
    stateLevel = !stateLevel;

    var width = stateLevel ? cellWidthBig : cellWidth;
    setWidthContainers(currentChart, width);

  });

  $planNav.on('click', function () {
    var $this = $(this);
    $planNav.removeClass('active');
    $this.addClass('active');
    currentChart = $this.data('chart');

    var width = stateLevel ? cellWidthBig : cellWidth;
    setWidthContainers(currentChart, width);
    openChart(currentChart);
  });
};
