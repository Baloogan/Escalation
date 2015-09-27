
app.controller('GameController', ['$scope', '$rootScope', '$window', function ($scope, $rootScope, $window) {

    var diffpatcher = jsondiffpatch.create();

    $.connection.hub.logging = true;
    $.connection.hub.qs = { GameId: GameId };
    $scope.game = null;

    $scope.state = null;
    $scope.vertex = null;

    $scope.game_str = null;
    $scope.state_str = null;
    $scope.vertex_str = null;

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
    $scope.debug_state = function () {
        $scope.game_str = JSON.stringify(JSON.decycle($scope.game), null, 4);
        $scope.state_str = JSON.stringify(JSON.decycle($scope.state), null, 4);
        $scope.vertex_str = JSON.stringify(JSON.decycle($scope.vertex), null, 4);
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
                $window.document.title = $scope.state.Title
                $scope.GameHub.server.download_vertex($scope.state.StateId)
                    .then(JSON.parse)
                    .done(function (v) {
                        retrocycle(v);
                        $scope.vertex = v;
                        _.each($scope.vertex.Edges, function (e) {
                            e.diff = diffpatcher.diff(s, e.State);
                            var obj = e.diff;
                            for (var prop in obj) {
                                if (obj.hasOwnProperty(prop)) {
                                    if (prop == "Game" || prop == "VertexName" || prop == "$id") {
                                        delete obj[prop];
                                    } else {
                                        var obj2 = obj[prop];
                                        if (Array.isArray(obj2))
                                            continue;
                                        var obj2_count = 0;
                                        for (var prop2 in obj2) {
                                            if (prop2 == "Game" || prop2 == "VertexName" || prop2 == "$id") {
                                                delete obj2[prop2];
                                            } else {
                                                obj2_count++;
                                            }
                                        }
                                        if (obj2_count == 0) {
                                            delete obj[prop];
                                        } else {
                                            for (var prop2 in obj2) {
                                                obj[e.State[prop].Name + " - " + prop2] = obj2[prop2];
                                                delete obj[prop];
                                            }
                                        }
                                    }
                                }
                            }
                        });
                        $scope.$apply();
                        $scope.debug_state();
                        $rootScope.client_report("Vertex: " + v.Name);
                        $window.scrollTo(0, 0);

                    });
            });

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
