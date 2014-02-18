app.controller('PesquisaController', function ($scope, $http, $alert, $aside, ngTableParams) {
    $scope.listSubstancia = [];
   
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

    $scope.openModal = function (id) {

        var myOtherModal = $aside({ scope: $scope, template: baseUrl + '/Substancia/Substancia' });

        myOtherModal.$promise.then(function () {
            myOtherModal.show();
        });
    }

    $scope.getAll = function () {

        $scope.tableParams = new ngTableParams({
            page: 1,            // show first page
            count: 10           // count per page
        }, {
            total: data.length, // length of data
            getData: function ($defer, params) {
                $http.post(baseUrl + '/Substancia/GetAll')
               .success(function (data) {
                   $scope.listSubstancia = data;
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
                baseUrl + '/Substancia/Remover/' + item.SUB_ID
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

                    $scope.listSubstancia.splice(index, 1);
                    $scope.tableParams.reload();
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