angular.module('mgApp').controller('masterDataController', 
['$scope', '$routeParams', 'masterDataTypeList', 'repository', 'cardImgUri', 'equipImgUri', 
function ($scope, $routeParams, masterDataTypeList, repository, cardImgUri, equipImgUri) {
  repository[$routeParams.masterDataType].get(function(response) {
    if (response.success) {
      angular.extend($scope, {
        TypeList: masterDataTypeList,
        Type: $routeParams.masterDataType,
        List: response.data,        
        cardImgUri: cardImgUri,
        buffInfo: function(buff, buffLv) {
          return buff + " Lv." + buffLv;
        },
        equipImgUri: equipImgUri
      })
    }
  });
}]);