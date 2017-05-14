var gulp = require('gulp');
var shell = require('gulp-shell');
var config = require('config');
var path = require('path');
var del = require('del');

gulp.task('docs:server', ['docs:build'], shell.task(['sphinx-autobuild -b html . ' + path.resolve(config.docs.dest)], {cwd: config.docs.src}));
gulp.task('docs:build', ['docs:clean'], shell.task([
  'sphinx-build -b html . ' + path.resolve(config.docs.dest)
], {cwd: config.docs.src}));

gulp.task('docs:clean', function (cb) {
  if (config.args['skip-clean'] === true) {
    return cb();
  }

  del([
    config.docs.dest,
  ], {
    force: true
  }, cb);
});
