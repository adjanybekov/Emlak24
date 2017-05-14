Browser Support
===============

Compatible browsers are IE9, IE10, IE11, Firefox, Safari, Opera, Chrome

Out of the box, Realtyspace theme does not support browsers older than IE9, however
you may add some basic older browser support by adding this code into template ``<head>``.



.. code-block:: html

    <!--[if lt IE 9]>
    <script type="text/javascript" src='https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js'></script>
    <script type="text/javascript" src='https://oss.maxcdn.com/respond/1.4.2/respond.min.js'></script>
    <![endif]-->


and switching ``jQuery 2`` version to ``jQuery 1``.

.. note:: We can provide support only for issues in browsers IE9 and higher, Firefox, Safari, Opera and Chrome.