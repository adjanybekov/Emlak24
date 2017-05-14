exports.rangeInputInteraction = function(slider) {
  var $sliderInput = $(slider.input);
  var $formGroup = $sliderInput.closest('.form-group');
  var $searchInputsContainer = $formGroup.find('.js-search-inputs');
  var $searchInputFrom = $searchInputsContainer.find('input[data-input-type="from"]');
  var $searchInputTo = $searchInputsContainer.find('input[data-input-type="to"]');
  if ($searchInputFrom.length) $searchInputFrom.val(slider.from);
  if ($searchInputTo.length) $searchInputTo.val(slider.to);
};

exports.initRangeInput = function () {
  $('.js-field-range').on('input', function () {
    var $inputFieldRange = $(this);
    var $formGroup = $inputFieldRange.closest('.form-group');
    var $sliderInput = $formGroup.find(".js-search-range").data("ionRangeSlider");
    var key = $inputFieldRange.data('input-type');
    var value = $inputFieldRange.val();

    var options = {};
    options[key] = value;

    // Call sliders update method
    $sliderInput.update(options);
  });

  $('.js-input-mode').on('click', function () {
    var $inputModeBtn = $(this);
    var $formGroup = $inputModeBtn.closest('.form-group');
    var classMode = $inputModeBtn.data('mode');
    var mode = $inputModeBtn.data('mode') === 'input' ? 'range' : 'input';
    $formGroup.removeClass('form-group--input').removeClass('form-group--range');
    $formGroup.addClass('form-group--' + classMode);
    $inputModeBtn.data('mode', mode);
    $inputModeBtn.text(mode);
  });

  $('.js-input-commision').on('click', function () {
    var $inputModeBtn = $(this);
    var $formGroup = $inputModeBtn.closest('.form-group');
    var $fieldRange = $formGroup.find('.js-field-range');
    var mode = $inputModeBtn.data('mode');
    var newMode = $inputModeBtn.data('mode') === 'rm' ? 'percent' : 'rm';
    var $sliderInput = $formGroup.find(".js-search-range").data("ionRangeSlider");

    var options = {};
    if (mode === 'rm') {
      options = {
        min: 0,
        max: 10000,
        from: 0,
        to: 10000,
        max_postfix: '+',
        prefix: 'RM ',
        postfix: ''
      }
    } else {
      options = {
        min: 0,
        max: 100,
        from: 0,
        to: 100,
        max_postfix: '',
        prefix: '',
        postfix: '%'
      }

    }

    // Call sliders update method
    $sliderInput.update(options);

    $inputModeBtn.data('mode', newMode);
    $inputModeBtn.text(newMode);
    $fieldRange.val('')
  });

};
