var gulp = require('gulp');
var preprocess = require('gulp-preprocess');
var path = require('path');
var config = require('config');
var _ = require('lodash');

gulp.task('preprocess', function () {
  var paths = _.values(config.preprocess.paths);
  return gulp.src(paths, {base: './'})
    .pipe(preprocess())
    .pipe(gulp.dest('./'))
    ;
});