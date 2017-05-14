var d = require('config/defer').deferConfig;
var path = require('path');
module.exports = {
  src: d(function (config) {
    return path.join(config.build.src, 'docs');
  }),
  dest: d(function (config) {
    return path.join(config.docs.src, '_build/html');
  })
};