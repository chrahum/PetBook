 var  modules = modules || [];
(function () {
    'use strict';
    modules.push('Appointment');

    angular.module('Appointment',['ngRoute'])
    .controller('Appointment_list', ['$scope', '$http', function($scope, $http){

        $http.get('/Api/Appointment/')
        .then(function(response){$scope.data = response.data;});

    }])
    .controller('Appointment_details', ['$scope', '$http', '$routeParams', function($scope, $http, $routeParams){

        $http.get('/Api/Appointment/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});

    }])
    .controller('Appointment_create', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $scope.data = {};
                $http.get('/Api/Veterinarian/')
        .then(function(response){$scope.VeterinarianId_options = response.data;});
                $http.get('/Api/Customer/')
        .then(function(response){$scope.CustomerId_options = response.data;});
        
        $scope.save = function(){
            $http.post('/Api/Appointment/', $scope.data)
            .then(function(response){ $location.path("Appointment"); });
        }

    }])
    .controller('Appointment_edit', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $http.get('/Api/Appointment/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});

                $http.get('/Api/Veterinarian/')
        .then(function(response){$scope.VeterinarianId_options = response.data;});
                $http.get('/Api/Customer/')
        .then(function(response){$scope.CustomerId_options = response.data;});
        
        $scope.save = function(){
            $http.put('/Api/Appointment/' + $routeParams.id, $scope.data)
            .then(function(response){ $location.path("Appointment"); });
        }

    }])
    .controller('Appointment_delete', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $http.get('/Api/Appointment/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});
        $scope.save = function(){
            $http.delete('/Api/Appointment/' + $routeParams.id, $scope.data)
            .then(function(response){ $location.path("Appointment"); });
        }

    }])

    .config(['$routeProvider', function ($routeProvider) {
            $routeProvider
            .when('/Appointment', {
                title: 'Appointment - List',
                templateUrl: '/Static/Appointment_List',
                controller: 'Appointment_list'
            })
            .when('/Appointment/Create', {
                title: 'Appointment - Create',
                templateUrl: '/Static/Appointment_Edit',
                controller: 'Appointment_create'
            })
            .when('/Appointment/Edit/:id', {
                title: 'Appointment - Edit',
                templateUrl: '/Static/Appointment_Edit',
                controller: 'Appointment_edit'
            })
            .when('/Appointment/Delete/:id', {
                title: 'Appointment - Delete',
                templateUrl: '/Static/Appointment_Delete',
                controller: 'Appointment_delete'
            })
            .when('/Appointment/:id', {
                title: 'Appointment - Details',
                templateUrl: '/Static/Appointment_Details',
                controller: 'Appointment_details'
            })
    }])
;

})();
