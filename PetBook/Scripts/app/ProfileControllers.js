 var  modules = modules || [];
(function () {
    'use strict';
    modules.push('Profile');

    angular.module('Profile',['ngRoute'])
    .controller('Profile_list', ['$scope', '$http', function($scope, $http){

        $http.get('/Api/Profile/')
        .then(function(response){$scope.data = response.data;});

    }])
    .controller('Profile_details', ['$scope', '$http', '$routeParams', function($scope, $http, $routeParams){

        $http.get('/Api/Profile/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});

    }])
    .controller('Profile_create', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $scope.data = {};
                $http.get('/Api/Pet/')
        .then(function(response){$scope.PetId_options = response.data;});
        
        $scope.save = function(){
            $http.post('/Api/Profile/', $scope.data)
            .then(function(response){ $location.path("Profile"); });
        }

    }])
    .controller('Profile_edit', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $http.get('/Api/Profile/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});

                $http.get('/Api/Pet/')
        .then(function(response){$scope.PetId_options = response.data;});
        
        $scope.save = function(){
            $http.put('/Api/Profile/' + $routeParams.id, $scope.data)
            .then(function(response){ $location.path("Profile"); });
        }

    }])
    .controller('Profile_delete', ['$scope', '$http', '$routeParams', '$location', function($scope, $http, $routeParams, $location){

        $http.get('/Api/Profile/' + $routeParams.id)
        .then(function(response){$scope.data = response.data;});
        $scope.save = function(){
            $http.delete('/Api/Profile/' + $routeParams.id, $scope.data)
            .then(function(response){ $location.path("Profile"); });
        }

    }])

    .config(['$routeProvider', function ($routeProvider) {
            $routeProvider
            .when('/Profile', {
                title: 'Profile - List',
                templateUrl: '/Static/Profile_List',
                controller: 'Profile_list'
            })
            .when('/Profile/Create', {
                title: 'Profile - Create',
                templateUrl: '/Static/Profile_Edit',
                controller: 'Profile_create'
            })
            .when('/Profile/Edit/:id', {
                title: 'Profile - Edit',
                templateUrl: '/Static/Profile_Edit',
                controller: 'Profile_edit'
            })
            .when('/Profile/Delete/:id', {
                title: 'Profile - Delete',
                templateUrl: '/Static/Profile_Delete',
                controller: 'Profile_delete'
            })
            .when('/Profile/:id', {
                title: 'Profile - Details',
                templateUrl: '/Static/Profile_Details',
                controller: 'Profile_details'
            })
    }])
;

})();
