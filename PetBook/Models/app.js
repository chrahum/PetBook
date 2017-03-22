var app = angular.module("myApp", ["ui.router", "ui.bootstrap"]);

app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/");
    //sets up different routes
    $stateProvider
        //starts at startpage.html
      .state("calendar", {
          url: "/appointment",
          templateUrl: "./htmlrouting/calendar.html",
          controller: "datePickerController"
      })

      .state("login", {
          url: "/login",
          templateUrl: "login.html",
          controller: "loginController"
      })
});
