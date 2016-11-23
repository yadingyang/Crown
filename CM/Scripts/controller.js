app.controller('Index', function ($scope, $http) {
    $http.get("/Index/GetCate")
   .success(function (response) { $scope.ca = response; })
})