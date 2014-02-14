function PesquisaSubstanciaCtrl($scope, $http, $filter) {
    // init
    $scope.sortingOrder = sortingOrder;
    $scope.reverse = false;
    $scope.filteredItems = [];
    $scope.groupedItems = [];
    $scope.itemsPerPage = 25;
    $scope.pagedItems = [];
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.substancia = [];
    $scope.edicao = 0;

    $scope.form = {};


    $scope.pesquisar = function () {

        var oRequest = new XMLHttpRequest();
        oRequest.open('POST', '/substancia/GetAll/', false);
        oRequest.send(null)

        return angular.fromJson(oRequest.responseText);

    };


    $scope.salvar = function () {
        var obj = [];

        obj.SUB_ID = 
        obj.SUB_NOME = $scope.form.nome;

        console.log(obj);
        //$http.post('/substancia/Edit/', $scope.form);
        
    }

    $scope.getsubstancia = function (subId,edicao) {

        $scope.edicao = edicao;

        var oRequest = new XMLHttpRequest();
        oRequest.open('POST', '/substancia/Get/' + subId, false);
        oRequest.send(null)

        $scope.substancia = angular.fromJson(oRequest.responseText);
       
    };

    $scope.items = $scope.pesquisar();

    var searchMatch = function (haystack, needle) {
        if (!needle) {
            return true;
        }

        return haystack.toLowerCase().indexOf(needle.toLowerCase()) !== -1;
    };

    // init the filtered items
    $scope.search = function () {
        $scope.filteredItems = $filter('filter')($scope.items, function (item) {
            for (var attr in item) {
                if (item[attr] != null) {
                    if (searchMatch(item[attr].toString(), $scope.query))
                        return true;
                }
            }
            return false;
        });
        // take care of the sorting order
        if ($scope.sortingOrder !== '') {
            $scope.filteredItems = $filter('orderBy')($scope.filteredItems, $scope.sortingOrder, $scope.reverse);
        }
        $scope.currentPage = 0;
        // now group by pages
        $scope.groupToPages();
    };

    // calculate page in place
    $scope.groupToPages = function () {
        $scope.pagedItems = [];

        for (var i = 0; i < $scope.filteredItems.length; i++) {
            if (i % $scope.itemsPerPage === 0) {
                $scope.pagedItems[Math.floor(i / $scope.itemsPerPage)] = [$scope.filteredItems[i]];
            } else {
                $scope.pagedItems[Math.floor(i / $scope.itemsPerPage)].push($scope.filteredItems[i]);
            }
        }
    };

    $scope.range = function (start, end) {
        var ret = [];
        if (!end) {
            end = start;
            start = 0;
        }
        for (var i = start; i < end; i++) {
            ret.push(i);
        }
        return ret;
    };

    $scope.prevPage = function () {
        if ($scope.currentPage > 0) {
            $scope.currentPage--;
        }
    };

    $scope.nextPage = function () {
        if ($scope.currentPage < $scope.pagedItems.length - 1) {
            $scope.currentPage++;
        }
    };

    $scope.setPage = function () {
        $scope.currentPage = this.n;
    };

    // functions have been describe process the data for display
    $scope.search();

    // change sorting order
    $scope.sort_by = function (newSortingOrder) {
        if ($scope.sortingOrder == newSortingOrder)
            $scope.reverse = !$scope.reverse;

        $scope.sortingOrder = newSortingOrder;

    };
};
PesquisaSubstanciaCtrl.$inject = ['$scope', '$http', '$filter'];

