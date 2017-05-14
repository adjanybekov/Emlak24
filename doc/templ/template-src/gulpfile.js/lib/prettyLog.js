var gutil = require("gulp-util");

module.exports = function (message) {
  gutil.log(gutil.colors.cyan(message));
};
