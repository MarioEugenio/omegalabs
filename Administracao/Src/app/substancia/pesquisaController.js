app.controller('PesquisaController', function ($scope, $http, $alert) {
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

    $scope.remover = function (item, index) {
        var conf = confirm('Deseja remover este registro?');

        if (conf) {
            $http.post(
                baseUrl + '/Substancia/Remover/' + item.SUB_ID
                )
                .success(function (response) {
                if (response.success) {
                    $alert({
                        title: response.message,
                        content: response.message,
                        placement: 'top',
                        type: 'success',
                        show: true
                    });

                    $scope.listSubstancia.splice(index, 1);
            } else {
                $alert({
                    title: response.message,
                content: response.message,
                placement: 'top',
                type: 'warning',
                show: true
            });

            }
            });
        }
    }
});