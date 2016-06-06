var app = angular.module('Personajes', []);
//comentarisController
app.controller('PersonajesController', function($scope,$http) {
    $http.get('https://localhost:44329/Personajes/IndexAngular').success(function (personajes) {
        personajesAngular = JSON.parse(personajes);
        $scope.personajes=personajesAngular;
    })

    $scope.BorrarFiltros = function () {
        $scope.cerca = {};
    }
});

app.filter('menorQueCoste', function () {
    return function (items, number) {
        var filtered = [];
        angular.forEach(items, function (item, key) {
            if (item.Coste <= number) {
                filtered.push(item);
            }
        });
        return filtered;
    };
});

app.filter('menorQueEstrellas', function () {
    return function (items, number) {
        var filtered = [];
        angular.forEach(items, function (item, key) {
            if (item.Estrellas <= number) {
                filtered.push(item);
            }
        });
        return filtered;
    };
});
    