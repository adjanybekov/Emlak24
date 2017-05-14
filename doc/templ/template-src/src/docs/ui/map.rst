Map
===

Source
~~~~~~

Sass styles are in folder ``template_src/src/assets/sass/widgets/_form.sass`` .

Js source are in ``template_src/src/js/module/gmap`` .

Variations
~~~~~~~~~~

*
  ``<div class="map map--properties">`` - map on property details page

  .. image:: ../img/map--property-details.jpg

*
  ``<div class="map map--index">`` - map on page

  .. image:: ../img/map--index.png

*
 ``<div class="map map--contacts">`` - map on contacts

 .. image:: ../img/map--contacts.png

*
 ``<div class="map map--submit">`` - map on submit page

 .. image:: ../img/map--submit.jpg


Options
~~~~~~~

Initialize map on index page
----------------------------

.. code-block:: javascript

    /***************************************************************
     * Initialize map on index page
     ==============================================================*/
    function initIndexMap() {
        // Array with sample properties, used to display markers on the map
        var properties = window.demodata;
        // Default map zoom
        var zoom = 10;
        // We're using here sample coordinates, please replace them with real ones
        var coordinates = new google.maps.LatLng(33.74229160384012, -117.86845207214355);
        // jQuery object with map container
        var $mapCanvas = $('.js-map-index-canvas');
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
        app.createGoogleMap(
            // Map container
            $mapCanvas,

            /**
             * See more options
             * https://developers.google.com/maps/documentation/javascript/reference#MapOptions
             */
            {
                zoom: zoom,
                center: coordinates,
                // Disable scrolling wheel for usability purposes
                scrollwheel: false,
                zoomControl: true,
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
            },

            // A button, clicking on which will display the map in a fullscreen popup on small screens
            $('.js-map-btn'),

            /**
             * This callback is executed when the Google Map is loaded
             * As first agrument it receives the google map object
             *
             * Please place here all the code that needs the google map object
             */
            function (map) {
                markers = [];
                // Loop over demo properties to create markers over map
                _.each(properties, function (item) {
                    var infoboxHtml = generateMarkerHTML(item);

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
    }

Initialize map on preperty details page
---------------------------------------

.. code-block:: javascript

    function initPropertyMapAndPanorama() {
        // Getting first sample property to display marker for it
        var property = window.demodata[3];
        // We're using here sample coordinates, please replace them with real ones
        var coordinates = new google.maps.LatLng(property.lat, property.lng);
        // Default map zoom
        var zoom = 10;
        // jQuery object with map container
        var $mapCanvas = $('.js-map-canvas[data-type="map"]');
        var $panoramaCanvas = $('.js-map-canvas[data-type="panorama"]');

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
        app.createGoogleMap(
            // Map container
            $mapCanvas,

            /**
             * See more options
             * https://developers.google.com/maps/documentation/javascript/reference#MapOptions
             */
            {
                zoom: zoom,
                center: coordinates,
                // Disable scrolling wheel for usability purposes
                scrollwheel: false,
                zoomControl: true,
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
            },

            // A button, clicking on which will display the map in a fullscreen popup on small screens
            $mapBtn,

            /**
             * This callback is executed when the Google Map is loaded
             * As first agrument it receives the google map object
             *
             * Please place here all the code that needs the google map object
             */
            function (map) {
                var infoboxHtml = generateMarkerHTML(property);

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
        app.createGooglePanorama(
            // Map container
            $panoramaCanvas,

            /**
             * See more options
             * https://developers.google.com/maps/documentation/javascript/streetview#StreetViewMapUsage
             */
            {
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
            },

            // A button, clicking on which will display the map in a fullscreen popup on small screens
            $panoramaBtn);

        if (app.gridSize !== 'xs') {
            active = $mapBtn.add($panoramaBtn).filter('.active');
            $mapBtn.on('click', function () {
                toggleActive(this);
                $panoramaCanvas.css({zIndex: 5});
                $mapCanvas.css({zIndex: 10});
            });
            $panoramaBtn.on('click', function () {
                toggleActive(this);
                $panoramaCanvas.css({zIndex: 10});
                $mapCanvas.css({zIndex: 5});
            });

            function toggleActive(newActive) {
                if (active) {
                    active.removeClass('active');
                }
                active = $(newActive);
                active.addClass('active');
            }
        } else {
            $mapBtn.removeClass('active');
        }
    }

Initialize Leaflet map
----------------------

.. code-block:: js

    /***************************************************************
     * As an alternative to Google Maps, you can use Leaflet
     * which uses data from OSM and tiles from MapBox
     ==============================================================*/
    function initLeafletMap() {
        // Array with sample properties, used to display markers on the map
        var properties = window.demodata;
        // Default map zoom
        var zoom = 10;
        // We're using here sample coordinates, please replace them with real ones
        var coordinates = new L.LatLng(33.74229160384012, -117.86845207214355);
        // jQuery object with map container
        var $mapCanvas = $('.js-map-canvas');

        /*
         * This is a wrapper around original Leftlet map object,
         * which brings some user experience improvements for mobile users,
         *
         * If you don't want/need that, you can call ` L.map` contructor directly
         *
         * See http://leafletjs.com/reference.html
         * for more examples and options
         ==============================================================*/
        app.createLeafletMap(
            // Map container
            $mapCanvas,
            /* Leaftlet map options
             * http://leafletjs.com/reference.html#map-options
             ==============================================================*/
            {
                zoom: zoom,
                center: coordinates,
                zoomControl: false,
                // Disable scrolling wheel for usability purposes
                scrollWheelZoom: false
            },

            // A button, clicking on which will display the map in a fullscreen popup on small screens
            $('.js-map-btn'),

            /**
             * This callback is executed when the Leftlet is loaded
             * As first agrument it receives the Leftlet object
             *
             * Please place here all the code that needs the Leftlet object
             */
            function (map) {

                // Loop over demo properties to create markers over map
                _.each(properties, function (item) {
                    var infoboxHtml = generateMarkerHTML(item);

                    /**
                     * app.createLeafletInfoboxMarker is a helper which contains:
                     * - preconfigured Marker object (see docs http://leafletjs.com/reference.html#marker)
                     * - preconfigured Popup object (see docs http://leafletjs.com/reference.html#popup)
                     * to make sure they work and look good with our theme.
                     *
                     * If you want something more sophisticated, please use these objects directly
                     */
                    app.createLeafletInfoboxMarker(
                        map,
                        new L.LatLng(item.lat, item.lng),
                        item.address,
                        infoboxHtml,
                        // You can pass directly the 'white' or 'dark' value or get it some other way
                        $mapCanvas.data('infoboxTheme')
                    );
                });
            });
    }



Html content for infoboxes
--------------------------


.. code-block:: js

    // Simple helper for generating html content for infoboxes
    function generateMarkerHTML(data) {
        return "<span class='map__address'>" + data.address +
            "</span> <span class='map__info'>" +
            "<img  class='map__photo' src='assets/media-demo/properties/277x180/" + data.image +
            ".jpg'/><span class='map__details'> " +
            "<dl><dt>Type:</dt> <dd>" + data.type + "</dd></dl>" +
            "<dl><dt>Area:</dt> <dd>" + data.area + " m2</dd></dl>" +
            "<dl><dt>Bedrooms:</dt> <dd>" + data.bedrooms + "</dd></dl>" +
            "</span></span> <span class='map__price'><strong>$" + data.price +
            "</strong></span> <a  class='map__more' href='property_details.html'>Details</a>";
    }

Examples
~~~~~~~~

Map on index page
-----------------

.. code-block:: html

    <div class="map map--index">
      <div class="map__buttons">
        <button class="map__change-map js-map-btn active">Property Map</button>
      </div>
      <div class="map__wrap">
        <div style="" data-infobox-theme="white" class="map__view js-map-index-canvas"></div>
      </div>
      <div class="container">
        <!-- BEGIN SEARCH-->
        <div class="search js-search-form search--map-sidebar">
          <button type="button" class="search__show"></button>
        <...>
        </div>
      </div>
    </div>

Map on property details page
----------------------------

.. code-block:: html

    <div class="map map--properties">
      <div class="map__buttons">
        <button class="map__change-map js-map-btn active">Property Map</button>
        <button class="map__change-panorama js-panorama-btn">Street view</button>
      </div>
      <div class="map__wrap">
        <div style="" data-type="map" class="map__view js-map-canvas"></div>
        <div style="" data-type="panorama" class="map__view map__view--panorama js-map-canvas"></div>
      </div>
    </div>
