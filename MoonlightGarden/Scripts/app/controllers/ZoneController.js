angular.module('mgApp').controller('ZoneController', ['$scope', '$routeParams', 'cardImgUri', 'bossImgUri', 'mobImgUri', 'ZoneService', function ($scope, $routeParams, cardImgUri, bossImgUri, mobImgUri, ZoneService) {
    ZoneService.loadZone($routeParams.zoneId, function (data) {
        angular.extend($scope, data);
    });

    $scope.cardImgUri = cardImgUri;
    $scope.bossImgUri = bossImgUri;
    $scope.mobImgUri = mobImgUri;

    $scope.isSafeZone = ZoneService.isSafeZone;

    $scope.moveTo = ZoneService.moveTo;

    $scope.explore = function () {
        ZoneService.moveTo($routeParams.zoneId + '/Explore');
    }
}]);