var notifier = require('../notifier');
exports.enable = function () {
  $(document)
    .ajaxError(function (event, request, settings) {
      if (request.status === 500) {
        notifier.showServerError();
      } else {
        if (request.responseJSON.error) {
          notifier.showError(request.responseJSON.error);
        }
      }
    })
    .ajaxSuccess(function (event, request) {
      if (request.responseJSON && request.responseJSON.result && request.responseJSON.result.message) {
        notifier.showSuccess(request.responseJSON.result.message);
      }
    })
  ;
};