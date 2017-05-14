var gulp = require('gulp');
var del = require('del');
var config = require('config');

gulp.task('clean', function (cb) {
  if (config.args['skip-clean'] === true) {
    return cb();
  }

  del([
    config.build.destAssets,
    config.html.dest
  ], {
    force: true
  }, cb);
});
