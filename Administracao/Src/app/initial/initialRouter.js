app.config(['$routeProvider',
  function($routeProvider) {
      $routeProvider.
        when('/login', {
            templateUrl: baseUrl + '/Home/Login',
            controller: 'LoginController'
        }).
        otherwise({
            redirectTo: '/login'
        });
  }]);