/// <reference path="../typings/angularjs/angular.d.ts" />

export class Module2Ctrl {
	public message: string;

	// $inject annotation.
	// It provides $injector with information about dependencies to be injected into constructor
	// it is better to have it close to the constructor, because the parameters must match in count and type.
	// See http://docs.angularjs.org/guide/di
	public static $inject = [
		'$scope',
		'$location'
	];

	// dependencies are injected via AngularJS $injector
	constructor(
		private $scope: ng.IScope,
		private $location: ng.ILocationService
	) {
		this.message = 'Welcome to Module 2!';
	}
}