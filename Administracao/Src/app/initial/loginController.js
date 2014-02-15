app.controller('LoginController', function($scope, $http, $alert) {
    $scope.form = {};

    $scope.autenticar = function () {
        $http.post(
            baseUrl + '/Usuario/Autenticacao',
            $scope.form
            )
            .success(function (response) {
                if (response.success) {
                    window.location = '/home/main';
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