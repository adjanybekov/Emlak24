var config = require('config');
var gulp = require('gulp');
var sizereport = require('gulp-sizereport');

gulp.task('size-report', function () {

  return gulp.src([
      config.build.destAssets + '/**/*.{min.css,min.js}'
    ])
    .pipe(sizereport({
      gzip: true
    }));
});
