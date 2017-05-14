require('bootstrap-daterangepicker');
var _ = require('lodash');

var detectOpenDirection = function ($item) {
  var opensDir;
  var offsetLeft = $item.offset().left;
  var offsetRight = ($(window).width() - ($item.offset().left + $item.outerWidth()));
  if (offsetLeft < 600) {
    opensDir = 'right';
  } else if (offsetRight < 600) {
    opensDir = 'left';
  }
  return opensDir;
};

var buildOptions  = function($item){
  return _.defaultsDeep(
    {
      startDate: $item.data('start-date'),
      endDate: $item.data('end-date'),
      timePicker: $item.data('time-picker'),
      singleDatePicker: $item.data('single-picker'),
      timePicker24Hour: $item.data('24hr'),
      locale: {
        format: $item.data('locale-format')
      }
    },
    {
      locale: {
        format: 'MM/DD/YYYY  h:mm A'
      },
      timePicker: false,
      timePickerIncrement: 5,
      opens: detectOpenDirection($item),
      autoApply: false
    }
  );
};

module.exports = function () {
  $('.js-datetimerange').each(function () {
    var $fieldsDatetime = $(this);
    $fieldsDatetime.daterangepicker(buildOptions($fieldsDatetime));
  });
};
