Form
====

Source
~~~~~~

Sass styles are in folder ``template_src/src/assets/sass/widgets/_form.sass`` .

Jade source are in ``template_src/src/jade/partials/chunks/form.jade`` .

Variations
~~~~~~~~~~

* ``<div class="form form--properties">`` - form on property details page
* ``<div class="form form--comment">`` - comment form
* ``<div class="form form--contacts">`` - contacts form
* ``<div class="form form--workers">`` - worker's form
* ``<div class="form form--sidebar-workers">`` - sidebar worker's form
* ``<div class="form form--footer">`` - form in footer


Example
~~~~~~~

You can use rangeSlider insteand of simple selects,

.. code-block:: html

    <div class="form form--properties">
      <form action="#" method="POST" class="form__wrap js-contact-form">
        <!-- wrap each inputs group in row -->
        <div class="form__row form-group">
          <!-- include standrart bootstraps classes 'control-label', 'form-control', 'form-group', very usable for some plugins -->
          <label for="in-form-name" class="form__label control-label">Your Name</label>
          <input id="in-form-name" type="text" name="name" required class="form__in form__in--text form-control">
        </div>
        <!-- modificators 'form__row--tel' and 'form__row--email' are usable when it should be aligned in columns -->
        <div class="form__row form__row--tel form-group">
          <label for="in-form-phone" class="form__label control-label">Telephone</label>
          <input id="in-form-phone" type="text" name="phone" class="form__in form__in--text form-control">
        </div>
        <div class="form__row form__row--email form-group">
          <label for="in-form-email" class="form__label control-label">E-mail</label>
          <input id="in-form-email" type="email" name="email" required data-parsley-trigger="change" class="form__in form__in--text form-control">
        </div>
        <div class="form__row form-group">
          <label for="in-form-message" class="form__label control-label">Message</label>
          <textarea id="in-form-message" name="message" required data-parsley-trigger="keyup" data-parsley-minlength="20" data-parsley-validation-threshold="10" data-parsley-minlength-message="You need to enter at least a 20 caracters long comment.." class="form__in form__in--textarea form-control"></textarea>
        </div>
        <div class="form__row">
          <button type="submit" class="form__submit">Submit</button>
        </div>
      </form>
    </div>
    <!-- end of block form-->

.. Note:: Pay attention to input's attributes ``data-parsley-*`` this are rules for validation, see documentation `Parsleyjs <http://parsleyjs.org/>`_