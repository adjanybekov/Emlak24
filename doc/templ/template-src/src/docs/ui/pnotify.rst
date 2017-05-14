Pnotify
=======

Source
~~~~~~


Sass styles are in folder ``template_src/src/assets/sass/block/pnotify.sass`` .

Js are in ``template_src/src/js/demo.js`` and ``template_src/src/assets/js/module/notifier.js`` .


Options
~~~~~~~

Use global triggers for generating notifications:

* ``app.notifier.showSuccess('You have been successfully subscribed!');`` - success notification.
* ``app.notifier.showError('Subscription failed! Please try again.');`` - error notification.

Example
~~~~~~~

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
                // trigger here success notification
                app.notifier.showSuccess('You have been successfully subscribed!');
                return false;
            })
            .on('form:error', function (formInstance) {
                // trigger here error notification
                app.notifier.showError('Subscription failed! Please try again.');
                return false;
            })
        ;

    }

.. Note:: More documentaion `PNotify <http://sciactive.github.io/pnotify/>`_