var path = require('path');
var webpack = require('webpack');
var BowerWebpackPlugin = require("bower-webpack-plugin");
var ExtractTextPlugin = require("extract-text-webpack-plugin");
var d = require('config/defer').deferConfig;
var SplitByPathPlugin = require('webpack-split-by-path');
module.exports = {
  src: d(function (config) {
    return config.build.srcAssets + '/js';
  }),
  srcGA: d(function (config) {
    return config.build.src + '/jade/ga.js';
  }),
  dest: d(function (config) {
    return config.build.destAssets + '/js';
  }),
  destGlob: d(function (config) {
    return config.build.destAssets + '/js/**/*.js';
  }),
  pubDest: d(function (config) {
    return config.build.pubDestAssets + 'js';
  }),
  copy: d(function (config) {
    return config.js.src + '/{demodata,demo}.js';
  }),
  webpack: {
    app: {
      context: d(function (config) {
        return path.resolve(config.build.srcAssets);
      }),
      entry: {
        app: './js/app.js'
      },
      output: {
        path: d(function (config) {
          return config.build.destAssets
        }),
        pathinfo: true,
        filename: "js/[name].js",
        chunkFilename: "js/[name].js",
        library: 'app',
        libraryTarget: 'var',
        publicPath: d(function (config) {
          return config.build.pubDestAssets;
        })
      },
      plugins: [
        new webpack.ProvidePlugin({
          $:      "jquery",
          jQuery: "jquery"
        }),
        new BowerWebpackPlugin({
          modulesDirectories: ["vendor"],
          manifestFiles: "bower.json",
          excludes: [
            /\.css/,
            /fonts/,
            /.(png|jpg|gif)/,
            /pnotify\.(buttons|callbacks|confirm|desktop|history|nonblock)/,
            /leaflet.js/,
            /\.(png|jpg|gif|svg|sass|less|scss)/,
            /pnotify\.(buttons|callbacks|confirm|desktop|history|nonblock)/,
            /dist\/plyr\.js/,
            /dist\\plyr\.js/
          ],
          searchResolveModulesDirectories: false
        }),
        new ExtractTextPlugin("css/[name].css", {
          //allChunks: true
        }),
        new SplitByPathPlugin([
          {
            name: 'vendor',
            path: [
              path.join(path.resolve('./'), 'node_modules'),
              path.join(path.resolve('./'), 'vendor')
            ]
          }
        ])
      ],
      resolve: {
        extensions: ['', '.js']
      },
      module: {
        loaders: [
          {test: /jquery\.js$/, loader: 'expose?$'},
          {test: /jquery\.js$/, loader: 'expose?jQuery'},
          {test: /dropzone/, loader: 'expose?Dropzone'},
          {test: /google\-marker\-clusterer\-plus/, loader: 'exports?MarkerClusterer'},
          {test: /google-infobox/, loader: 'exports?InfoBox'},
          {test: /plyr/, loader: 'imports?this=>window'},
          {
            test: /\.css$/,
            loader: ExtractTextPlugin.extract("css-loader")
          },
          {
            test: /\.woff(\?v=\d+\.\d+\.\d+)?$/,
            loader: "file",
            query: {
              name: 'fonts/fa/[name].[ext]'
            }
          }, {
            test: /\.woff2(\?v=\d+\.\d+\.\d+)?$/,
            loader: "file",
            query: {
              name: 'fonts/fa/[name].[ext]'
            }
          }, {
            test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/,
            loader: "file",
            query: {
              name: 'fonts/fa/[name].[ext]'
            }
          }, {
            test: /\.eot(\?v=\d+\.\d+\.\d+)?$/,
            loader: "file",
            query: {
              name: 'fonts/fa/[name].[ext]'
            }
          }, {
            test: /\.svg(\?v=\d+\.\d+\.\d+)?$/,
            loader: "file",
            query: {
              name: 'fonts/fa/[name].[ext]'
            }
          }
        ]
      }
    }

  }
};
