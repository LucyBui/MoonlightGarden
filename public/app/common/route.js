angular.module('mgApp').config(['$routeProvider', function ($routeProvider) {
  $routeProvider
    .when('/Barrack', {
      templateUrl: 'app/view/barrack.html',
      controller: 'barrackController'
    })
    .when('/MasterData/:masterDataType', {
      templateUrl: 'app/view/masterData.html',
      controller: 'masterDataController'
    })
    .otherwise({
      redirectTo: '/Barrack'
    });
}])