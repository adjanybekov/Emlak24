"use strict";
(function ($) {
    /***************************************************************
     * Enables javascript support for theme
     ==============================================================*/
    app.initTheme({
        // Please update this options if you changes theme color scheme
        colorTheme: 'blue-orange_red',
        /** By default all svg icons are inlined at the beggining of
         * the <body> tag. If you would like to remove that inlined
         * data from the template, please set this to true.
         ==============================================================*/
        loadSvgWithAjax: true
    });
    /***************************************************************
     * Enables fixed menu
     * Enables fixed search bar in mobile view
     *
     * To disable this just comment out
     ==============================================================*/
    app.activateHeaderSpy();

    /***************************************************************
     * Enables "Scroll to top" button
     *
     * To disabled this just comment out and remove the corresponding
     * code from templates
     ==============================================================*/
    app.activateScrollToTopSpy();

    app.scrollAnimation();

    /***************************************************************
     * Panel useful for development, where you can
     * enable or disable various theme features.
     *
     * Usually, this should be disabled on live website.
     ==============================================================*/
    //app.activateUIPanel();

    /**
     * See more options
     * https://developers.google.com/maps/documentation/javascript/reference#MapOptions
     */
    var mapOptions = {
        zoom: 7,
        center: new google.maps.LatLng(50.1231277, 8.4964826),
        // Disable scrolling wheel for usability purposes
        scrollwheel: false,
        zoomControl: true,
        mapTypeControl: true,
        autocomplete: {
            //componentRestrictions: {'country': 'de'}
        },
        mapTypeControlOptions: {
            position: google.maps.ControlPosition.LEFT_TOP
        },
        zoomControlOptions: {
            position: google.maps.ControlPosition.RIGHT_CENTER
        },
        scaleControl: true,
        scaleControlOptions: {
            position: google.maps.ControlPosition.RIGHT_TOP
        },
        panControl: true,
        panControlOptions: {
            position: google.maps.ControlPosition.RIGHT_TOP
        }
    };

    if ($('#map-container').length) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/en/Property/GetProperties",
            dataType: "json",
            success: function (data) {
                initIndexMap('.js-map-index-canvas', data);
            }
        });
    }


    initPlyr('.player');
    initPartnersSlider('#partners-slider');
    initSelect2('select.form-control');

    initGallery('.js-gallery-item');
    initReviewSlider('#review-slider');
    initMainBanner('.js-banner');
    initWideSlider('#slider-wide');
    initBannerSlider('.js-banner-slider');
    initBannerSliderAndThumbs('.js-slider-thumbs');
    initRangeSliders();
    initSlider('.js-slick-blog');
    initSlider('.js-slick-plan');
    initSlider('#counter-slider');
    initSlider('#properties-banner');
    initBtnDemo('.js-btn-demo');
    initPopovers('.js-popover');
    initGeocoderGoogleMap('.js-map-location-dashboard-submit', { lat: 37.7749295, lng: -122.41941550000001 });
    initGeocoderGoogleMap('.js-map-location-dashboard', { lat: 37.7749295, lng: -122.41941550000001 });
    initGeocoderGoogleMap('.js-map-location-dashboard-hidden', { lat: 37.7749295, lng: -122.41941550000001 });
    initPropertyMapAndPanorama('.js-map-canvas[data-type="map"]', '.js-map-canvas[data-type="panorama"]');

    if ($('.datetimepicker').length) {
        $(function () {
            $('.datetimepicker').datetimepicker({
                locale: $(this).data("date-lacale")
            });
        });
    }


    function initGallery(container) {
        /**
         * Setup image popups with Photoswipe plugin
         * See documentation in http://photoswipe.com/documentation/options.html
         ==============================================================*/
        var $galleryItem = $(container);
        if (!$galleryItem.length) return;
        var gallery = app.createPhotoSwipe(container,
          {
              /*
               See here available options
               http://photoswipe.com/documentation/options.html
               */
          }
        );
    }

    function initSelect2(container) {

        /**
         * Setup select form fields improved with Select2 plugin
         * See documentation in https://select2.github.io
         ==============================================================*/
        var $inSelect = $(container);
        var $inWidgetsSelect = $('.widget select');
        if ($inSelect.length) $inSelect.select2({ width: '100%' });
        if ($inWidgetsSelect.length) $inWidgetsSelect.select2({ width: '100%' });
    }

    function initPartnersSlider(container) {
        /**
         * Slick slider for "Our partners" block
         * See documentation for options http://kenwheeler.github.io/slick/
         ==============================================================*/
        var $partnersSlider = $(container);
        if (!$partnersSlider.length) return;

        $partnersSlider
          .find('.js-slick-slider')
          .slick({
              dots: false,
              infinite: true,
              speed: 300,
              slidesToShow: 5,
              autoplay: true,
              accessibility: false,
              prevArrow: $partnersSlider.find('.js-partners-prev'),
              nextArrow: $partnersSlider.find('.js-partners-next'),
              responsive: [
                {
                    breakpoint: 1100,
                    settings: {
                        slidesToShow: 4
                    }
                },
                {
                    breakpoint: 1000,
                    settings: {
                        slidesToShow: 3
                    }
                },
                {
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 1
                    }
                }
              ]
          });
    }

    function initPlyr(container) {
        /***************************************************************
         * Plyr initialization for displaying html5 video
         * If you don't plan to have html5 video on the website,
         * you can remove this
         * Documentation https://github.com/selz/plyr
         ==============================================================*/
        var $player = $(container);
        if (!$player.length) return;
        plyr.setup();
        //
        //$('.js-player-play').on('click', function () {
        //  $(this).closest('.player')[0].plyr.play();
        //  $(this).hide();
        //});
    }

    function initReviewSlider(container) {
        /***************************************************************
         * Initialize sliders for user reviews
         * See http://kenwheeler.github.io/slick/ for more options
         ==============================================================*/
        var $reviewSlider = $(container);
        if (!$reviewSlider.length) return;
        $reviewSlider
          .find('.js-slick-slider')
          .slick({
              dots: true,
              infinite: true,
              speed: 800,
              slidesToShow: 1,
              autoplay: true,
              autoplaySpeed: 5000
          });
    }

    function initMainBanner(container) {
        var $container = $(container);
        if (!$container.length) return;

        var $searchForm = $container.find('.js-search-form');
        var $header = $('.header');
        var $headerNav = $('#header-nav');
        var $mainBannerMap = $container.find('.map');

        /***************************************************************
         * Initialize banner animation
         * Just add class start animation on document ready
         ==============================================================*/

        $container.addClass('banner--play');
        $searchForm.on('formChange', _.throttle(showMap, 500));
        initBannerLineAnimation(container);
        initIndexMap('.js-map-index-canvas');

        var stateOpenedMap = false;

        function showMap() {
            if (stateOpenedMap) return;
            if (app.gridSize.get() === 'lg') {
                requestAnimationFrame(function () {
                    if ($headerNav.hasClass('navbar--overlay')) {
                        $header.addClass('header--white');
                        $headerNav.addClass('navbar--overlay-map');
                    }
                    $mainBannerMap.addClass('opened');
                    $searchForm.addClass('form--white');
                    stateOpenedMap = true;
                });
            }
        }
    }

    function initBannerLineAnimation(container) {
        /***************************************************************
         * Initialize line animation
         * See https://github.com/maxwellito/vivus for more options
         ==============================================================*/
        if (!$('#banner-line').length) return;
        var $container = $(container);
        var $searchForm = $container.find('.js-search-form');

        new app.Vivus('banner-line', { type: 'async', start: 'autostart', ignoreInvisible: false, duration: 50 }, function () {
            var $sliderItem = $('#banner-line').closest('.slider__item');
            if ($sliderItem.hasClass('slick-slide') && !$sliderItem.hasClass('slick-active')) return;
            $container.find('.js-arrow-end').css({ opacity: 1 });
            $searchForm.addClass('form--anim');
        });
    }

    function initWideSlider(container) {
        /***************************************************************
         * Initialize sliders on the frontpage
         * See http://kenwheeler.github.io/slick/ for more options
         ==============================================================*/
        var $wideBanner = $(container);
        if (!$wideBanner.length) return;
        var $wideBannerSlider = $wideBanner.find('.js-slick-slider');


        $wideBannerSlider
          .slick({
              dots: false,
              infinite: true,
              speed: 300,
              slidesToShow: 1,
              lazyLoad: 'progressive',
              prevArrow: $wideBanner.find('.js-banner-prev'),
              nextArrow: $wideBanner.find('.js-banner-next'),
              responsive: [
                {
                    breakpoint: 1300,
                    settings: {
                        centerMode: false,
                        variableWidth: false,
                        arrows: true
                    }
                }
              ]
          });
        $wideBannerSlider.on('setPosition', function (event, slick) {
            $wideBanner.addClass('slider--init');
        });
    }

    function initBannerSlider(container) {
        /***************************************************************
         * Initialize sliders on the frontpage
         * See http://kenwheeler.github.io/slick/ for more options
         ==============================================================*/
        if (app.gridSize.get() === 'xs') return;
        var $banner = $(container);
        var $bannerSlider = $banner.find('.js-slick-slider');

        $bannerSlider
          .slick({
              dots: true,
              infinite: true,
              autoplay: true,
              autoplaySpeed: 3000,
              speed: 600,
              slidesToShow: 1,
              lazyLoad: 'progressive',
              accessibility: false,
              arrows: false,
              focusOnSelect: false
          });
    }

    function initBannerSliderAndThumbs(container) {
        /***************************************************************
         * Slider for blog pages
         * See http://kenwheeler.github.io/slick/ for more options
         ==============================================================*/
        var $sliders = $(container);
        if (!$sliders.length) return;
        var $sliderNavSlick, $sliderSlick, _$sliderNavSlickCache;
        $sliders.each(function () {
            var $sliderContainer = $(this);
            var $sliderSlick = $sliderContainer.find('.js-slick-slider');
            var $sliderNavContainer = $sliderContainer.siblings('.slider');
            $sliderNavSlick = $sliderNavContainer.find('.js-slick-slider');

            $sliderSlick
              .slick({
                  dots: false,
                  infinite: true,
                  speed: 300,
                  slidesToShow: 1,
                  centerMode: false,
                  arrows: false,
                  accessibility: false,
                  fade: true
              });

            _$sliderNavSlickCache = $sliderNavSlick.html();
            $sliderNavSlick
              .slick({
                  slidesToShow: 5,
                  slidesToScroll: 1,
                  focusOnSelect: true,
                  arrows: true,
                  accessibility: false,
                  centerMode: true,
                  centerPadding: 0,
                  prevArrow: $sliderNavContainer.find('.js-slick-prev'),
                  nextArrow: $sliderNavContainer.find('.js-slick-next'),
                  responsive: [
                    {
                        breakpoint: 768,
                        settings: {
                            slidesToShow: 3
                        }
                    }
                  ]
              });

            var $sliderCategories = $('.js-slider-category');
            var firstRun = true;
            var slideRel;
            $sliderCategories.on('click', function () {
                $sliderCategories.removeClass('active');
                $(this).addClass('active');
                var slides;
                var param = $(this).data('filter');

                $sliderNavSlick.slick('slickRemove', true, true, true);
                if (param === 'all') {
                    slides = _$sliderNavSlickCache;
                } else {
                    slides = $(_$sliderNavSlickCache).filter('.slider__item--' + param);
                }
                $sliderNavSlick.slick('slickAdd', slides);


                slideRel = $sliderNavSlick.find('.slick-current').data('slide-rel');
                $sliderSlick.slick('slickGoTo', slideRel, false);
            });

            // On before slide change
            $sliderNavSlick
              .on('afterChange', function (event, slick, currentSlide, nextSlide) {
                  slideRel = $sliderNavSlick.find('.slick-current').data('slide-rel');
                  $sliderSlick.slick('slickGoTo', slideRel, false);
              })
              .on('click', '.slider__item', function () {
                  var item = $(this);
                  slideRel = $(item).data('slide-rel');
                  $sliderSlick.slick('slickGoTo', slideRel, false);
              });

        });



    }



    function initRangeSliders() {
        /***************************************************************
         * Example usage of range sliders that replace the
         * price/rooms/area "from" and "to" fields
         *
         * For documentation
         * and options see https://github.com/IonDen/ion.rangeSlider
         ==============================================================*/
        var $rangeArea = $("#range_area");
        var $rangePrice = $("#range_price");
        var $rangedNumbers = $(".ranged_numbers");
        var $rangeCommision = $("#range_commision");
        var $rangeRoom = $("#range_room");
        var $rangeUi = $("#range_ui");
        var $rangeNumberOfPeople = $("#range_max_num_of_people");
        var $rangeMaxIncome = $("#range_max_income");
        var $rangeMaxAgeOfChildren = $("#range_max_age_of_children");
        var $rangeMaxAgeOfPeople = $("#range_max_age_of_people");
        var $rangeMaxNumOfChildren = $("#range_max_num_of_children");
        var $durationRange = $("#duration_range");
        var $singleSliders = $(".wt24-slider");

        if ($singleSliders.length) {
            $singleSliders.ionRangeSlider({
                min: 0,
                hide_min_max: true,
                hide_from_to: false,
                grid: true,
                force_edges: false,
                step: 1,
                max_postfix: '+',
                onFinish: app.rangeInputInteraction
            });
        }

        if ($rangeArea.length) {
            $rangeArea.ionRangeSlider({
                type: "double",
                min: 0,
                max: 2000,
                hide_min_max: true,
                hide_from_to: false,
                grid: false,
                postfix: 'm<sup>2</sup>',
                force_edges: true,
                step: 10,
                max_postfix: '+',
                onFinish: app.rangeInputInteraction
            });
        }

        if ($rangeNumberOfPeople.length) {
            $rangeNumberOfPeople.ionRangeSlider({
                type: "single",
                min: 0,
                max: 10,
                hide_min_max: true,
                hide_from_to: false,
                grid: false,
                prefix: '',
                force_edges: true,
                max_postfix: '+',
                step: 1,
                onFinish: app.rangeInputInteraction
            });
        } if ($rangeMaxAgeOfChildren.length) {
            $rangeMaxAgeOfChildren.ionRangeSlider({
                type: "single",
                min: 0,
                max: 10,
                hide_min_max: true,
                hide_from_to: false,
                grid: false,
                prefix: '',
                force_edges: true,
                max_postfix: '+',
                step: 1,
                onFinish: app.rangeInputInteraction
            });
        } if ($rangeMaxAgeOfPeople.length) {
            $rangeMaxAgeOfPeople.ionRangeSlider({
                type: "single",
                min: 0,
                max: 120,
                hide_min_max: true,
                hide_from_to: false,
                grid: false,
                prefix: '',
                force_edges: true,
                max_postfix: '+',
                step: 1,
                onFinish: app.rangeInputInteraction
            });
        } if ($rangeMaxNumOfChildren.length) {
            $rangeMaxNumOfChildren.ionRangeSlider({
                type: "single",
                min: 0,
                max: 10,
                hide_min_max: true,
                hide_from_to: false,
                grid: false,
                prefix: '',
                force_edges: true,
                max_postfix: '+',
                step: 1,
                onFinish: app.rangeInputInteraction
            });
        } if ($durationRange.length) {
            $durationRange.ionRangeSlider({
                type: "single",
                min: 3,//month
                max: 48, //month == 4 years
                hide_min_max: true,
                hide_from_to: false,
                grid: false,
                prefix: '',
                force_edges: true,
                max_postfix: '+',
                step: 1,
                onFinish: app.rangeInputInteraction
            });
        }
        if ($rangeMaxIncome.length) {
            $rangeMaxIncome.ionRangeSlider({
                type: "single",
                min: 100,
                max: 5000,
                hide_min_max: true,
                hide_from_to: false,
                grid: false,
                prefix: '&euro;',
                force_edges: true,
                max_postfix: '+',
                step: 1,
                onFinish: app.rangeInputInteraction
            });
        }

        if ($rangePrice.length) {
            $rangePrice.ionRangeSlider({
                type: "double",
                min: 0,
                max: 5000000,
                hide_min_max: true,
                hide_from_to: false,
                grid: false,
                prefix: '&euro;',
                force_edges: true,
                max_postfix: '+',
                step: 1000,
                onFinish: app.rangeInputInteraction
            });
        }

        if ($rangedNumbers.length) {
            $rangedNumbers.each(function() {
                $(this).ionRangeSlider({
                    type:'double',
                    hide_min_max: true,
                    hide_from_to: false,
                    grid: true,
                    prefix: '',
                    force_edges: false,
                    max_postfix: '+',
                    step: 1,
                    prettify_enabled: false,
                    keyboard:true,
                    onFinish: app.rangeInputInteraction
                });
            });
        }

        if ($rangeRoom.length) {
            $rangeRoom.ionRangeSlider({
                type: "double",
                min: 0,
                max: 10,
                from: 0,
                to: 10,
                hide_min_max: true,
                hide_from_to: false,
                grid: false,
                max_postfix: '+',
                onFinish: app.rangeInputInteraction
            });
        }

        if ($rangeCommision.length) {
            $rangeCommision.ionRangeSlider({
                type: "double",
                min: 0,
                max: 10000,
                from: 0,
                to: 10000,
                hide_min_max: true,
                hide_from_to: false,
                grid: false,
                max_postfix: '+',
                prefix: 'RM ',
                onFinish: app.rangeInputInteraction
            });
        }

        if ($rangeUi.length) {
            $rangeUi.ionRangeSlider({
                type: "double",
                min: 1000,
                max: 2000,
                from: 1200,
                to: 1800,
                hide_min_max: true,
                hide_from_to: false,
                grid: false,
                onFinish: app.rangeInputInteraction
            });
        }

    }

    function initSlider(container) {
        /***************************************************************
         * Slider for blog pages
         * See http://kenwheeler.github.io/slick/ for more options
         ==============================================================*/
        var $blogSliders = $(container);
        if (!$blogSliders.length) return;

        $blogSliders.each(function () {
            var $sliderContainer = $(this),
              $sliderCurrent = $sliderContainer.find('.js-slick-current'),
              $sliderTotal = $sliderContainer.find('.js-slick-total');


            $sliderContainer
              .find('.js-slick-slider')
              .on('init', function (event, slick) {
                  $sliderTotal.html(slick.slideCount);
              })
              .slick({
                  dots: false,
                  infinite: true,
                  speed: 300,
                  slidesToShow: 1,
                  centerMode: false,
                  prevArrow: $sliderContainer.find('.js-slick-prev'),
                  nextArrow: $sliderContainer.find('.js-slick-next')
              })
              .on('afterChange', function (event, slick, currentSlide) {
                  $sliderCurrent.html(currentSlide + 1 + ' /');
              });
        });
    }

    function initGoogleMap(container, location) {
        /**
         * Google map initialization
         ==============================================================*/

        var $mapCanvas = $(container);
        if (!$mapCanvas.length) return;

        (function () {
            // We're using here sample coordinates, please replace them with real ones
            var coordinates = new google.maps.LatLng(location.lat, location.lng);
            // Default map zoom
            // jQuery object with map container

            var $mapBtn = $('.js-map-btn');


            /**
             * This is a wrapper around original Google Maps object,
             * which brings some user experience improvements for mobile users,
             * So that, when user loads the map on small-screen device, it
             * is replaced by a button, clicking on it will open full screen
             * popup with the map in it.
             *
             * If you don't want/need that, you can call `google.maps.Map` contructor directly
             *
             * See https://developers.google.com/maps/documentation/javascript/
             * for more examples and options
             */
            app.createMap(
              // Map container
              $mapCanvas,

              // A button, clicking on which will display the map in a fullscreen popup on small screens
              $mapBtn,

              /**
               * This callback is executed when the Google Map is loaded
               * As first agrument it receives the google map object
               *
               * Please place here all the code that needs the google map object
               */
              function () {
                  var map = new google.maps.Map($mapCanvas[0], _.merge(mapOptions, { zoom: 7, coordinates: coordinates }));

                  /**
                   * app.createMarker is a helper which contains
                   * preconfigured Marker object (see docs https://developers.google.com/maps/documentation/javascript/markers)
                   *
                   * If you want something more sophisticated, please use these libraries directly
                   */
                  app.createGmapMarker.create(
                    map,
                    coordinates,
                    location.address
                  );
              });
        })();
    }


    function initBtnDemo(selector) {
        /***************************************************************
         * Button interaction demo
         * See feature_ui.html (Full button interaction) for dempnstration
         *
         * This feature is useful for displaying visual feedback
         * to users that interact with long-running requests like:
         * - credit card processing
         * - waiting in the queue
         * - or simple ajax form submit
         ==============================================================*/
        var $buttons = $(selector);
        if (!$buttons.length) return;
        $buttons.on('click', function () {
            var $btn = $(this);
            var state = $btn.data('state') || 'success';

            $btn.addClass('loading');
            setTimeout(function () {
                $btn.addClass('progress');
            }, 500);
            setTimeout(function () {
                $btn.removeClass('loading');
                $btn.removeClass('progress');
                $btn.addClass(state);
            }, 1000);
            return false;
        });
    }

    /***************************************************************
     * Initialize map on index page
     * @param {object} container sdfsdfdsf
     * @param {object} properties
     ==============================================================*/
    function initIndexMap(container, properties) {
        var $mapCanvas = $(container);
        if (!$mapCanvas.length) return;
        // Temporary array for storing markers for clustering
        var markers = [];

        /**
         * This is a wrapper around original Google Maps object,
         * which brings some user experience improvements for mobile users,
         * So that, when user loads the map on small-screen device, it
         * is replaced by a button, clicking on it will open full screen
         * popup with the map in it.
         *
         * If you don't want/need that, you can call `google.maps.Map` contructor directly
         *
         * See https://developers.google.com/maps/documentation/javascript/
         * for more examples and options
         */
        requestAnimationFrame(function () {
            app.createMap(
              // Map container
              $mapCanvas,

              // A button, clicking on which will display the map in a fullscreen popup on small screens
              $('.js-map-btn'),

              /**
               * This callback is executed when the Google Map is loaded
               * As first agrument it receives the google map object
               *
               * Please place here all the code that needs the google map object
               */
              function () {

                  var map = new google.maps.Map($mapCanvas[0], mapOptions);
                  markers = [];
                  // Loop over demo properties to create markers over map
                  _.each(properties, function (item) {
                      var infoboxHtml = generateMarkerHtml(item);

                      /**
                       * app.createInfoboxMarker is a helper which contains:
                       * - preconfigured Marker object (see docs https://developers.google.com/maps/documentation/javascript/markers)
                       * - preconfigured Infobox object (see docs http://google-maps-utility-library-v3.googlecode.com/svn/trunk/infobox/docs)
                       * to make sure they work and look good with our theme.
                       *
                       * If you want something more sophisticated, please use these libraries directly
                       */
                      var marker = app.createGmapInfoboxMarker(
                        map,
                        new google.maps.LatLng(item.lat, item.lng),
                        item.address,
                        infoboxHtml,
                        // You can pass directly the 'white' or 'dark' value or get it some other way
                        $mapCanvas.data('infoboxTheme')
                      );
                      // Save the created marker for later use for clustering
                      markers.push(marker);
                  });

                  /**
                   * Wrapper object for MarkerClustererPlus library preconfigured to work with our theme
                   * See http://google-maps-utility-library-v3.googlecode.com/svn/trunk/markerclustererplus/docs/reference.html
                   * for examples
                   *
                   * You can use it directly instead of wrapper if you want to customizer its options
                   * Remove this if you don't want to cluster properties.
                   */
                  app.createGmapClustering(map, markers);
              });
        });

    }

    function initPopovers(container) {
        /**
         * Popover example
         * Docs http://getbootstrap.com/javascript/#popovers
         ==============================================================*/

        var $popovers = $(container);
        if (!$popovers.length) return;
        $popovers.popover();
    }

    function initGeocoderGoogleMap(container, coordinates) {
        var $map = $(container);
        if (!$map.length) return;
        /** Helper to create a Google Map that:
         * - provides a draggable marker
         * - syncs marker position to the Lat and Long fields
         * - provides a autocomplete fields with locations
         ==============================================================*/
        var $triggerButton = $('.js-map-btn');
        var $mapCanvas = $map.find('.js-map');
        app.createMap(
          $mapCanvas,
          $triggerButton,
          function () {
              var map, marker,
                geocoder,
                $autocompleteAddress = $map.find('.js-autocomplete'),
                $locationCoords = $map.find('.js-location-coords'),
                $btnRemoveOverlays = $map.find('.js-remove-overlays'),
                stateMapInit = false;

              geocoder = new google.maps.Geocoder();

              mapOptions.zoom = 15;
              map = new google.maps.Map($mapCanvas[0], mapOptions);

              if ($.isNumeric($locationCoords[0].value) && $.isNumeric($locationCoords[1].value)) {
                  mapOptions.center = new google.maps.LatLng($locationCoords[0].value, $locationCoords[1].value);
                  map.panTo(mapOptions.center);
                  placeMarker(mapOptions.center);
                  if (marker) {
                      marker.setPosition(mapOptions.center); //on change sa position
                  } else {
                      addMapMarker(mapOptions.center);
                  }
              }

              google.maps.event.addListener(map, 'click', function (event) {
                  placeMarker(event.latLng);
              });

              app.geolocation.activate(map, {
                  buttonTrigger: $map.find('.js-geolocate'),
                  onSuccess: function (latLng) {
                      placeMarker(latLng);
                  }
              });

              function placeMarker(location) {
                  if (marker) {
                      marker.setPosition(location); //on change sa position
                  } else {
                      addMapMarker(location.lat(), location.lng());
                  }
                  setCoordinatesFiled(location.lat(), location.lng());
                  getAddress(location);
              }

              function getAddress(latLng) {
                  geocoder.geocode({ 'latLng': latLng },
                    function (results, status) {
                        if (status === google.maps.GeocoderStatus.OK) {
                            if (results[0]) {
                                $autocompleteAddress[0].value = results[0].formatted_address;
                            }
                            else {
                                $autocompleteAddress[0].value = "No results";
                            }
                        }
                        else {
                            $autocompleteAddress[0].value = status;
                        }
                    });
              }

              // Create the autocomplete object and associate it with the UI input control.
              // Restrict the search to the default country, and to place type "cities".
              var autocomplete = new google.maps.places.Autocomplete(
                /** @type {HTMLInputElement} */$autocompleteAddress[0],
                mapOptions.autocomplete);

              google.maps.event.addListener(autocomplete, 'place_changed', onPlaceChanged);

              $autocompleteAddress.on('keypress', function (e) {
                  if (e.keyCode === 13) return false;
              });


              // When the user selects a city, get the place details for the city and
              // zoom the map in on the city.
              function onPlaceChanged() {
                  var place = autocomplete.getPlace();
                  if (place.geometry) {
                      map.panTo(place.geometry.location);
                      // change zoom map only if user did not change it before
                      map.setZoom(15);
                      if (marker) {
                          var markerCoords = new google.maps.LatLng(place.geometry.location.lat(), place.geometry.location.lng());
                          marker.setPosition(markerCoords); //on change sa position
                      } else {
                          addMapMarker(place.geometry.location.lat(), place.geometry.location.lng());
                      }
                      setCoordinatesFiled(place.geometry.location.lat(), place.geometry.location.lng());
                  } else {
                      autocomplete.placeholder = 'Enter a address';
                  }

              }

              // create marker on map
              function addMapMarker(lat, lng) {
                  var markerCoords = new google.maps.LatLng(lat, lng);

                  marker = app.createGmapMarker.createAdvanced({
                      position: markerCoords,
                      map: map,
                      draggable: true
                  });

                  google.maps.event.addListener(marker, 'dragend', function () {
                      placeMarker(marker.getPosition());
                  });
              }

              // set coordinates in fileds
              function setCoordinatesFiled(lat, lng) {
                  $locationCoords[0].value = lat;
                  $locationCoords[1].value = lng;
              }

              function removeOverlays() {
                  var overlays;
                  for (var i = 0; i < overlays.length; i++) {
                      overlays[i].overlay.setMap(null);
                  }
                  overlays = [];
              }

              var drawingManager = new google.maps.drawing.DrawingManager({
                  //drawingMode: google.maps.drawing.OverlayType.MARKER,
                  drawingControl: true,
                  drawingControlOptions: {
                      position: google.maps.ControlPosition.TOP_RIGHT,
                      drawingModes: [
                        google.maps.drawing.OverlayType.POLYGON
                      ]
                  }
              });

              if (!stateMapInit) {
                  drawingManager.setMap(map);
              }


              google.maps.event.addListener(drawingManager, 'overlaycomplete', function (e) {
                  overlays.push(e);
              });


              $locationCoords.on('input', function (e) {
                  if ($.isNumeric($locationCoords[0].value()) && $.isNumeric($locationCoords[1].value())) {
                      var latlng = new google.maps.LatLng($locationCoords[0].value(), $locationCoords[1].value());
                      if (marker) {
                          marker.setPosition(latlng); //on change sa position
                      } else {
                          addMapMarker(latlng.lat(), latlng.lng());
                      }
                      map.panTo(latlng);
                      getAddress(latlng);
                      if (e.keyCode === 13) return false;
                  }
              });

              $btnRemoveOverlays.on('click', function () {
                  removeOverlays();
              });

          }
        );

    }
    function initPropertyMapAndPanorama(containerMap, containerPanorama) {
        var property = {
            lat: $(containerMap).data("lat"),
            lng: $(containerMap).data("lng"),
            address: $(containerMap).data("address"),
            image:$(containerMap).data("image"),
            type:$(containerMap).data("property-type"),
            area:$(containerMap).data("area"),
            price: $(containerMap).data("price")
        };
        // jQuery object with map container
        var $mapCanvas = $(containerMap);
        var $panoramaCanvas = $(containerPanorama);
        if (!$mapCanvas.length || !$panoramaCanvas) return;
        // We're using here sample coordinates, please replace them with real ones
        var coordinates = new google.maps.LatLng(property.lat, property.lng);
        // Default map zoom
        var $mapBtn = $('.js-map-btn');
        var $panoramaBtn = $('.js-panorama-btn');
        var active;

        /**
         * This is a wrapper around original Google Maps object,
         * which brings some user experience improvements for mobile users,
         * So that, when user loads the map on small-screen device, it
         * is replaced by a button, clicking on it will open full screen
         * popup with the map in it.
         *
         * If you don't want/need that, you can call `google.maps.Map` contructor directly
         *
         * See https://developers.google.com/maps/documentation/javascript/
         * for more examples and options
         */
        app.createMap(
          // Map container
          $mapCanvas,

          // A button, clicking on which will display the map in a fullscreen popup on small screens
          $mapBtn,

          /**
           * This callback is executed when the Google Map is loaded
           * As first agrument it receives the google map object
           *
           * Please place here all the code that needs the google map object
           */
          function () {
              var map = new google.maps.Map($mapCanvas[0], _.merge(mapOptions, { zoom: 7, coordinates: coordinates }));
              var infoboxHtml = generateMarkerHtmlDetail(property);

              /**
               * app.createInfoboxMarker is a helper which contains:
               * - preconfigured Marker object (see docs https://developers.google.com/maps/documentation/javascript/markers)
               * - preconfigured Infobox object (see docs http://google-maps-utility-library-v3.googlecode.com/svn/trunk/infobox/docs)
               * to make sure they work and look good with our theme.
               *
               * If you want something more sophisticated, please use these libraries directly
               */
              app.createGmapInfoboxMarker(
                map,
                coordinates,
                property.address,
                infoboxHtml,
                // You can pass directly the 'white' or 'dark' value or get it some other way
                $mapCanvas.data('infoboxTheme')
              );
              // Save the created marker for later use for clustering
          });

        /**
         * This is a wrapper around original Google Maps Panorama object,
         * which brings some user experience improvements for mobile users,
         * So that, when user loads the panorama on small-screen device, it
         * is replaced by a button, clicking on it will open full screen
         * popup with the panorama in it.
         *
         * If you don't want/need that, you can call `google.maps.StreetViewPanorama` contructor directly
         *
         * See https://developers.google.com/maps/documentation/javascript/
         * for more examples and options
         */
        app.createMap(
          // Map container
          $panoramaCanvas,

          // A button, clicking on which will display the map in a fullscreen popup on small screens
          $panoramaBtn,
          function () {
              var map = new google.maps.StreetViewPanorama($panoramaCanvas[0], {
                  position: coordinates,
                  pov: {
                      heading: 34,
                      pitch: 10
                  },
                  zoomControl: true,
                  zoomControlOptions: {
                      position: google.maps.ControlPosition.RIGHT_CENTER
                  },
                  panControl: true,
                  panControlOptions: {
                      position: google.maps.ControlPosition.RIGHT_TOP
                  }
              });
          }
        );


        active = $mapBtn.add($panoramaBtn).filter('.active');
        var toggleActive = function (newActive) {
            if (active) {
                active.removeClass('active');
            }
            active = $(newActive);
            active.addClass('active');
        };

        $mapBtn.on('click', function () {
            if (app.gridSize.get() === 'xs') return;
            toggleActive(this);
            $panoramaCanvas.css({ zIndex: 5 });
            $mapCanvas.css({ zIndex: 10 });
        });
        $panoramaBtn.on('click', function () {
            if (app.gridSize.get() === 'xs') return;
            toggleActive(this);
            $panoramaCanvas.css({ zIndex: 10 });
            $mapCanvas.css({ zIndex: 5 });
        });
    }
    // Simple helper for generating html content for infoboxes
    function generateMarkerHtml(data) {
        var link;
        link = "en/Image/GetImage/" + data.image;
        return "<span class='map__address'>" +
            data.address +
            "</span> <span class='map__info'>" +
            "<img class='map__photo' src='" +link +"'/><span class='map__details'> " +
            "<dl><dt>Type:</dt> <dd>" +
            data.type +
            "</dd></dl>" +
            "<dl><dt>Area:</dt> <dd>" +
            data.area +
            " m<sup>2</sup></dd></dl>" +
            //"<dl><dt>Bedrooms:</dt> <dd>" + data.bedrooms + "</dd></dl>" +
            "</span></span> <span class='map__price'><strong>$" +
            data.price +
            "</strong></span> <a  class='map__more' href='" +
            data.detailUrl +
            "'>Details</a>";
    }
    function generateMarkerHtmlDetail(data) {
        var link;
        link = "/en/Image/GetImage/" + data.image;
        return "<span class='map__address'>" +
            data.address +
            "</span> <span class='map__info'>" +
            "<img  class='map__photo' src='" +link +"'/><span class='map__details'> " +
            "<dl><dt>Type:</dt> <dd>" +
            data.type +
            "</dd></dl>" +
            "<dl><dt>Area:</dt> <dd>" +
            data.area +
            " m<sup>2</sup></dd></dl>" +
            //"<dl><dt>Bedrooms:</dt> <dd>" + data.bedrooms + "</dd></dl>" +
            "</span></span> <span class='map__price'><strong>$" +
            data.price +
            "</strong></span>";
    }

    $(function() {
        $('[data-toggle="tooltip"]').tooltip();
    });

    $(function() {
        $('input[data-toggle="toggle"]')
            .each(function() {
                handleChanges(this);
            });
    });

    $(function () {
        $('input[data-toggle="toggle"]').change(function () {
            handleChanges(this);
        });
    });

    function handleChanges(elem) {
        var onIdToShow = $(elem).data('on-id-to-show');
        var onClassToShow = $(elem).data('on-class-to-show');
        var offIdToShow = $(elem).data('off-id-to-show');
        var offClassToShow = $(elem).data('off-class-to-show');
        var checked = $(elem).prop('checked');

        if (onIdToShow) {
            handleInputs('#', onIdToShow, !checked);
        }
        if (onClassToShow) {
            handleInputs('.', onClassToShow, !checked);
        }
        if (offIdToShow) {
            handleInputs('#', offIdToShow, checked);
        }
        if (offClassToShow) {
            handleInputs('.', offClassToShow, checked);
        }
    };

    function handleInputs(selector,elemIdOrClass, checked) {
        if ($(selector + elemIdOrClass).children().length > 0) {
            $(selector + elemIdOrClass + " :input").prop("disabled", checked);
        } else {
            $(selector + elemIdOrClass).prop("disabled", checked);
        }
        if (checked) {
            $(selector + elemIdOrClass).hide('slow');
        } else {
            $(selector + elemIdOrClass).show('slow');
        }
    }

    $(".wt24-link-confirmation").click(function (e) {
        e.preventDefault();
        var href = $(this).data('link');
        swal({
            title: $(this).data('title'),
            text: $(this).data('text'),
            type: "info",
            showCancelButton: true,
            closeOnConfirm: false,
            showLoaderOnConfirm: true,
        }, function () {
                return window.location.href = href;
            });
    });

    initSearch();
    var locationSelectionItems = $('.wt24-location-selection');
    locationSelectionItems.each(function () {
        var ddElement = $(this);
        ddElement.change(function () {
            var loadingElementContainer = $('#' + ddElement.data('loading-element-container'));
            loadingElementContainer.addClass("loading-overlay");
            if (!$(this).val()) {
                loadingElementContainer.removeClass("loading-overlay");
                return;
            }
            var request = $.ajax({
                url: '/en/Locations/GetLocationLevelTree',
                method: "GET",
                data: { id: $(this).val() },
                contentType: "application/json",
                dataType: "html"
            });
            request.done(function (data) {
                var targetDiv = $('#' + ddElement.data('target-div'));
                targetDiv.html(data);
                targetDiv.bonsai('update');
                loadingElementContainer.removeClass("loading-overlay");
                initSearch();

            });
            request.fail(function (jqXHR, textStatus) {
                alert("Request failed: " + textStatus);
                loadingElementContainer.removeClass("loading-overlay");
            });
        });
    });

        $('.js-select-checkboxes-reset').on('click', function () {
            var $this = $(this),
              $selectCheckboxesDropdown = $this.closest('.js-select-checkboxes');

            $selectCheckboxesDropdown
              .find('input[type="checkbox"]')
              .prop({
                  checked: false,
                  indeterminate: false
              });
            $selectCheckboxesDropdown
              .find('input[type="checkbox"]')
              .first()
              .trigger('change');

        });
        $('.js-select-checkboxes-accept').on('click', function () {
            var $this = $(this),
              $selectCheckboxesDropdown = $this.closest('.js-select-checkboxes');

            $selectCheckboxesDropdown
              .closest('.dropdown')
              .removeClass('open');
        });
        $('.js-form-reset').on('click', function () {
            $inputsText.val('');

            $inputsTextArea.text('');

            $inputsSelect.each(function (i, item) {
                $(item).find('option').removeAttr('selected');
                $(item).trigger('change');
            });

            $inputsCheckbox.prop({
                checked: false,
                indeterminate: false
            });

            // trigger event for custom menu dropdown
            $selectCheckboxesDropdown.each(function (i, selectCheckboxes) {
                $(selectCheckboxes)
                  .find('input[type="checkbox"]')
                  .first()
                  .trigger('change');
            });
            // reset range slider
            $rangeSliders.each(function (i, rangeSlider) {
                // Save slider instance
                var slider = $(rangeSlider).data("ionRangeSlider");
                // Call sliders reset method
                slider.reset();
            });

        });
        $('body').on('click', '.js-dropdown-menu', function (e) {
            e.stopPropagation();
        });

        var checkboxesTree = $('.js-checkboxes-tree');
        if (checkboxesTree.length) {
            checkboxesTree.bonsai();
            checkboxesTree.qubit();
        }

        function handleCheckedElements(locationsContainer, $showBtn) {
            var location = [];
            var $parentGroup = $(locationsContainer).closest('.js-select-checkboxes');
            $($parentGroup)
                .find('.in-checkbox:checked')
                .each(function () {
                    var $label = $("label[for='" + this.id + "']");
                    var name = $label.text();
                    if (location.length < 1 || !$parentGroup.data('single-select')) {
                        location.push(name);
                    } else {
                        swal("err", "choose one");
                        $(this).attr("checked", false);
                    }
                });
            var resultHtml = location.join(', ') || $($showBtn).data('placeholder');
            $($showBtn).text(resultHtml);
        };

        function initSearch() {
            var $container = $('.js-search-form');
            var $selectCheckboxes = $container.find('.js-select-checkboxes');

            $selectCheckboxes.each(function () {
                var $this = $(this);
                var $showBtn = $(this).prev('.js-select-checkboxes-btn');
                handleCheckedElements(this, $showBtn);
                $this.find('.in-checkbox').change(function () {
                    handleCheckedElements(this, $showBtn);
                });
            });
        }
})(jQuery);
