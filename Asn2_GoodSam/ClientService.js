// ClientService.js

(function () {

    var ClientService = function ($http) {

        var baseUrl = 'http://a3.fredbcit.xyz/api/Clients/GetClientsWithAssignedWorker/';

        var _getAllClients = function (name) {
            return $http.get(baseUrl + name + "/")
              .then(function (response) {
                  return response.data;
              });
        };

        return {
            getAllClients: _getAllClients
        };
    };

    var module = angular.module("clientViewer");
    module.factory("ClientService", ClientService);

}());