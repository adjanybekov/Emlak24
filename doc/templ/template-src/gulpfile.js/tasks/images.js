var browserSync = require('browser-sync');
var changed = require('gulp-changed');
var config = require('config');
var gulp = require('gulp');
// var imagemin = require('gulp-imagemin');
var gulpSequence = require('gulp-sequence');
var _ = require('lodash');
var
  svgSprite = require('gulp-svg-sprite'),
  plumber = require('gulp-plumber'),
  inject = require('gulp-inject'),
  svgmin = require('gulp-svgmin')
  ;


function process(src, dest) {
  return gulp.src(src)
    .pipe(changed(dest)) // Ignore unchanged files
    // .pipe(imagemin()) // Optimize
    .pipe(gulp.dest(dest))
    .pipe(browserSync.reload({stream: true}));
}

gulp.task('images', function (cb) {
  var isThere = require("is-there");
  var tasks = [
    'images:img',
    'images:demo',
    [
      'images:generate-svg',
      'images:html-inject-svg'
    ],
    cb
  ];

  if (config.target == 'wp' || !isThere(config.images.srcDemo)) {
    tasks = _.without(tasks, 'images:demo');
  }
  return gulpSequence.apply(this, tasks);
});

gulp.task('images:img', function () {
  return process(config.images.srcGlob, config.images.dest);
});

gulp.task('images:demo', function () {
  return process(config.images.srcDemoGlob, config.images.destDemo);
});

gulp.task('images:generate-svg', ['images:generate-inline-svg'], function () {
  return gulp.src([
      config.images.srcSvgGlob,
      config.images.srcSvgGlobVendor
    ])
    .pipe(changed(config.images.dest))
    .pipe(svgmin(config.images.svgminSettings))
    .pipe(plumber())
    .pipe(svgSprite(config.images.svgSpriteSettings))
    .on('error', function (error) {
      console.log(error);
    })
    .pipe(gulp.dest(config.images.dest))
    .pipe(browserSync.reload({stream: true}))
    ;
});

gulp.task('images:generate-inline-svg', function () {
  return gulp.src([
      config.images.srcSvgGlob,
      config.images.srcSvgGlobVendor
    ])
    .pipe(svgmin(config.images.svgminSettings))
    .pipe(plumber())
    .pipe(svgSprite(config.images.svgSpriteSettingsInline))
    .on('error', function (error) {
      console.log(error);
    })
    .pipe(gulp.dest(config.images.dest))
    .pipe(browserSync.reload({stream: true}))
    ;
});

gulp.task('images:html-inject-svg', function () {
  var transform = function (filePath, file) {
    return file.contents.toString();
  };

  return gulp
    .src(config.html.destGlob)
    .pipe(inject(gulp.src(config.images.destInlineSprite), {transform: transform}))
    .pipe(gulp.dest(config.build.dest))
    ;
});


