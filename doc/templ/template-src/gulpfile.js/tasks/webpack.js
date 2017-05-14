var assign = require('object-assign');
var config = require('config');
var gulp = require('gulp');
var logger = require('../lib/compileLogger');
var webpack = require('webpack');
var browserSync = require('browser-sync');
var uglify = require('gulp-uglify');
var rename = require('gulp-rename');
var changed = require('gulp-changed');
var gulpSequence = require('gulp-sequence');

gulp.task('webpack', ['webpack:copy-js'], function (callback) {
  if (config.env === 'dev') {
    var built = false;

    webpack(config.js.webpack.app).watch(200, function (err, stats) {
      logger(err, stats);
      browserSync.reload();
      // On the initial compile, let gulp know the task is done
      if (!built) {
        built = true;
        callback();
      }

    })
  } else {
    webpack(config.js.webpack.app, function (err, stats) {
      logger(err, stats);
      gulpSequence('webpack:minify', callback);
    });
  }
});


gulp.task('webpack:copy-js', function () {
  return gulp.src(config.js.copy)
    .pipe(changed(config.js.dest))
    .pipe(gulp.dest(config.js.dest))
    .pipe(browserSync.stream());

});

gulp.task('webpack:minify', function () {
  return gulp.src(config.js.dest + '/**/*.js')
    .pipe(uglify())
    .pipe(rename({
      suffix: '.min'
    }))
    .pipe(gulp.dest(config.js.dest));
});

