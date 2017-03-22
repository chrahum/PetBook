 var  modules = modules || [];
(function () {
    'use strict';
    modules.push('Customer');

    angular.module('Customer',['ngRoute'])
    .controller('Customer_list', ['$scope', '$http', function($scope, $http){

        $http.get('/Api/Customer/')
        .then(function(response){$scope.data = response.data;});

    }])
    .controller('Customer_details', ['$scope', '$http', '$routeParams', function($scope, $http, $routeParams){

        $http.get('/Api/Customer/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});

    }])
    .controller('Customer_create', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $scope.data = {};
                $http.get('/Api/Veterinarian/')
        .then(function(response){$scope.VeterinarianId_options = response.data;});
        
        $scope.save = function(){
            $http.post('/Api/Customer/', $scope.data)
            .then(function(response){ $location.path("Customer"); });
        }

    }])
    .controller('Customer_edit', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $http.get('/Api/Customer/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});

                $http.get('/Api/Veterinarian/')
        .then(function(response){$scope.VeterinarianId_options = response.data;});
        
        $scope.save = function(){
            $http.put('/Api/Customer/' + $routeParams.id, $scope.data)
            .then(function(response){ $location.path("Customer"); });
        }

    }])
    .controller('Customer_delete', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $http.get('/Api/Customer/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});
        $scope.save = function(){
            $http.delete('/Api/Customer/' + $routeParams.id, $scope.data)
            .then(function(response){ $location.path("Customer"); });
        }

    }])

    .config(['$routeProvider', function ($routeProvider) {
            $routeProvider
            .when('/Customer', {
                title: 'Customer - List',
                templateUrl: '/Static/Customer_List',
                controller: 'Customer_list'
            })
            .when('/Customer/Create', {
                title: 'Customer - Create',
                templateUrl: '/Static/Customer_Edit',
                controller: 'Customer_create'
            })
            .when('/Customer/Edit/:id', {
                title: 'Customer - Edit',
                templateUrl: '/Static/Customer_Edit',
                controller: 'Customer_edit'
            })
            .when('/Customer/Delete/:id', {
                title: 'Customer - Delete',
                templateUrl: '/Static/Customer_Delete',
                controller: 'Customer_delete'
            })
            .when('/Customer/:id', {
                title: 'Customer - Details',
                templateUrl: '/Static/Customer_Details',
                controller: 'Customer_details'
            })
    }])
;

})();
