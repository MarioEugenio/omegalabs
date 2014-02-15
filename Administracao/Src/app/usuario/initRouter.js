app.config(['$routeProvider',
  function($routeProvider) {
      $routeProvider.
        when('/usuario', {
            templateUrl: baseUrl + '/Usuario/Pesquisa',
            controller: 'PesquisaUsuarioController'
        }).
        when('/usuario/cadastro', {
            templateUrl: baseUrl + '/Usuario/Usuario',
            controller: 'UsuarioController'
        }).
        when('/usuario/:id/alterar', {
            templateUrl: baseUrl + '/Usuario/Usuario',
            controller: 'UsuarioController'
        }).
        otherwise({
            redirectTo: '/usuario'
        });
  }]);