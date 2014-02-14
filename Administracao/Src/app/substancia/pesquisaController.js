app.controller('PesquisaController', function ($scope, $http) {
    $scope.listSubstancia = [];

    $scope.init = function () {
        $scope.getAll();
    }

    $scope.getAll = function () {
        $http.post(baseUrl + '/Substancia/GetAll')
            .success(function (data) {
                $scope.listSubstancia = data;
        });
    }
});