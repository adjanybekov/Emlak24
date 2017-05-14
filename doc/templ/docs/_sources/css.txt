CSS
===

About
-----

All css files that you will need are located in ``template/css`` folder

vendor.css
    Styles from Bootstrap and other plugins

font-awesome.css
    Styles for Font-Awesome

theme-default.css
    Styles for Realtyspace default color theme

theme-\*.css
    Styles for other Realtyspace color themes

custom.css
    Empty file, you can add here your custom styles

.. tip::

    We are using `BEM methodology <https://en.bem.info>`_ for theme development. It promotes a specific
    naming convention, style reuse and clean, bloat-free code. If you'd like to follow this methodology,
    please consult `this list of tutorials <https://en.bem.info/tutorials/>`_.


Normally you should connect the following files in your html template:

.. code-block:: html

    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:200,400,600,700,400italic,700italic&amp;subset=latin,latin-ext" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="css/vendor.css">
    <link rel="stylesheet" href="css/font-awesome.css">
    <link rel="stylesheet" href="css/theme-default.css">
    <link rel="stylesheet" href="css/style.css">

.. note::

    The theme css code is split into ``vendor.css`` and ``theme-default.css`` for compatility reasons,
    because IE9 has a `4095 rule limit <http://stackoverflow.com/questions/9906794/internet-explorers-css-rules-limits/9906889#9906889>`_ per one stylesheet.


How do I...
-----------

.. contents::
    :local:
    :depth: 1


.. _color_scheme:

...change color scheme?
~~~~~~~~~~~~~~~~~~~~~~~

Just replace the stylesheet

.. code-block:: html

    <link rel="stylesheet" href="css/theme-default.css" id="link-styles">

with

.. code-block:: html

    <link rel="stylesheet" href="css/theme-pink_yellow.css" id="link-styles">

to use pink_yellow color scheme.

