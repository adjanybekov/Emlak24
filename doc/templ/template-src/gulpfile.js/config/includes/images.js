var _ = require('lodash');
var prefix = './node_modules';
var bprefix = './vendor';
var d = require('config/defer').deferConfig;


var settings = {
  src: d(function (config) {
    return config.build.srcAssets + '/img';
  }),
  srcGlob: d(function (config) {
    return config.images.src + '/**';
  }),
  dest: d(function (config) {
    return config.build.destAssets + '/img';
  }),
  pubDest: d(function (config) {
    return config.build.pubDestAssets + 'img';
  }),
  srcDemo: d(function (config) {
    return config.build.srcAssets + '/media-demo';
  }),
  srcDemoGlob: d(function (config) {
    return config.images.srcDemo + '/**';
  }),
  destDemo: d(function (config) {
    return config.build.destAssets + '/media-demo';
  }),
  pubDestDemo: d(function (config) {
    return config.build.pubDestAssets + 'media-demo';
  }),
  srcSvgGlob: d(function (config) {
    return config.images.src + '/*.svg';
  }),
  srcSvgGlobVendor: bprefix + '/plyr/src/sprite/*.svg',
  destInlineSprite: d(function (config) {
    return config.images.dest + '/sprite-inline.svg';
  }),
  svgSpriteSettings: {
    mode: {
      symbol: {
        inline: false,
        dest: '.',
        sprite: 'sprite.svg'
      }
    }
  },
  svgminSettings: {
    js2svg: {
      pretty: true
    },
    plugins: [
      {removeTitle: true},
      {removeDesc: true}
    ]
  }
};

settings.svgSpriteSettingsInline = _.cloneDeep(settings.svgSpriteSettings);
settings.svgSpriteSettingsInline.mode.symbol.inline = true;
settings.svgSpriteSettingsInline.mode.symbol.sprite = 'sprite-inline.svg';

module.exports = settings;
