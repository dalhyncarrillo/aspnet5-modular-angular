/// <reference path="typings/angularjs/angular.d.ts" />

//declare function require(string): any;

var angular: ng.IAngularStatic = require('angular');
require('ui.router');
require('oclazyload');
import AppCtrl = require('./AppCtrl');

var csWebApp = angular.module('csWebApp', ['ui.router', 'oc.lazyLoad']);
csWebApp.config(['$stateProvider', '$locationProvider', '$urlRouterProvider', '$ocLazyLoadProvider', 
  function($stateProvider, $locationProvider, $urlRouterProvider, $ocLazyLoadProvider) {
    $urlRouterProvider
        .otherwise('/');
        
    $stateProvider
	    .state('home', {
	          url: '/',
	          templateUrl: 'src/js/home.html',
	          controller: AppCtrl.AppCtrl,
            controllerAs: 'appVm'
	    })
      .state('breweryModule', {
        url: '/breweries',
        templateProvider: ['$q', function($q) {
           var deferred = $q.defer();
  
           require.ensure([], function() {
              var template = require('./breweryModule/breweries.html');
              deferred.resolve(template);
           });
           return deferred.promise;
        }],
        controller: 'BreweryCtrl',
        controllerAs: 'breweryVm',
        resolve: ['$q', '$ocLazyLoad', function($q, $ocLazyLoad) {
           var deferred = $q.defer();
  
           require.ensure([], function() {
              var mod = require('./breweryModule/module');
              $ocLazyLoad.load({
                  name: 'breweryModule',
              });
              deferred.resolve(mod);
           });
  
           return deferred.promise;
        }]
     })
     .state('module2', {
        url: '/module2',
        templateProvider: ['$q', function($q) {
           var deferred = $q.defer();
  
           require.ensure([], function() {
              var template = require('./module2/module2.html');
              deferred.resolve(template);
           });
           return deferred.promise;
        }],
        controller: 'Module2Ctrl',
        controllerAs: 'm2Vm',
        resolve: ['$q', '$ocLazyLoad', function($q, $ocLazyLoad) {
           var deferred = $q.defer();
  
           require.ensure([], function() {
              var mod = require('./module2/module');
              $ocLazyLoad.load({
                  name: 'module2Module',
              });
              deferred.resolve(mod);
           });
  
           return deferred.promise;
        }]
     })
     .state('module3', {
        url: '/module3',
        templateProvider: ['$q', function($q) {
           var deferred = $q.defer();
  
           require.ensure([], function() {
              var template = require('./module3/module3.html');
              deferred.resolve(template);
           });
           return deferred.promise;
        }],
        controller: 'Module3Ctrl',
        controllerAs: 'm3Vm',
        resolve: ['$q', '$ocLazyLoad', function($q, $ocLazyLoad) {
           var deferred = $q.defer();
  
           require.ensure([], function() {
              var mod = require('./module3/module');
              $ocLazyLoad.load({
                  name: 'module3Module',
              });
              deferred.resolve(mod);
           });
  
           return deferred.promise;
        }]
     })     
     .state('module4', {
        url: '/module4',
        templateProvider: ['$q', function($q) {
           var deferred = $q.defer();
  
           require.ensure([], function() {
              var template = require('./module4/module4.html');
              deferred.resolve(template);
           });
           return deferred.promise;
        }],
        controller: 'Module4Ctrl',
        controllerAs: 'm4Vm',
        resolve: ['$q', '$ocLazyLoad', function($q, $ocLazyLoad) {
           var deferred = $q.defer();
  
           require.ensure([], function() {
              var mod = require('./module4/module');
              $ocLazyLoad.load({
                  name: 'module4Module',
              });
              deferred.resolve(mod);
           });
  
           return deferred.promise;
        }]
     });

    $locationProvider.html5Mode(false);
}]);

// TODO: Remove ui-router debugging code
csWebApp.run(($rootScope) => {
  $rootScope.$on("$stateChangeError", console.log.bind(console));
});