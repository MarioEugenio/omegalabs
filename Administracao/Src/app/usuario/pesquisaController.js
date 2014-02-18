app.controller('PesquisaUsuarioController', function ($scope, $http, $alert, ngTableParams) {
    $scope.listUsuario = [];

    var data = [];

    $scope.tableParams = new ngTableParams({
        page: 1,            // show first page
        count: 10           // count per page
    }, {
        total: data.length, // length of data
        getData: function ($defer, params) {
            $defer.resolve(data.slice((params.page() - 1) * params.count(), params.page() * params.count()));
        }
    });

    $scope.init = function () {
        $scope.getAll();
    }

    $scope.getAll = function () {

        $scope.tableParams = new ngTableParams({
            page: 1,            // show first page
            count: 10           // count per page
        }, {
            total: data.length, // length of data
            getData: function ($defer, params) {
                $http.post(baseUrl + '/Usuario/GetAll')
               .success(function (data) {
                   $scope.listUsuario = data;

                   params.total(data.length);

                   $defer.resolve(data.slice((params.page() - 1) * params.count(), params.page() * params.count()));
               });
            }
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