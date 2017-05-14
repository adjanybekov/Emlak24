var d = require('config/defer').deferConfig;
var webpack = require('webpack');
var webpackPlugins = require('./includes/js').webpack.app.plugins;

webpackPlugins.push(
  new webpack.DefinePlugin({
    'process.env': {
      'NODE_ENV': JSON.stringify('production')
    }
  }),
  new webpack.optimize.DedupePlugin(),
  new webpack.NoErrorsPlugin()
);

module.exports = {
  target: 'tpl',
  env: 'release',
  build: {
    dest: './../template_build'
  },
  js: {
    webpack: {
      app: {
        plugins: webpackPlugins
      }
    }
  }
};