Partners
========

Source
~~~~~~

Sass styles are in folder ``template_src/src/assets/sass/widgets/_partners.sass`` .

Jade source are in ``template_src/src/jade/partials/widgets/partners.jade`` .

Js initialization are in ``template_src/src/js/demo.js`` .

Ooptions
~~~~~~~~

.. code-block:: js

    /**
     * Slick slider for "Our partners" block
     * See documentation for options http://kenwheeler.github.io/slick/
     ==============================================================*/
    var $partnersSlider = $('#partners-slider');

    $partnersSlider
        .find('.js-slick-slider')
        .slick({
            dots: false,
            infinite: true,
            speed: 300,
            slidesToShow: 5,
            autoplay: true,
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

Example
~~~~~~~

.. code-block:: html

    <!-- BEGIN PARTNERS-->
    <section class="partners">
      <div class="container">
        <header class="partners__header">
          <h3 class="partners__title">Our Partners</h3>
          <h4 class="partners__headline">
            At RS, our partners make great digital experiences possible by offering our products, consulting
             expertise and the products of our technology partners
          </h4>
        </header>
        <!-- end of block .partners__header-->
        <div id="partners-slider" class="partners__list">
          <div class="partners__slider js-slick-slider">
            <div class="partners__item"><img src="assets/media-demo/partners/logo-company-1.png" alt=""></div>
            <!-- end of block .partners__item-->
            <...>
          </div>
          <div class="partners__controls">
            <button class="partners__arrow partners__arrow--prev js-partners-prev"></button>
            <button class="partners__arrow partners__arrow--next js-partners-next"></button>
          </div>
          <!-- end of block .partners__controls-->
        </div>
        <!-- end of block .partners__list-->
      </div>
    </section>
    <!-- end of block .partners-->
    <!-- END PARTNERS-->