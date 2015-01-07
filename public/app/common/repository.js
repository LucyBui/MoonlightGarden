angular.module('mgApp').factory('repository', ['$resource', function($resource) {
  return {
    Family: $resource('data/family.json', {}, {
      get: {method:'GET', isArray: false}
    }),
    Card: $resource('data/card.json', {}, {
      get: {method:'GET', isArray: false}
    }),
    Equip: $resource('data/equip.json', {}, {
      get: {method:'GET', isArray: false}
    }),
    Zone: $resource('data/zone.json', {}, {
      get: {method:'GET', isArray: false}
    }),
    Monster: $resource('data/monster.json', {}, {
      get: {method:'GET', isArray: false}
    })
  };
}]);