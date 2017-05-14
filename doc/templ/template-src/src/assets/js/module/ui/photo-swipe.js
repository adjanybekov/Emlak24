"use strict";
function getItems(cssSelector) {
  var $items = $(cssSelector),
    arrItems = [];

  $items.each(function (i, item) {
    var size = item.getAttribute('data-size').split('x'),
      src = item.getAttribute('href');
    arrItems.push({
      src: src,
      w: parseInt(size[0]),
      h: parseInt(size[1])
    });
  });

  return arrItems;
}

function buildPopup() {

  var htmlPswp =
    '<div class="pswp js-pspw" tabindex="-1" role="dialog" aria-hidden="true">\
      <div class="pswp__bg"></div>\
      <div class="pswp__scroll-wrap">\
        <div class="pswp__container">\
          <div class="pswp__item"></div>\
          <div class="pswp__item"></div>\
          <div class="pswp__item"></div>\
          <div class="pswp__item"></div>\
        </div>\
        <div class="pswp__ui pswp__ui--hidden">\
          <div class="pswp__top-bar">\
            <div class="pswp__counter"></div>\
            <button class="pswp__button pswp__button--close" title="Close (Esc)"></button>\
            <button class="pswp__button pswp__button--share" title="Share"></button>\
            <button class="pswp__button pswp__button--fs" title="Toggle fullscreen"></button>\
            <button class="pswp__button pswp__button--zoom" title="Zoom in/out"></button>\
            <div class="pswp__preloader">\
              <div class="pswp__preloader__icn">\
                <div class="pswp__preloader__cut">\
                  <div class="pswp__preloader__donut"></div>\
                </div>\
              </div>\
            </div>\
          </div>\
          <div class="pswp__share-modal pswp__share-modal--hidden pswp__single-tap">\
            <div class="pswp__share-tooltip"></div>\
          </div>\
          <button class="pswp__button pswp__button--arrow--left" title="Previous (arrow left)"></button>\
          <button class="pswp__button pswp__button--arrow--right" title="Next (arrow right)"></button>\
          <div class="pswp__caption">\
            <div class="pswp__caption__center"></div>\
          </div>\
        </div>\
      </div>\
    </div>';

  return $(htmlPswp).appendTo('body')[0];
}

var _ = require('lodash');
exports.init = function (cssSelector, options) {


  // define options (if needed)
  options = _.defaults(options, {
    // optionName: 'option value'
    // for example:
    shareEl: false,
    index: 0,
    history: false
  });


  // build items array
  var items = getItems(cssSelector);
  var PhotoSwipe = require('photoswipe/dist/photoswipe');
  var PhotoSwipeUI_Default = require('photoswipe/dist/photoswipe-ui-default');
  var galleryLinks = $(cssSelector);
  var popup = buildPopup();

  // listen events>
  galleryLinks.on('click', function (e) {
    var index = $(this).data('gallery-index') ? $(this).data('gallery-index') : galleryLinks.index(this);
    // Initializes and opens PhotoSwipe
    var gallery = new PhotoSwipe(popup, PhotoSwipeUI_Default, items, options);
    gallery.init();

    gallery.listen('initialZoomInEnd', function() {
      gallery.goTo(index);
      $('.pswp__item').show();
    });

    return false;
  });
};
