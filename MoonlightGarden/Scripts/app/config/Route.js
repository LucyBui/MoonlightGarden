angular.module('mgApp').config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/Barrack', {
            templateUrl: 'Scripts/app/views/Barrack.html',
            controller: 'BarrackController'
        })
        .when('/Zone/:zoneId', {
            templateUrl: 'Scripts/app/views/Zone.html',
            controller: 'ZoneController'
        })
        .when('/Zone/:zoneId/Explore', {
            templateUrl: 'Scripts/app/views/Explore.html',
            controller: 'ExploreController'
        })
        .otherwise({
            redirectTo: '/Barrack'
        });
}])