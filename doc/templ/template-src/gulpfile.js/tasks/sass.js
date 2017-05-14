var gulp = require('gulp');
var browserSync = require('browser-sync');
var sassnew = require('gulp-sass');
var sourcemaps = require('gulp-sourcemaps');
var handleErrors = require('../lib/handleErrors');
var autoprefixer = require('gulp-autoprefixer');
var _ = require('lodash');
var tasks = [];
var gutil = require('gulp-util');
var importCss = require('gulp-import-css');
var config = require('config');
var minify = require('gulp-minify-css');
var gulpSequence = require('gulp-sequence');
var rename = require('gulp-rename');
var firstStart = true;

gulp.task('sass', tasks, function () {
  if (firstStart === true) {
    firstStart = false;
  }
  if (config.env !== 'dev') {
    gulp.start('sass:minify');
  }
});

gulp.task('sass:minify', function () {
  return gulp.src(config.css.dest + '/**/*.css')
    .pipe(minify())
    .pipe(rename({
      suffix: '.min'
    }))
    .pipe(gulp.dest(config.css.dest));
});

for (var name in config.css.entrySassFiles) {
  var taskName = 'sass:' + name;
  if (!config.css.entrySassFiles[name].independent) {
    tasks.push(taskName);
  }
  (function (name, taskName) {
    gulp.task(taskName, function (cb) {
      if (firstStart === true || config.css.entrySassFiles[name].recompileOnChange === true) {
        return compile(config.css.entrySassFiles[name].src);
      }
      return cb;
    });
  })(name, taskName);
}


function compile(input) {
    return gulp.src(input)
        .pipe(sassnew(config.css.compilerSettings).on('error', sassnew.logError))
        .pipe(autoprefixer(config.css.autoprefixer))
        .pipe(gulp.dest(config.css.dest))
        .pipe(importCss())
        .pipe(gulp.dest(config.css.dest))
        .pipe(browserSync.stream({match: '**/*.css'}));
}