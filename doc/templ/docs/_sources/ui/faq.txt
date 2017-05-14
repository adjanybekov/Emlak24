Faq
===

Overview
~~~~~~~~

Expandable plugin, provided by bootstrap, more documentation and options look `here <http://getbootstrap.com/javascript/#collapse-example-accordion>`_

Source
~~~~~~

Sass source are in ``template_src/src/assets/sass/layout/_faq.sass``

Jade source are in folder ``template_src/jade/faq.jade``

Example
~~~~~~~

.. code-block:: html

    <div id="accordion" role="tablist" aria-multiselectable="true" class="faq">
        <dl class="faq__item">
          <dt id="heading-0" role="tab" class="faq__title">
            <!-- heading questions -->
            <a data-toggle="collapse" data-parent="#accordion" href="#collapse-0" aria-expanded="true" aria-controls="collapse-0" class="faq__expander collapsed">How do we determine how much we can afford to pay for a home?</a>
          </dt>
          <dd id="collapse-0" role="tabpanel" aria-labelledby="heading-0" class="faq__content collapse">
            <div class="faq__body">
              <!-- issue response -->
              <p>In order to determine how much you can afford, we need to understand debt to income ratios. First, we must determine what your gross annual income is and divide that income by 12. (12 months). Second, we must determine your long term debt. For example: home mortgage (principal &amp; interest), taxes &amp; insurance (T &amp; I), school loan, car loan, credit card debt, etc. and calculate the monthly payments. Third, the debt to income ratio is established by dividing the monthly debt by the monthly income. The debt to income ratio should, in most cases not exceed 35%.     Forth, if the debt to income ratio is 35% or less and your credit rating is decent, there is a good chance you will be able to get approved for a mortgage loan.</p>
            </div>
            <div class="faq__footer">
              <!-- close button -->
              <a data-toggle="collapse" data-parent="#accordion" href="#collapse-0" aria-controls="collapse-0" class="faq__close">Close</a>
            </div>
          </dd>
        </dl>
        <!-- end of block .faq__item-->
        <...>
    </div>
    <!-- END FAQ-->

.. Note:: Attributes ``id="heading-0"`` where ``0`` are in all controls, must be correlated, for this you can just increment it.