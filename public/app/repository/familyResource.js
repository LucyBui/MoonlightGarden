angular.module('mgApp').factory('familyResource', ['$resource', function($resource) {
  return $resource('/api/family/:id');
}]);