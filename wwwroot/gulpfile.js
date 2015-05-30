'use strict';
var gulp       = require('gulp');
var sass       = require('gulp-sass');
var sourcemaps = require('gulp-sourcemaps');
//var plumber    = require('gulp-plumber');
var del        = require('del');
var pkg        = require('./package.json');
var webpack    = require('gulp-webpack-build');
var path       = require('path');
var tslint     = require('gulp-tslint');
//var run        = require('gulp-run');
//var rev        = require('gulp-rev');

gulp.task('css', ['clean'], function () {
  return gulp.src(pkg.paths.source.css)
    .pipe(sourcemaps.init())
    .pipe(sass({
        errLogToConsole: true
    }))
    .pipe(sourcemaps.write())
    .pipe(gulp.dest(pkg.paths.dest.css));
});

gulp.task('lint', [], function() {
    return gulp.src(pkg.paths.source.js)
        .pipe(tslint());
});

gulp.task('clean', function (cb) {
  del([
    pkg.paths.dest.css,
    pkg.paths.dest.js
  ], cb);
});

gulp.task('watch', ['build'], function() {
    gulp.watch(pkg.paths.source.css, ['css']);
    gulp.watch(pkg.paths.source.js).on('change', function(event) {
        if (event.type === 'changed') {
            gulp.src(webpack.config.CONFIG_FILENAME)
                .pipe(webpack.configure(webpackConfig))
                .pipe(webpack.watch(function(err, stats) {
                    gulp.src(pkg.paths.source.js)
                        .pipe(webpack.proxy(err, stats))
                        .pipe(webpack.format({
                            verbose: true,
                            version: false
                        }))
                        .pipe(gulp.dest(pkg.paths.dest.js));
                }));
        }
    });
});

gulp.task('build', ['css', 'webpack']);
gulp.task('default', ['build']);

var webpackConfig = {
    useMemoryFs: true
};

gulp.task('webpack', ['clean', 'lint'], function() {
    return gulp.src(webpack.config.CONFIG_FILENAME)
        .pipe(webpack.configure(webpackConfig))
        .pipe(webpack.compile())
        .pipe(webpack.format({
            version: false,
            timings: true
        }))
        .pipe(webpack.failAfter({
            errors: true,
            warnings: true
        }))
        .pipe(gulp.dest(pkg.paths.dest.js));
});