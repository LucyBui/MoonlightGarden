angular.module('mgApp').factory('Cache', ['$cacheFactory', function ($cacheFactory) {
    return $cacheFactory('Cache');
}]);