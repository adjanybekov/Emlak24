var d = require('config/defer').deferConfig;
var path = require('path');

module.exports = {
  paths: {
    demo: d(function (config) {
      return path.join(config.js.dest, 'demo.js');
    })
  }
};