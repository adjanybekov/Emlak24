Breadcrumbs
===========

.. image:: ../img/breadcurmbs.png

Source
~~~~~~

Sass source are in ``template_src/src/assets/sass/block/_breadcrumbs.sass``

Variations
~~~~~~~~~~

*
 Default html breadcrumbs

  .. code-block:: html

      <nav class="breadcrumbs">
        <ul>
          <li class="breadcrumbs__item"><a href="" class="breadcrumbs__link">Home</a></li>
          <li class="breadcrumbs__item"><a href="" class="breadcrumbs__link">Listing estate</a></li>
          <li class="breadcrumbs__item"><a href="" class="breadcrumbs__link">1600 Pennsylvania Ave NW</a></li>
        </ul>
      </nav>

*
  WP like

  .. code-block:: html

      <nav class="breadcrumbs">
        <ul class="breadcrumbs__list">
          <li class="home">
            <span typeof="v:Breadcrumb">
              <a rel="v:url" property="v:title" title="Go to Realtyspace." href="http://realtyspace.dev" class="home">Realtyspace</a>
            </span>
          </li>
          <li>
            <span typeof="v:Breadcrumb">
              <a rel="v:url" property="v:title" title="Go to Blog." href="http://realtyspace.dev/blog/">Blog</a>
            </span>
          </li>
          <li class="current_item">
            <span typeof="v:Breadcrumb">
              <span property="v:title">FAQ</span>
            </span>
          </li>
        </ul>
      </nav>
