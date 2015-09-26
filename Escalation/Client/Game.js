
app.controller('GameController', ['$scope','$rootScope', function ($scope,$rootScope) {


    $.connection.hub.logging = true;
    $.connection.hub.qs = {GameId=GameId};


    $scope.GameHub = $.connection.GameHub;
    $scope.GameHub.client.returnTest = function (s) { console.log(s); };
    
    $rootScope.client_report = function (s) {
        $scope.GameStateHub.server.client_report(s);
    }

    $scope.display_state(state){
        scope.GameStateHub.server.download_game_state()
            .then(JSON.parse)
            .done(function (g) {
                retrocycle(g);
                $scope.gameState = g;
                $scope.$apply();
            });
    }

    $.connection.hub
        .start()
        .done(function () {
            
            $rootScope.client_report("GameController started");
            $scope.display_state();
        });


}]);
