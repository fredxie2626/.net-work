// ClientService.js

(function () {

    var WorkerService = function ($http) {

        var baseUrl = 'http://a3.fredbcit.xyz/api/AssignedWorkersAPI/';

        var _getAllWorkers = function () {
            return $http.get(baseUrl)
              .then(function (response) {
                  return response.data;
              });
        };

        return {
            getAllWorkers: _getAllWorkers
        };
    };

    var module = angular.module("workerViewer");
    module.factory("WorkerService", WorkerService);

}());