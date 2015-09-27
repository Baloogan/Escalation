
app.controller('GameController', ['$scope', '$rootScope', function ($scope, $rootScope) {


    $.connection.hub.logging = true;
    $.connection.hub.qs = { GameId: GameId };
    $scope.game = null;
    $scope.state = null;
    $scope.vertex = null;

    $scope.GameHub = $.connection.GameHub;
    $scope.GameHub.client.returnTest = function (s) { console.log(s); };

    $rootScope.client_report = function (s) {
        $scope.GameHub.server.client_report(s);
    }
    $scope.edge_click = function (edgeName) {
        $rootScope.client_report("Edge: " + edgeName);
        $scope.GameHub.server.choose_edge($scope.state.StateId, edgeName)
            .done(function () {
                $scope.display_state();
            });
    }

    $scope.display_state = function () {

        $scope.GameHub.server.download_game()
            .then(JSON.parse)
            .done(function (g) {
                retrocycle(g);
                $scope.game = g;
                $scope.$apply();
            });

        $scope.GameHub.server.download_game_state()
            .then(JSON.parse)
            .done(function (s) {
                retrocycle(s);
                $scope.state = s;
                $scope.GameHub.server.download_vertex($scope.state.StateId)
                    .then(JSON.parse)
                    .done(function (v) {
                        retrocycle(v);
                        $scope.vertex = v;
                        $scope.$apply();
                        $rootScope.client_report("Vertex: " + v.Name);
                    });
            });

        $rootScope.client_report("display_state");
    }

    $.connection.hub
        .start()
        .done(function () {


            $rootScope.client_report("GameController started");

            $scope.display_state();

        }).fail(function (error) {
            console.log('Invocation of start failed. Error: ' + error)
        });;


}]);
