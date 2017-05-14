var gulp = require('gulp');
var bower = require('gulp-bower');
var replace = require('gulp-replace');

gulp.task('bower', function (cb) {
  return bower()
    .pipe(gulp.dest('./vendor/'));
});

