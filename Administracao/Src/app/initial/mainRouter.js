app.config(['$routeProvider',
  function($routeProvider) {
      $routeProvider.
        when('/main', {
            templateUrl: baseUrl + '/Home/Administracao',
            controller: 'MainController'
        }).
        otherwise({
            redirectTo: '/main'
        });
  }]);