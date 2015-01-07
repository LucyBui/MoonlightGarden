angular.module('mgApp').controller('barrackController', 
['$scope', 'repository', 'cardImgUri', 
function ($scope, repository, cardImgUri) {
  repository.Family.get(function(response) {
    if (response.success) {
      angular.extend($scope, {
        Family: response.data,
        cardImgUri: cardImgUri
      })
    }
  });
}]);