 var  modules = modules || [];
(function () {
    'use strict';
    modules.push('Pet');

    angular.module('Pet',['ngRoute'])
    .controller('Pet_list', ['$scope', '$http', function($scope, $http){

        $http.get('/Api/Pet/')
        .then(function(response){$scope.data = response.data;});

    }])
    .controller('Pet_details', ['$scope', '$http', '$routeParams', function($scope, $http, $routeParams){

        $http.get('/Api/Pet/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});

    }])
    .controller('Pet_create', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $scope.data = {};
                $http.get('/Api/Customer/')
        .then(function(response){$scope.CustomerId_options = response.data;});
        
        $scope.save = function(){
            $http.post('/Api/Pet/', $scope.data)
            .then(function(response){ $location.path("Pet"); });
        }

    }])
    .controller('Pet_edit', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $http.get('/Api/Pet/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});

                $http.get('/Api/Customer/')
        .then(function(response){$scope.CustomerId_options = response.data;});
        
        $scope.save = function(){
            $http.put('/Api/Pet/' + $routeParams.id, $scope.data)
            .then(function(response){ $location.path("Pet"); });
        }

    }])
    .controller('Pet_delete', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $http.get('/Api/Pet/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});
        $scope.save = function(){
            $http.delete('/Api/Pet/' + $routeParams.id, $scope.data)
            .then(function(response){ $location.path("Pet"); });
        }

    }])

    .config(['$routeProvider', function ($routeProvider) {
            $routeProvider
            .when('/Pet', {
                title: 'Pet - List',
                templateUrl: '/Static/Pet_List',
                controller: 'Pet_list'
            })
            .when('/Pet/Create', {
                title: 'Pet - Create',
                templateUrl: '/Static/Pet_Edit',
                controller: 'Pet_create'
            })
            .when('/Pet/Edit/:id', {
                title: 'Pet - Edit',
                templateUrl: '/Static/Pet_Edit',
                controller: 'Pet_edit'
            })
            .when('/Pet/Delete/:id', {
                title: 'Pet - Delete',
                templateUrl: '/Static/Pet_Delete',
                controller: 'Pet_delete'
            })
            .when('/Pet/:id', {
                title: 'Pet - Details',
                templateUrl: '/Static/Pet_Details',
                controller: 'Pet_details'
            })
    }])
;

})();
