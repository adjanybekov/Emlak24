var d = require('config/defer').deferConfig;
var prefix = './node_modules/';
var prefixSrc = './src/';

module.exports = {
  dest: d(function (config) {
    return config.build.destAssets + '/fonts';
  }),
  copy: [
    {
      task: 'font-awesome-fonts',
      from: prefix + 'font-awesome/fonts/**',
      to: d(function (config) {
        return config.fonts.dest + '/font-awesome';
      })
    },
    {
      task: 'bootstrap-fonts',
      from: prefix + 'bootstrap-sass/assets/fonts/bootstrap/**',
      to: d(function (config) {
        return config.fonts.dest + '/bootstrap';
      })
    },
    {
      task: 'slick-fonts',
      from: prefix + 'slick-carousel/slick/fonts/**',
      to: d(function (config) {
        return config.fonts.dest + '/slick';
      })
    },
    {
      task: 'local-fonts',
      from: prefixSrc + 'assets/fonts/**',
      to: d(function (config) {
        return config.fonts.dest;
      })
    },
    {
      task: 'php',
      from: d(function (config) {
        return config.build.src + '/php/**';
      }),
      to: d(function (config) {
        return config.build.dest + '/php';
      })
    }
  ]
};


