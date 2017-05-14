Workers
=======

Source
~~~~~~

Sass styles are in ``template_src/src/assets/sass/widgets/_worker.sass`` .

Jade source are in ``template_src/src/jade/partials/widgets/worker.jade`` .

Variations
~~~~~~~~~~


*
  ``worker--index``

  .. image:: ../img/worker--index.jpg

*
  ``worker--grid``

  .. image:: ../img/worker--grid.jpg

*
  ``worker--list``

  .. image:: ../img/worker--list.jpg

*
  ``worker--details``

  .. image:: ../img/worker--details.jpg

*
  ``worker--navbar``

  .. image:: ../img/worker--navbar.jpg

*
  ``worker--properties``

  .. image:: ../img/worker--properties.jpg

*
  ``worker--sidebar``

  .. image:: ../img/worker--sidebar.jpg

*
  ``worker--sidebar-advanced``

  .. image:: ../img/worker--sidebar-advanced.jpg

*
  ``worker--sidebar-nav``

  .. image:: ../img/worker--sidebar-nav.jpg

Options
~~~~~~~

Worker index page
-----------------

.. code-block:: html

  <!-- BEGIN SECTION WORKER INDEX-->
  <section class="worker worker--index">
    <div class="container">
      <header class="worker__header">
        <h3 class="worker__title">Our Agents</h3>
        <h4 class="worker__headline">Our agents are licensed professionals that specialise in searching, evaluating and negotiating the purchase of property on behalf of the buyer. They will sell you real estate. Insights, tips &amp; how-to guides on selling property and preparing your home or investment property for sale and working to maximise your sale price.</h4>
      </header>
      <!-- end of block .worker__header-->
      <div class="worker__list">
        <div class="worker__item vcard">
          <h3 class="worker__name fn">Christopher Pakulla</h3>
          <div class="worker__photo">
            <a href="agent_profile.html" class="item-photo">
              <img src="assets/media-demo/workers/worker-1.jpg" alt="Christopher Pakulla" class="photo">
              <figure class="item-photo__hover">
                <span class="item-photo__more">View Details</span>
              </figure>
            </a>
          </div>
          <a href="tel:+44(0)2035102390" class="worker__tel uri">+44 (0) 20 3510 2390</a>
          <div class="worker__contacts">
            <div class="email">
              <a href="mailto:c_walken@realtyspace.com" class="uri value">c_walken@realtyspace.com</a>
            </div>
          </div>
          <!-- end of block .worker__contacts-->
        </div>
        <!-- end of block .worker__item-->
        <...>
        <div class="loading"></div>
      </div>
      <!-- end of block .worker__list-->
    </div>
  </section>
  <!-- END SECTION WORKER INDEX-->
