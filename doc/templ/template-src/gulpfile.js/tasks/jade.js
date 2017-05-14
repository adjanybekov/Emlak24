var browserSync = require('browser-sync');
var config = require('config');
var gulp = require('gulp');
var handleErrors = require('../lib/handleErrors');
var gulpFilter = require('gulp-filter');
var cached = require('gulp-cached');
var gulpif = require('gulp-if');
var gulpJade = require('gulp-jade');
var jadeInheritance = require('gulp-jade-inheritance');
var changed = require('gulp-changed');
var gutil = require('gulp-util');
var plumber = require('gulp-plumber');
var prettyLog = require('../lib/prettyLog');
var gulpSequence = require('gulp-sequence');
var inlineCss = require('gulp-inline-css');
var debug = require('gulp-debug');
var w3ccjs = require('gulp-w3cjs');
var htmlreplace = require('gulp-html-replace');
var firstRun = true;
var moment = require('moment');
var _ = require('lodash');

gulp.task('jade', function (cb) {
  var sequence = [
    'jade:compile',
    'images:html-inject-svg',
    'html:inline-css',
    'browserSync:reload'
  ];

  if (config.env !== 'dev' && config.env !== 'themeforest') {
    sequence.push('html:set-minified-assets');
  }

  sequence.push(cb);
  gulpSequence.apply(this, sequence);
});

gulp.task('html:validate', function () {
  return gulp.src(config.html.destGlob).
  pipe(w3ccjs());
});

gulp.task('jade:compile', function () {
  prettyLog('Compiling templates. Please wait, this operation may take a LONG TIME!');
  var pipe = gulp.src(config.html.srcGlob)
    .pipe(plumber({errorHandler: handleErrors}))
    //only pass changed *main* files and *all* the partials
    .pipe(gulpif(!config.args['jade-force'], changed(config.html.dest, {extension: '.html'})))
    //filter out unchanged partials, but it only works when watching
    .pipe(gulpif(global.isWatching, cached('jade')))
    //find files that depend on the files that have changed
    .pipe(gulpif(global.isWatching && !firstRun, jadeInheritance({basedir: config.html.src})))
    //filter out partials (folders and files starting with "_" )
    .pipe(gulpFilter(config.html.filterSettings))
    .pipe(debug())
    //process jade template
    .pipe(gulpJade(config.html.jadeSettings))
    .pipe(gulp.dest(config.html.dest))
    ;
  firstRun = false;

  return pipe;
});

gulp.task('html:inline-css', function () {
  return gulp.src(config.html.dest + '/email.html')
    .pipe(inlineCss())
    .pipe(gulp.dest(config.html.dest))
    ;
});

gulp.task('html:set-minified-assets', function () {
  prettyLog('Replacing html source assets with minified assets');
  var replacements = {
    'cssvendor': config.css.pubDest + '/vendor.min.css',
    'cssfontawesome': config.css.pubDest + '/font-awesome.min.css',
    'cssiefix': config.css.pubDest + '/ie-fix.min.css',
    'csstheme-default': config.css.pubDest + '/theme-default.min.css',
    'jsvendor': config.js.pubDest + '/vendor.min.js',
    'jsdemodata': config.js.pubDest + '/demodata.min.js',
    'jsapp': config.js.pubDest + '/app.min.js',
    'jsdemo': config.js.pubDest + '/demo.min.js'
  };
  var timestamp = moment().format('YYYYMMDDHHmm');

  replacements = _.mapValues(replacements, function (value) {
    return value + '?v=' + timestamp;
  });

  console.log(replacements);

  return gulp.src(config.html.destGlob)
    .pipe(htmlreplace(replacements))
    .pipe(gulp.dest(config.html.dest));

});
