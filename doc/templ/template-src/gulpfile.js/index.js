/*
 gulpfile.js
 ===========
 Rather than manage one giant configuration file responsible
 for creating multiple tasks, each task has been broken out into
 its own file in gulpfile.js/tasks. Any files in that directory get
 automatically required below.

 To add a new task, simply add a new task file that directory.
 gulpfile.js/tasks/default.js specifies the default set of tasks to run
 when you run `gulp`.
 */

process.env.NODE_CONFIG_DIR = './gulpfile.js/config';

var requireDir = require('require-dir');
var matched = false;
var _ = require('lodash');

process.argv.slice(2).forEach(function (arg) {
  if (_.startsWith(arg, 'build:')) {
    process.env.NODE_ENV = arg.slice(6);
    matched = true;
  } else if (arg === 'server') {
    process.env.NODE_ENV = 'release';
    matched = true;
  }
});

if (!matched) {

  var minimist = require('minimist');
  var knownOptions = {
    string: [
      'env'
    ],
    default: {
      'env': 'dev'
    }
  };

  var options = minimist(process.argv.slice(2), knownOptions);
  process.env.NODE_ENV = options.env;
}

// Require all tasks in gulp/tasks, including subfolders
requireDir('./tasks', {recurse: true});