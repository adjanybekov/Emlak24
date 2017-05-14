var gulp = require('gulp'),
  gutil = require('gulp-util'),
  notifier = require('node-notifier'),
  browserSync = require('browser-sync'),
  reload = browserSync.reload,
  inlineCss = require('gulp-inline-css')
  ;

// Build our templates
gulp.task('email:build', function () {
  return gulp.src('./email/html/*.html')
    .pipe(inlineCss())
    .pipe(gulp.dest('./'))
    .pipe(reload({stream: true}));
});

// Watch Files For Changes
gulp.task('email:watch', function () {
  gulp.watch('./email/sass/**/*.sass', ['email:styles']);
  gulp.watch('./email/html/*.html', ['email:build']);
  gulp.watch('./email/css/*.css', ['email:build']);
});

// Default Task
gulp.task('email', ['email:styles', 'email:build', 'email:watch']);
