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
      .state('breweryList', {
        url: '/breweries',
        templateProvider: ['$q', function($q) {
           var deferred = $q.defer();
  
           require.ensure([], function() {
              var template = require('html!./breweryModule/breweries.html');
              deferred.resolve(template);
           });
           return deferred.promise;
        }],
        controller: 'BreweryCtrl',
        resolve: ['$q', '$ocLazyLoad', function($q, $ocLazyLoad) {
           var deferred = $q.defer();
  
           require.ensure([], function() {
              var mod = require('./breweryModule/module');
              $ocLazyLoad.load({
                  name: 'breweryModule',
              });
              deferred.resolve(mod.controller);
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