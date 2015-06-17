/// <reference path="../typings/angularjs/angular.d.ts" />

var angular: ng.IAngularStatic = require('angular');
require('ui.router');
import Module3Ctrl = require('./Module3Ctrl');

var m3Module = angular.module('module3Module', []);
m3Module.controller('Module3Ctrl', Module3Ctrl.Module3Ctrl);

export = m3Module;