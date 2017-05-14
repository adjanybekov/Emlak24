Pricing
=======

Source
~~~~~~

Sass styles are in folder ``template_src/src/assets/sass/widgets/_pricing.sass`` .

Jade source are in ``template_src/src/jade/pricing.jade`` .

Variations
~~~~~~~~~~

RS come with 3 variants of pricing blocks:

*
  3 columns

  .. image:: ../img/pricing--col-3.jpg

*
  4 columns

  .. image:: ../img/pricing--col-4.jpg

*
  Table

  .. image:: ../img/pricing--table.jpg


Example
~~~~~~~

.. code-block:: html

    <div class="pricing">
        <div class="pricing__row">
          <div class="pricing__col3">
            <div class="pricing__item">
              <dl class="pricing__list">
                <dt class="pricing__type">Free</dt>
                <dd class="pricing__total"><span class="pricing__currency">$</span><span class="pricing__summa">0</span><span class="pricing__period">/monthly</span></dd>
                <dd class="pricing__feature"><strong>2</strong>Properties</dd>
                <dd class="pricing__feature"><strong>1</strong>Agent Profiles</dd>
                <dd class="pricing__feature">Agency Profiles</dd>
                <dd class="pricing__feature">Featured Properties</dd>
              </dl>
              <div class="pricing__actions">
                <button class="pricing__button">Sign in</button>
              </div>
            </div>
          </div>
          <...>
        </div>
    </div>