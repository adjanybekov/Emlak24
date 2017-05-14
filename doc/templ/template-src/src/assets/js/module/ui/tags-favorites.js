"use strict";
var removeEditable = function () {
  var $tagsItem = $('.js-tags-item');
  $tagsItem.attr('contentEditable', false);
  $tagsItem.removeClass('editable');
};

var setEditable = function (el) {
  el.className = el.className + ' editable';
  el.setAttribute('contenteditable', true);
  var range = document.createRange();
  var sel = window.getSelection();
  var end = 0;
  if (el.childNodes && el.childNodes[0]) end = el.childNodes[0].length;
  if (!el.childNodes.length) {
    el.appendChild(document.createTextNode(''));
  }
  range.setStart(el.childNodes[0], end);
  range.collapse(true);
  sel.removeAllRanges();
  sel.addRange(range);
  el.focus();
};

var toggleTags = function (state) {
  var $tagsItem = $('.js-tags-item');
  removeEditable();
  if(state) {
    $tagsItem.addClass('active');
  } else {
    $tagsItem.removeClass('active');
  }
};

module.exports = function () {
  var $tags = $('.js-tags');
  if (!$tags.length) return;

  var $btnAll = $('.js-tags-all');
  var $btnNew = $('.js-tags-new');

  var DELAY = 200, clicks = 0, timer = null;

  $tags
    .on('click', function (e) {
      var $tag;
      if ($(e.target).hasClass('js-tags-item')) {
        $tag = $(e.target);
        clicks++;
        if (clicks === 1) {
          timer = setTimeout(function () {
            if (!$tag.hasClass('editable')) {
              removeEditable();
              $tag.toggleClass('active');
            }
            clicks = 0;
          }, DELAY);
        } else {
          clearTimeout(timer);
          removeEditable();
          setEditable($tag[0]);
          clicks = 0;
        }
      } else {
        removeEditable();
      }

    })
    .on('dblclick', '.js-tags-item', function(e) {
      e.preventDefault();
    })
    .on('keypress', function (e) {
      var keyCode = e.keyCode;
      if (keyCode === 13) {
        removeEditable();
        console.log('must save');
        e.preventDefault();
      }

    });

  $btnAll.on('click', function () {
    $btnAll.toggleClass('active');
    toggleTags($btnAll.hasClass('active'))
  });

  $btnNew
    .on('click', function () {
      var $btn = $(this).closest('.tags__item');
      if ($btn.hasClass('editable')) {
        var text = $btn.text();
        $btn.before('<button class="tags__item js-tags-item">' + text + '</button>');
        $btn[0].childNodes[0].nodeValue = '';
        $btn.removeClass('editable');
      } else {
        setEditable($btn[0]);
      }
    })
    .on('keypress', function (e) {
      var keyCode = e.keyCode;
      console.log(keyCode);
      if (keyCode === 13) {
        removeEditable();
        console.log('must save');
        e.preventDefault();
      }
    });
};
