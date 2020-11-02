var gulp = require('gulp');
var ugify = require("gulp-uglify");
var concat = require("gulp-concat");

function defaultTask() {
  return gulp.src("wwwroot/js/**/*.js")
    .pipe(ugify())
    .pipe(concat("dutchtreat.min.js"))
    .pipe(gulp.dest("wwwroot/dist"));
}

exports.default = defaultTask;
