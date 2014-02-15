app.controller('PesquisaUsuarioController', function ($scope, $http, $alert) {
    $scope.listUsuario = [];

    $scope.init = function () {
        $scope.getAll();
    }

    $scope.getAll = function () {

        $http.post(baseUrl + '/Usuario/GetAll')
            .success(function (data) {
                $scope.listUsuario = data;
        });
    }

    $scope.remover = function (item, index) {
        var conf = confirm('Deseja remover este registro?');

        if (conf) {
            $http.post(
                baseUrl + '/Usuario/Remover/' + item.USR_ID
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

                    $scope.listUsuario.splice(index, 1);
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
    }
});