var gulp = require('gulp');
var gulpSequence = require('gulp-sequence');

gulp.task('build:dev', ['bower'], function (cb) {
  //changelog
  global.isWatching = true;
  gulpSequence(
    'clean',
    [
      'images',
      'copy'
    ],
    [
      'sass',
      'webpack',
      'jade'
    ],
    'preprocess',
    'browserSync',
    'watch',
    cb
  );
});

gulp.task('build:release', ['bower'], function (cb) {
  gulpSequence(
    'clean',
    [
      'images',
      'copy'
    ],
    [
      'sass',
      'webpack'
    ],
    'jade',
    'preprocess',
    'html:validate',
    'size-report',
    cb
  )
  ;
});
