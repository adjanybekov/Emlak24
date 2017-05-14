Subscribe
=========

Source
~~~~~~


Sass styles are in ``template_src/src/assets/sass/widgets/_subscribe.sass`` .

Jade source are in ``template_src/src/jade/partials/widgets/subscribe.jade`` .

Example
~~~~~~~

.. code-block:: html

    <!-- BEGIN SUBSCRIBE-->
    <div class="subscribe">
      <div class="container">
        <div class="subscribe__row">
          <form action="#" class="subscribe__form js-subscribe-form">
            <h4 class="subscribe__title">Newsletters</h4>
            <div class="subscribe__field form-group">
              <label class="sr-only">Newsletters</label>
              <input type="email" placeholder="Input your e-mail" name="email" required data-parsley-trigger="change" class="subscribe__in subscribe__in--text form-control js-subscribe-email">
            </div>
            <button type="submit" class="subscribe__in subscribe__in--submit js-subscribe-submit">SUBMIT</button>
          </form>
          <!-- end of block .subscribe__form-->
        </div>
      </div>
    </div>
    <!-- END SUBSCRIBE-->

.. code-block:: js

    /**
     * Subscribe form validation initialization as well as
     * displaying PNotify global message on error/success
     *
     * app.notifier.showSuccess/showError is a wrapper around `PNotify` function
     * with predefined defaults to make it look good in this theme
     *
     * if you would like to modify it, feel free to use the PNotify
     * plugin directly
     ==============================================================*/

    var subscribeForm = $('.js-subscribe-form');
    if (subscribeForm.length) {
        subscribeForm
            .parsley()
            .on('form:success', function (formInstance) {
                app.notifier.showSuccess('You have been successfully subscribed!');
                return false;
            })
            .on('form:error', function (formInstance) {
                app.notifier.showError('Subscription failed! Please try again.');
                return false;
            })
        ;

    }

.. Note:: More documentaion `PNotify <http://sciactive.github.io/pnotify/>`_

.. Note:: Pay attention to input's attributes ``data-parsley-*`` this are rules for validation, see documentation `Parsleyjs <http://parsleyjs.org/>`_