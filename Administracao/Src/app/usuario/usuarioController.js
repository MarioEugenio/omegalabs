app.controller('UsuarioController', function ($scope, $http, $location, $routeParams, $alert) {
    $scope.form = {};
    $scope.listStatus = [];

    $scope.init = function () {
        var id = $routeParams.id;

        if (id) {
            $scope.get(id);
        }

        $scope.getAllStatus();
    }

    $scope.getAllStatus = function () {
        $http.post(baseUrl + '/Substancia/GetAllStatus/')
            .success(function (response) {
                $scope.listStatus = response;
            });
    }

    $scope.get = function (id) {
        $http.post(baseUrl + '/Usuario/Get/' + id)
            .success(function (response) {
                $scope.form = response;
        });
    }

    $scope.salvar = function () {

        if ($scope.form.USR_SENHA != $scope.form.R_USR_SENHA) {
            $alert({
                title: 'Confirme novamente a senha',
                content: '',
                placement: 'top-right',
                container: 'body',
                type: 'warning',
                show: true
            });

            return;
        }

        $http.post(
            baseUrl + '/Usuario/Save',
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

                    $location.path('/usuario');
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