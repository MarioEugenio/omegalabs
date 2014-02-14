app.config(['$routeProvider',
  function($routeProvider) {
      $routeProvider.
        when('/substancia', {
            templateUrl: baseUrl + '/Substancia/Pesquisa',
            controller: 'PesquisaController'
        }).
        when('/substancia/cadastro', {
            templateUrl: baseUrl + '/Substancia/Substancia',
            controller: 'SubstanciaController'
        }).
        when('/substancia/:id/alterar', {
            templateUrl: baseUrl + '/Substancia/Substancia',
            controller: 'SubstanciaController'
        }).
        otherwise({
            redirectTo: '/substancia'
        });
  }]);