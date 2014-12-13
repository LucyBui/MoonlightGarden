angular.module('mgApp').factory('BarrackService', ['MG', function (MG) {
    return {
        loadFamily: function(callback) {
            MG.api('Barrack', callback);
        },
        addCard: function (team, cardId) {
            if (team.length < 3) {
                team.push(cardId);
            }            
        },
        removeCard: function (team, cardId) {
            var cardIndex = team.indexOf(cardId);
            if (cardIndex > -1) {
                team.splice(cardIndex, 1);
            }
        },
        moveTo: function (team, location) {
            MG.api('Barrack/SaveTeam', team, 'PUT', function (data) {
                MG.renderView('Zone/' + location);
            });
        }
    };
}]);