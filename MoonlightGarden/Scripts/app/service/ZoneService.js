angular.module('mgApp').factory('ZoneService', ['MG', function (MG) {
    return {
        loadZone: function (zoneId, callback) {
            MG.api('Zone/Load/' + zoneId, callback);
        },
        moveTo: function(location) {
            if (location) {
                MG.renderView('Zone/' + location);
            } else {
                MG.renderView('Barrack');
            }
        },
        explore: function (zoneId, callback) {
            MG.api('Zone/Explore/' + zoneId, callback);
        },
        isSafeZone: function (zoneType) {
            return "SafeZone" === zoneType;
        }
    };
}]);