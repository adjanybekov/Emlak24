var d = require('config/defer').deferConfig;
module.exports = {
  node: {
    root: d(function (config) {
      return process.cwd() + config.build.dest.substr(1);
    }),
    port: process.env.PORT || 5000,
    logLevel: process.env.NODE_ENV ? 'combined' : 'dev',
    staticOptions: {
      extensions: ['html'],
      maxAge: '31556926'
    }
  },
  php: {
    base: d(function (config) {
      return process.cwd() + config.build.dest.substr(1);
    }),
    port: 8000,
    open: false,
    silent: true
  }
};
