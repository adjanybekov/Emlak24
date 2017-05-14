.. _source_version:

Source version
==============
The source version is located in the ``template-src/`` directory and is intended
for people that are proficient with tools like SASS, Jade, NPM, etc.

Structure
---------

* ``template-src/gulpfile.js/`` - Build system, that compiles all jade, sass, js modules into ready to use, standalone html, css and js files
* ``template-src/src/jade/`` - Template files from which final HTML templates are built
* ``template-src/src/assets/js/`` - JS modules from which final js files in ``js/`` are built
* ``template-src/src/assets/sass/`` - SASS files from which final css files in ``css/`` are built
* ``template-src/src/assets/img/`` - Images that are used in the theme
* ``template-src/src/assets/media-demo/`` - Demonstration images licensed under Creative Commons, please replace them with your own assets.
* ``template-src/bower.js`` - Bower package manager configuration
* ``template-src/package.json`` - NPM package manager configuration

Setup
-----

Requirements for running the builds:

* Ruby (https://www.ruby-lang.org/)
* SASS gem (http://sass-lang.com/)
* Node.js (https://nodejs.org/)
* NPM (https://www.npmjs.com/)
* Git (https://git-scm.com/)

Please follow the links above in order to get installation instructions for each application.
Once you have installed the required applications, open a console and navigate to ``your/path/to/template-src``

Run the below command to install packages listed in ``template-src/packages.json`` (npm will load automatically this file
and read its list of required modules)::

    npm install

That's all!

Available commands
------------------

npm run dev - developer mode
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

To run the build in developer mode, navigate to ``your/path/to/template-src``
and run::

    npm run dev

and access the dev-server on http://localhost:4000

When to use
***********
During development in order to preview the changes made in ``src`` directory.

Features and differences:
*************************

* The changes in sass files, jade files, etc. are automatically detected and the page is refreshed.
* Sourcemaps are attached to js and css in order to simplify debugging.
* The build process is tuned to skip some time-consuming tasks (like building stylesheets for all color schemes).

npm run release - release mode
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

To run the build in release mode, run::

    npm run release

After executing this command, the build will be placed into the ``template-build/`` directory.

When to use
***********
After you've finished editing the source files and you'd like to receive the compiled, compressed and minified
version of the theme. The resulting files are similar to the ones that you've got in ``template/`` directory
and are located in ``template-build/`` folder.

Features and differences:
*************************

* The css and js files are compressed and can be found next to non-compressed files in ``js/`` and ``css/`` directories.
* Unlike running the build in dev-mode, the non-default color schemes are also generated.

npm run server - production server
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

To start production server, run::

    npm run server

When to use
***********
After you've run ``npm run release`` and you'd like to view the resulting template.

.. _gulp: http://gulpjs.com/