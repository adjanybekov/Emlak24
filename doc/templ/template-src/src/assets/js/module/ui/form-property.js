"use strict";
module.exports = function () {
  var $form = $('.js-form-property');
  if (!$form.length) return;


  var Dropzone = require('dropzone');
  require('html5sortable');
  require('cropper');
  //require('parsleyjs');

  //$form
  //  .each(function () {
  //    var $currentForm = $(this);
  //    console.log($currentForm);
  //    $('.js-form-property-1')
  //      .parsley()
  //      .on('form:success', function (formInstance) {
  //        //app.notifier.showSuccess('You have successfully submit the form! 1');
  //        //return false;
  //      })
  //      .on('form:error', function (formInstance) {
  //        app.notifier.showError('Submited failed! Please try again. 2');
  //
  //        return false;
  //      });
  //  });

  $('.js-location-tab').on('shown.bs.tab', function (e) {
    var $map = $('.js-map');
    if ($map.length) {
      $map.each(function () {
        var $m = $(this);
        google.maps.event.trigger($m[0], 'resize');
      });
    }
  });

  $('.js-photos-list').sortable();

  Dropzone.options.photosUploader = {
    paramName: "file", // The name that will be used to transfer the file
    maxFilesize: 2, // MB
    thumbnailWidth: 250,
    accept: function(file, done) {
      console.log('accept');
      if (file.name == "justinbieber.jpg") {
        done("Naha, you don't.");
      }
      else { done(); }
    }
  };

  var minContainerWidth = app.gridSize.get() === 'xs' ? $(window).width() - 150 : 500;

  $('#photo-crop').cropper({
    aspectRatio: 16 / 9,
    minContainerWidth: minContainerWidth,
    minContainerHeight: 400,
    crop: function(e) {
      // Output the result data for cropping image.
      console.log(e.x);
      console.log(e.y);
      console.log(e.width);
      console.log(e.height);
      console.log(e.rotate);
      console.log(e.scaleX);
      console.log(e.scaleY);
    }
  });

  $('.js-photos-edit').on('click', function () {
    var link = $(this);
    var tab = link.data('tab');
    console.log(tab);
    $(tab).tab('show');

  });

  $('.js-portfolio').select2({
    tags: true
  })

};
