var d = require('config/defer').deferConfig;

module.exports = {
  direct: {
    files: [
      d(function (config) {
        return config.build.dest + '/**/*.html';
      })
    ],
    server: {
      baseDir: d(function (config) {
        return config.build.dest;
      })
    },
    open: false,
    port: 4000,
    directory: true,
    ghostMode: {
      clicks: false,
      forms: false,
      scroll: false
    },
    reloadDebounce: 1000
  },
  proxy: {
    proxy: d(function (config) {
      return 'localhost:' + config.server.php.port;
    }),
    open: false,
    port: d(function (config) {
      return config.browserSync.direct.port;
    })
  }
};