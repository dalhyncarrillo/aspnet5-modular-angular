/// <reference path="../typings/angularjs/angular.d.ts" />

var angular: ng.IAngularStatic = require('angular');
require('ui.router');
import Module2Ctrl = require('./Module2Ctrl');

var m2Module = angular.module('module2Module', []);
m2Module.controller('Module2Ctrl', Module2Ctrl.Module2Ctrl);

export = m2Module;