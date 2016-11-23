var App = angular.module("AngularApp", ['ngAnimate', 'ngSanitize', 'ui.bootstrap', 'angularUtils.directives.dirPagination', 'ngMask']);

App.controller("playerController", function ($scope, $http) {

    $scope.currentPage = 1;
    $scope.pageSize = 10;
    $scope.players = [];
    $scope.player = "";

    $http.get("/Player/GetPlayers").success(function (result) {
        $scope.players = result;
    }).error(function (result) {
        alert(JSON.stringify(result));
    });

    $http.get("/Player/GetCountries").success(function (result) {
        $scope.countries = result;
    }).error(function (result) {
        alert(JSON.stringify(result));
    });

    $scope.getProvinces = function (countryId) {

        $http.post("/Player/GetProvinces", { countryId: countryId }).success(function (result) {
            $scope.provinces = result;
        }).error(function (result) {
            alert(JSON.stringify(result));
        });
    }

    $scope.addPlayer = function (player) {

        $http.post("/Player/AddPlayer", { player: player }).success(function (result) {

            $scope.players = result;
        }).error(function (result) {
            alert(JSON.stringify(result));
        });
    }


    function ConvertToDateFormat(date) {
        return new Date(parseInt(date.substr(6)));
    }

    $scope.updatePlayer = function (player) {

        if (player !== "") {
            $http.post("/Player/UpdatePlayer", { player: player }).success(function (result) {

                $scope.players = result;
                $scope.showAlert("success", "Player updated");
            }).error(function (result) {
                alert(JSON.stringify(result));
            });
        }
        else {
            $scope.showAlert("warning","Choose a player");
        }
    }

    $scope.deletePlayer = function (playerId) {

        $http.post("/Player/DeletePlayer", { playerId: playerId }).success(function (result) {

            $scope.players = result;
        }).error(function (result) {
            alert(JSON.stringify(result));
        });
    }


    $scope.getPlayer = function (playerId) {

        $http.post("/Player/GetPlayer", { playerId: playerId }).success(function (result) {

            $scope.getProvinces(result.CountryId)


            result.RegisterationDate = ConvertToDateFormat(result.RegisterationDate);
            $scope.player = result;

        }).error(function (result) {
            alert(JSON.stringify(result));
        });
    }

    $scope.openSchedule = function () {
        $scope.schedulePopup.opened = true;
    };

    $scope.schedulePopup = {
        opened: false
    };


    $scope.dateOptions = {
        'starting-day': 1
    };

    // function to submit the form after all validation has occurred			
    $scope.submitForm = function (isValid) {

        // check to make sure the form is completely valid
        if (isValid) {
            alert('our form is amazing');
        }

    };

    $scope.alerts = [];

    $scope.showAlert = function (alertType, message) {
        $scope.alerts = [];
        $scope.alerts.push({ type: alertType, msg: message });
    }

    $scope.closeAlert = function (index) {
        $scope.alerts.splice(index, 1);
    };
});


App.directive('bootstrapSwitch', [
        function () {
            return {
                restrict: 'A',
                require: '?ngModel',
                link: function (scope, element, attrs, ngModel) {
                    element.bootstrapSwitch();

                    element.on('switchChange.bootstrapSwitch', function (event, state) {
                        if (ngModel) {
                            scope.$apply(function () {
                                ngModel.$setViewValue(state);
                            });
                        }
                    });

                    scope.$watch(attrs.ngModel, function (newValue, oldValue) {
                        if (newValue) {
                            element.bootstrapSwitch('state', true, true);
                        } else {
                            element.bootstrapSwitch('state', false, true);
                        }
                    });
                }
            };
        }
]);
