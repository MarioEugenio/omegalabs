app.controller('SubstanciaController', function ($scope, $http, $location, $routeParams, $alert) {
    $scope.form = {};
    $scope.listStatus = [];
    $scope.listDerivacao = [];

    $scope.init = function () {
        var id = $routeParams.id;

        if (id) {
            $scope.get(id);
        }

        $scope.getAllStatus();
        $scope.getAll();
    }

    $scope.getAll = function () {
        $http.post(baseUrl + '/Substancia/GetAll')
        .success(function (data) {
            $scope.listDerivacao = data;
        });
    }

    $scope.getAllStatus = function () {
        $http.post(baseUrl + '/Substancia/GetAllStatus/')
            .success(function (response) {
                $scope.listStatus = response;
            });
    }

    $scope.get = function (id) {
        $http.post(baseUrl + '/Substancia/Get/' + id)
            .success(function (response) {
                $scope.form = response;
        });
    }

    $scope.salvar = function () {
        $http.post(
            baseUrl + '/Substancia/Save',
            $scope.form
            )
            .success(function (response) {
                if (response.success) {
                    $alert({
                        title: response.message,
                        content: response.message,
                        placement: 'top-right',
                        container: 'body',
                        type: 'success',
                        show: true
                    });

                    $location.path('/substancia');
                } else {
                    $alert({
                        title: response.message,
                        content: response.message,
                        placement: 'top-right',
                        container: 'body',
                        type: 'warning',
                        show: true
                    });

                }   
        });
    }
});