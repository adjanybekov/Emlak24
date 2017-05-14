Datetime picker
===============

SASS
    ``template_src/src/assets/sass/vendor/daterangepicker.sass``
JavaScript
    ``template_src/src/assets/js/module/data-api/datetime.js``
Plugin URL
    `Date Range Picker`_



Options
~~~~~~~
Required HTML class ``js-datetimerange``

=========================== =============== ======================= ====================================================
Name                        Type            Default                 Description
=========================== =============== ======================= ====================================================
``data-start-time``         date                                    Datepicker starting time
``data-end-time``           date                                    Datepicker end time
``data-time-picker``        boolean         false                   Show timepicker
``data-single-picker``      boolean         false                   Show single datepicker window
``data-24hr``               boolean         false                   Show 24hr time
``data-locale-format``      datetime format MM/DD/YYYY  h:mm A
=========================== =============== ======================= ====================================================

.. Note:: If you need more options, you should use the `Date Range Picker`_ plugin directly.

Example
~~~~~~~

Minimal
-------
.. code-block:: html

   <input type="text" class="js-datetimerange">

Advanced
--------
.. code-block:: html

   <input type="text"
        id="in-datetime"
        data-start-date="01/01/2015"
        data-end-date="01/03/2015"
        data-time-picker="true"
        data-single-picker="false"
        class="js-datetimerange"
    >


.. _Date Range Picker: http://www.daterangepicker.com/