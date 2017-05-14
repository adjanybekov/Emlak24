Article
=======

Source
~~~~~~

Sass styles are in folder ``template_src/src/assets/sass/widgets/_article.sass``

Jade sources are in ``template_src/src/jade/partials/widgets/article.jade``

Variations
~~~~~~~~~~

There are 6 variations of the article block

*
  ``article--index`` wide grid articles

  .. image:: ../img/article--index.png

*
 ``article--sidebar`` article item in sidebar

 .. image:: ../img/article--sidebar.png

*
 ``article--list`` list of articles

 .. image:: ../img/article--list.png

*
 ``article--details`` articles details

 .. image:: ../img/article--list-item.png

*
 ``article--empty`` when no article

 .. image:: ../img/article--empty.png

*
 ``article--footer`` in footer

 .. image:: ../img/article--footer.png




Example
~~~~~~~

.. code-block:: html

    <!-- BEGIN SECTION ARTICLE -->
    <!-- class 'js-unhide-block' and button 'js-unhide' works together for showing this block on mobile devices -->
    <section class="article js-unhide-block article--index">
      <!-- Button is required on mobiles devices -->
      <button type="button" class="widget__show js-unhide">Show articles</button>
      <div class="container">
        <div class="article__header">
          <h3 class="article__title">News/Blog</h3>
          <h4 class="article__headline">Insights, tips how-to guides on selling property and preparing your home or investment property for sale and working to maximise your sale price.</h4>
        </div>
        <!-- end of block .article__header-->
        <div class="article__list">

          <div class="article__item">
            <a href="blog_details.html" class="article__photo">
              <img src="assets/media-demo/news/news-1.jpg" alt="News title" class="article__photo-img">
              <time datetime="2005-09-01" class="article__time">SEP<strong>01</strong></time>
            </a>
            <div class="article__details">
              <a href="blog_details.html" class="article__item-title">You've been approved for a rental home. Now what?</a>
              <div class="article__intro">
                <p>If you bought a home in these four areas during the downturn, you�ll make a tidy profit if you want to sell today.</p>
              </div>
              <a href="blog_details.html" class="article__more">Read more</a>
            </div>
          </div>
          <!-- end of block .article__item-->
          <!-- no limit to news items -->
          <...>
          <!-- div 'loading' is usable when you mask block, and load through ajax more items -->
          <div class="loading"></div>
        </div>
        <!-- end of block .article__list-->
        <a href="blog.html" class="article__btn-more">More articles...</a>
      </div>
    </section>
    <!-- END SECTION ARTICLE -->