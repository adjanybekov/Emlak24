var gulp = require('gulp');
var config = require('config');

var tasks = [];

config.fonts.copy.forEach(function (entry) {
  var taskName = 'copy:' + entry.task;
  tasks.push(taskName);
  (function (entry) {
    gulp.task(taskName, function () {
      return gulp.src(entry.from)
        .pipe(gulp.dest(entry.to))
        ;
    });
  })(entry);
});

gulp.task('copy', tasks);
