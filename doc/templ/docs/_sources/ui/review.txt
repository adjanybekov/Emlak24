Review
======

Source
~~~~~~


Sass styles are in ``template_src/src/assets/sass/widgets/_review.sass`` .

Jade source are in ``template_src/src/jade/partials/widgets/review.jade`` , ``template_src/src/jade/partials/chunks/review_item.jade`` .

Variations
~~~~~~~~~~

*
 ``review--wide`` - wide review

 .. image:: ../img/review--wide.jpg
*
 ``review--list`` - list review

 .. image:: ../img/review--list.jpg


Options
~~~~~~~

Review wide
-----------

.. code-block:: html

    <!-- BEGIN SECTION REVIEW-->
    <section class="review review--wide">
      <div class="container">
        <div class="review__header">
          <h3 class="review__title">Testimonials</h3>
          <h4 class="review__headline">Some nice words from our clients. The funds are strictly designed to help single-family homeowners retrofit their residences for safety purposes.</h4>
        </div>
        <!-- end of block .review__header-->
        <div id="review-slider" class="review__list">
          <div class="review__slider js-slick-slider">
            <div class="review__item">
              <div class="review__photo"><img src="assets/media-demo/testimonials/01.jpg" alt="ALT" class="review__photo-img"></div>
              <div class="review__details"><span class="review__name">Vanessa Kasinsky</span><span class="review__post">Back-End Developer</span>
                <div class="review__stars"><i class="glyphicon glyphicon-star"></i><i class="glyphicon glyphicon-star"></i><i class="glyphicon glyphicon-star"></i><i class="glyphicon glyphicon-star"></i><i class="glyphicon glyphicon-star"></i></div>
              </div>
              <!--.clearfix-->
              <div class="review__info">
                <div class="review__info-quote review__info-quote--open">&rdquo;</div>
                <p>Mariusz always addressed my questions professionally and in a very timely manner. Working with him was a pleasure and would come with my recommendation.
                </p>
                <div class="review__info-quote review__info-quote--close">&ldquo;</div>
              </div>
            </div>
            <!-- end of block .review__item-->
            <...>
          </div>
          <div class="review__controls">
            <button class="review__arrow review__arrow--prev js-review-prev"></button>
            <button class="review__arrow review__arrow--next js-review-next"></button>
          </div>
        </div>
        <!-- end of block .review__list-->
      </div>
    </section>
    <!-- END SECTION REVIEW-->


Review wide initialization
--------------------------

.. code-block:: js

    function initReviewSlider() {
        /***************************************************************
         * Initialize sliders for user reviews
         * See http://kenwheeler.github.io/slick/ for more options
         ==============================================================*/
        var $reviewSlider = $('#review-slider');
        $reviewSlider
            .find('.js-slick-slider')
            .slick({
                dots: false,
                infinite: true,
                speed: 300,
                slidesToShow: 1,
                autoplay: true,
                prevArrow: $reviewSlider.find('.js-review-prev'),
                nextArrow: $reviewSlider.find('.js-review-next')
            });
    }


Review list
-----------

.. code-block:: html

  <section class="review review--list">
    <div class="review__list">
      <div class="review__item">
        <div class="review__photo"><img src="assets/media-demo/testimonials/01.jpg" alt="ALT" class="review__photo-img"></div>
        <div class="review__details"><span class="review__name">Vanessa Kasinsky</span><span class="review__post">Back-End Developer</span>
          <div class="review__stars"><i class="glyphicon glyphicon-star"></i><i class="glyphicon glyphicon-star"></i><i class="glyphicon glyphicon-star"></i><i class="glyphicon glyphicon-star"></i><i class="glyphicon glyphicon-star"></i></div>
        </div>

        <div class="review__info">
          <p>Mariusz always addressed my questions professionally and in a very timely manner. Working with him was a pleasure and would come with my recommendation.This summer helper is smokin' hot! Porter is a multi-purpose BBQ tray that eliminates extra trips between your kitchen and grill. Containers with lids keep raw food safely separated.</p>
        </div>
      </div>
      <!-- end of block .review__item-->
      <...>
    </div>
  </section>