angular.module('mgApp').controller('BarrackController', ['$scope', 'cardImgUri', 'BarrackService', function ($scope, cardImgUri, BarrackService) {
    BarrackService.loadFamily(function (data) {
        angular.extend($scope, {
            Family : data
        });       
    });

    $scope.cardImgUri = cardImgUri;
    $scope.addCard = function(cardId) {
        BarrackService.addCard($scope.Family.Profile.Team, cardId);
    }
    $scope.removeCard = function(cardId) {
        BarrackService.removeCard($scope.Family.Profile.Team, cardId);
    }
    $scope.moveTo = function (location) {
        BarrackService.moveTo($scope.Family.Profile.Team, location);
    }
}]);