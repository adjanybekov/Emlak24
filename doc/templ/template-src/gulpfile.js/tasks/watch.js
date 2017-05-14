var gulp = require('gulp');
var config = require('config');
var watch = require('gulp-watch');
var gulpSequence = require('gulp-sequence');
var _ = require('lodash');

gulp.task('watch', function () {
  global.isWatching = true;
  watch(config.images.srcGlob, function () {
    gulp.start('images');
  });
  watch(config.css.watch, function () {
    gulp.start('sass');
  });
  watch(config.html.watch, function () {
    gulp.start('jade');
  });
  watch(config.html.inlineCssWatch, function () {
    gulp.start('jade');
  });
  watch(config.js.copy, function () {
    gulp.start('webpack:copy-js');
  });

  watch(_.map(config.fonts.copy, 'from'), function () {
    gulp.start('copy');
  });
});
