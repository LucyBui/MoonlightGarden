angular.module('mgApp').controller('ExploreController', ['$scope', '$routeParams', 'cardImgUri', 'bossImgUri', 'mobImgUri', 'ZoneService', function ($scope, $routeParams, cardImgUri, bossImgUri, mobImgUri, ZoneService) {
    ZoneService.explore($routeParams.zoneId, function (data) {
        angular.extend($scope, data);
        
    });

    $scope.cardImgUri = cardImgUri;
    $scope.bossImgUri = bossImgUri;
    $scope.mobImgUri = mobImgUri;
}]);