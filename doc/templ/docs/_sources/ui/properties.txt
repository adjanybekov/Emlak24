Properties
==========

Source
~~~~~~

Sass styles are in folder ``template_src/src/assets/sass/widgets/_properties.sass`` .

Jade source are in ``template_src/src/jade/partials/chunks/properties_item.jade`` .

Variations
~~~~~~~~~~

* ``properties--index`` properties on index page
* ``properties--grid`` properties grid
* ``properties--list`` properties list
* ``properties--similar`` properties similar widget
* ``properties--workers`` properties on workers page
* ``properties--sidebar`` properties in sidebar
* ``properties--gallery`` properties gallery

Options
~~~~~~~

.. code-block:: html

  <div class="properties properties--grid">
    <div class="properties__list">
      <div class="properties__item">
        <div class="properties__thumb">
            <a href="property_details.html" class="item-photo">
                <img src="assets/media-demo/properties/830x540/02.jpg" style="" alt="">
                <figure class="item-photo__hover">
                    <span class="item-photo__more">View Details</span>
                </figure>
            </a>
            <span class="properties__ribon">For rent</span>
        </div>
        <!-- end of block .properties__thumb-->
        <a href="property_details.html" class="properties__address">649 West Adams Boulevard, Los Angeles, CA 90007, USA</a>
        <dl class="properties__param">
          <dt>Property type:</dt>
          <dd>Self Storage</dd>
          <dt>Area:</dt>
          <dd>371 m2</dd>
          <dt>Bedrooms:</dt>
          <dd>2</dd>
          <dt>Bathrooms:</dt>
          <dd>1</dd>
        </dl>
        <!-- end of block .properties__param--><span class="properties__price">$ 4,555<span class="properties__price-period">per month</span></span><a href="property_details.html" class="properties__more">View Details</a>
      </div>
      <!-- end of block .properties__item-->
      <...>
    </div>
  </div>
