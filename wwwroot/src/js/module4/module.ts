/// <reference path="../typings/angularjs/angular.d.ts" />

var angular: ng.IAngularStatic = require('angular');
require('ui.router');
import Module4Ctrl = require('./Module4Ctrl');

var m4Module = angular.module('module4Module', []);
m4Module.controller('Module4Ctrl', Module4Ctrl.Module4Ctrl);

export = m4Module;