 var  modules = modules || [];
(function () {
    'use strict';
    modules.push('Veterinarian');

    angular.module('Veterinarian',['ngRoute'])
    .controller('Veterinarian_list', ['$scope', '$http', function($scope, $http){

        $http.get('/Api/Veterinarian/')
        .then(function(response){$scope.data = response.data;});

    }])
    .controller('Veterinarian_details', ['$scope', '$http', '$routeParams', function($scope, $http, $routeParams){

        $http.get('/Api/Veterinarian/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});

    }])
    .controller('Veterinarian_create', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $scope.data = {};
        
        $scope.save = function(){
            $http.post('/Api/Veterinarian/', $scope.data)
            .then(function(response){ $location.path("Veterinarian"); });
        }

    }])
    .controller('Veterinarian_edit', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $http.get('/Api/Veterinarian/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});

        
        $scope.save = function(){
            $http.put('/Api/Veterinarian/' + $routeParams.id, $scope.data)
            .then(function(response){ $location.path("Veterinarian"); });
        }

    }])
    .controller('Veterinarian_delete', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $http.get('/Api/Veterinarian/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});
        $scope.save = function(){
            $http.delete('/Api/Veterinarian/' + $routeParams.id, $scope.data)
            .then(function(response){ $location.path("Veterinarian"); });
        }

    }])

    .config(['$routeProvider', function ($routeProvider) {
            $routeProvider
            .when('/Veterinarian', {
                title: 'Veterinarian - List',
                templateUrl: '/Static/Veterinarian_List',
                controller: 'Veterinarian_list'
            })
            .when('/Veterinarian/Create', {
                title: 'Veterinarian - Create',
                templateUrl: '/Static/Veterinarian_Edit',
                controller: 'Veterinarian_create'
            })
            .when('/Veterinarian/Edit/:id', {
                title: 'Veterinarian - Edit',
                templateUrl: '/Static/Veterinarian_Edit',
                controller: 'Veterinarian_edit'
            })
            .when('/Veterinarian/Delete/:id', {
                title: 'Veterinarian - Delete',
                templateUrl: '/Static/Veterinarian_Delete',
                controller: 'Veterinarian_delete'
            })
            .when('/Veterinarian/:id', {
                title: 'Veterinarian - Details',
                templateUrl: '/Static/Veterinarian_Details',
                controller: 'Veterinarian_details'
            })
    }])
;

})();
