var changed = require('gulp-changed');
var config = require('config');
var gulp = require('gulp');
var inject = require('gulp-inject');

gulp.task('ga:html-inject', function () {
  var transform = function (filePath, file) {
    return '<script>' + file.contents.toString() + '</script>';
  };

  return gulp
    .src(config.html.destGlob)
    .pipe(inject(gulp.src(config.js.srcGA), {
        transform: transform,
        starttag: '<!-- inject:ga -->'
      }
    ))
    .pipe(gulp.dest(config.build.dest))
    ;
});


