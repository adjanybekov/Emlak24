var path = require('path');
var d = require('config/defer').deferConfig;

module.exports = {
  src: d(function (config) {
    return config.build.srcAssets + '/sass';
  }),
  dest: d(function (config) {
    return config.build.destAssets + '/css';
  }),
  pubDest: d(function (config) {
    return config.build.pubDestAssets + 'css';
  }),
  autoprefixer: {browsers: ['last 2 version', 'safari 5', 'ie 8', 'ie 9', 'opera 12.1']},
  watch: d(function (config) {
    return config.css.src + '/**/*.{sass,scss}'
  }),

  entrySassFiles: {
    defaulTheme: {
      src: d(function (config) {
        return config.css.src + '/colors/theme-default.sass'
      }),
      recompileOnChange: true
    },
    vendorTheme: {
      src: d(function (config) {
        return config.css.src + '/vendor.sass'
      }),
      recompileOnChange: true
    },
    uiPanel: {
      src: d(function (config) {
        return config.css.src + '/ui-panel.sass'
      }),
      recompileOnChange: false
    },
    email: {
      src: d(function (config) {
        return config.css.src + '/email.sass'
      }),
      recompileOnChange: false
    },
    custom: {
      src: d(function (config) {
        return config.css.src + '/custom.sass'
      }),
      recompileOnChange: false
    },
    iefix: {
      src: d(function (config) {
        return config.css.src + '/ie-fix.sass'
      }),
      recompileOnChange: true
    },
    fontAwesome: {
      src: d(function (config) {
        return config.css.src + '/font-awesome.sass'
      }),
      recompileOnChange: false
    },
    allThemes: {
      src: d(function (config) {
        return config.css.src + '/colors/*.sass'
      }),
      recompileOnChange: false,
      independent: false
    }
  },
  compilerSettings: {
      outputStyle: 'expanded',
      includePaths: [
      './vendor/',
      './node_modules/',
      './node_modules/bootstrap-sass/assets/stylesheets/'
    ],
    noCache: false
  }
};

