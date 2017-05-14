var browserSync = require('browser-sync');
var gulp = require('gulp');
var config = require('config');
var connect = require('gulp-connect-php');
gulp.task('browserSync', function () {
  if (config.args['php-server']) {
    connect.server(config.server.php, function () {
      browserSync((config.browserSync.proxy));
    });
  } else {
    return browserSync(config.browserSync.direct);
  }
});

gulp.task('browserSync:reload', browserSync.reload);
