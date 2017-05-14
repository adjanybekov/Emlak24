var gulp = require('gulp');
var express = require('express');
var config = require('config');
var gutil = require('gulp-util');
var compress = require('compression');
var logger = require('morgan');
var open = require('open');
var serveIndex = require('serve-index');

gulp.task('server', function () {
  var url = 'http://localhost:' + config.server.node.port;

  express()
  //.use(compress())
    .use(logger(config.server.node.logLevel))
    .use('/', serveIndex(config.server.node.root, {'icons': true}))
    .use('/', express.static(config.server.node.root, config.server.node.staticOptions))
    .listen(config.server.node.port);

  gutil.log('production server started on ' + gutil.colors.green(url));
  open(url);
});

