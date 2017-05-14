JavaScript
==========

About
-----

All js files that you will need are located in ``template/js`` folder

vendor.js
    contains vendor libraries (Bootstrap3, Jquery, Chosen, etc) already compiled into a single file, with
    versions that are verified to work with our theme. Normally, you should not edit that file.

app.js
    JavaScript library code that Realtyspace theme relies on, in order to function properly. Normally, you should not
    edit this file or add your own code there. This file exposes a very simple API that you can use in
    your own code.

demodata.js
    This file is used for demonstration purposes and contains example property items, that are mostly used to
    render markers on the map. You can safely delete this file, after you've adapted the demo.js code
    to use your own data.

demo.js
    the main file, that you should modify (or create another one). It contains lots of examples of
    plugin usage, with detailed comments about specific sections of the code. This is the file that runs
    most of the code defined in vendor.js and app.js, therefore you can easily make changes in this file,
    which will affect the way the theme works.


Here is the correct order to connect these JavaScript in your template:

.. code-block:: html

    <script type="text/javascript" src="https://maps.google.com/maps/api/js?libraries=places"></script>
    <script type="text/javascript" src="js/vendor.js"></script>
    <script type="text/javascript" src="js/demodata.js"></script>
    <script type="text/javascript" src="js/app.js"></script>
    <script type="text/javascript" src="js/demo.js"></script>


Class helpers
-------------

Our theme contains a wide range of class helpers, that allow you to use certain javascript plugins
(that come with Realtyspace theme), without having to write a single line of JavaScript code,
just by specifying a certain js-* class to a HTML element.

js-parsley
    By applying this class to a form, you can easily activate the advanced validation engine that is provided
    by the Parsleyjs_ plugin. Additionaly, you can set
    `specific validation rules <http://parsleyjs.org/doc/index.html#validators>`_ for each form field.

    Example:

    .. code-block:: html

        <form class="js-parsley">
        <div class="form__row form-group">
          <label for="in-form-name" class="form__label control-label">Your Name</label>
          <input id="in-form-name" type="text" name="name" required class="form__in form__in--text form-control">
        </div>
        <div class="form__row form-group">
          <label for="in-form-message" class="form__label control-label">Message</label>
          <textarea id="in-form-message" name="message" required data-parsley-trigger="keyup"
            data-parsley-minlength="20" data-parsley-validation-threshold="10"
            data-parsley-minlength-message="You need to enter at least a 20 caracters long comment.."
            class="form__in form__in--textarea form-control">
          </textarea>
        </div>
        <div class="form__row">
          <button type="submit" class="form__submit">Submit</button>
        </div>
        </form>


F.A.Q.
------

.. contents::
    :local:
    :depth: 1

.. _demojs:

...Can i use create my own file intead of demo.js?
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Totally! We've created this file so you can look at examples of module and plugin initialization.
But if you know what you're doing,  you can remove the line

.. code-block:: html

    <script type="text/javascript" src="js/demo.js"></script>


from the template and connect instead your own file with the code that you need.

.. _Parsleyjs: http://parsleyjs.org/
