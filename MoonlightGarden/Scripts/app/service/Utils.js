angular.module('mgApp').factory('MG', ['$http', '$location', function ($http, $location) {
    return {
        api: function (url, data, method, callback) {
            if (!method) {
                callback = data;
                method = 'GET';
                data = null;
            }
            $http({
                url: 'api/' + url,
                method: method,
                data: data
            }).success(function (response) {
                // Yeah it works!
                callback(response.data, response.success);
            }).error(function (response) {
                // It's failed...
            });
        },
        renderView: function (url) {
            $location.path(url)
        }
    };
}]);