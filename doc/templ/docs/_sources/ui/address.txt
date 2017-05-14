Address
=======

Source
~~~~~~

Sass styles are in folder ``template_src/src/assets/sass/widgets/_address.sass``

Jade source are in ``template_src/src/jade/partials/widgets/address.jade``

Example
~~~~~~~

.. code-block:: html

    <!-- modificator 'address--footer' because this is a part of footer -->
    <section class="address address--footer">
      <div class="address__header">
        <h3 class="address__title">Contact</h3>
        <h4 class="address__headline">Our office</h4>
      </div>
      <address class="address__main">
        <!-- put here any contact details, use tags 'span' or 'a', to have better styles -->
        <span>1950 New York, NY, Ave NW, California, DC 3000600, USA</span>
        <span>08 - 17 mon-fr</span>
        <a href="tel:+442240052225">+1 202 555 0135</a>
        <a href="tel:+442240052225">+1 202 555 0135</a>
        <span>Fax: +1 202 555 0135</span>
        <a href="mailto:hello@example.com">hello@example.com</a>
      </address>
    </section>