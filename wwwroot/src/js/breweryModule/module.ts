/// <reference path="../typings/angularjs/angular.d.ts" />

var angular: ng.IAngularStatic = require('angular');
require('ui.router');
import BreweryCtrl = require('./BreweryCtrl');

var breweryModule = angular.module('breweryModule', []);
breweryModule.controller('BreweryCtrl', BreweryCtrl.BreweryCtrl);

export = breweryModule;