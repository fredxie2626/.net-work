(function () {
    var app = angular.module("clientViewer", []);

    var MainController = function ($scope, ClientService) {

        var _clients = {
            ClientId: "",
            FirstName: "",
            Surname: "",
            FiscalYear: "",
            Month: "",
            Day: "",
            Program: "",
            PoliceFileNo: "",
            CourtFileNo: "",
            Service: "",
            VictimOfIncident: "",
            FamilyViolenceFile: "",
            Gender: "",
            Ethinicity: "",
            Surname: ""
        };

        var onGetAllComplete = function (data) {
            
            $scope.allClients = data;
        };

        var onGetAllError = function (reason) {
            $scope.error = "Could not get all clients.";
        };

        $scope.getAll = function (target1, source1, target2, source2) {
            replaceContentInContainer(target1, source1, target2, source2);
            var userName = document.getElementById('div_show_workers').innerHTML;
            var status = document.getElementById('div_show_status').innerHTML;
            //alert(userName);
            ClientService.getAllClients(userName)
              .then(onGetAllComplete, onGetAllError);
            document.getElementById("getClients").style.visibility = "hidden";
            if (userName != "" && status != "") {
                GetOpenFiles('#openstatus', userName);
                GetCloseFiles('#closestatus', userName);
                GetReopenFiles('#reopenstatus', userName);
                GetNoneFiles('#nonetatus', userName)
                GetSeletedStatusCount('#totalselectedstatus', status, userName);
                GetTotalAssign('#totalstatus', userName);
            }
        };

        $scope.message = "Detail for Selected Status";
        $scope.clients = _clients;
    };
    app.controller("MainController", MainController);

    var app = angular.module("workerViewer", []);

    var WorkerController = function ($scope, WorkerService) {

        var _Workers = {
            Name: ""
        };

        var onGetAllComplete = function (data) {
            $scope.allWorkers = data;
        };

        var onGetAllError = function (reason) {
            $scope.errorWorker = "Could not get all workers.";
        };

        $scope.getAllWorkers = function () {
            WorkerService.getAllWorkers()
              .then(onGetAllComplete, onGetAllError);
        };

        $scope.messageWorker = "Worker information";
        $scope.workers = _Workers;
    };
    app.controller("WorkerController", WorkerController);


    angular.element(document).ready(function () {
        var myDiv1 = document.getElementById("myDiv1");
        angular.bootstrap(myDiv1, ["clientViewer"]);

        var myDiv2 = document.getElementById("myDiv2");
        angular.bootstrap(myDiv2, ["workerViewer"]);
    });

    function replaceContentInContainer(target1, source1, target2, source2) {
        document.getElementById(target1).innerHTML = document.getElementById(source1).innerHTML;
        document.getElementById(target2).innerHTML = document.getElementById(source2).innerHTML;
        //document.getElementById("submit").style.visibility = "hidden";
    }

    function GetSeletedStatusCount(target, status, workName) {
        jQuery.support.cors = true;
        $.ajax({
            url: 'http://a3.fredbcit.xyz/api/Clients/GetClientNum/' + status + '/' + workName,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                WriteCountResponse(data, target);
            },
            error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });
    }

    var baseUrlStatus = 'http://a3.fredbcit.xyz/api/Clients/GetClientNum/';

    function GetOpenFiles(target, workerName) {
        jQuery.support.cors = true;
        $.ajax({
            url: baseUrlStatus + "Open/" + workerName,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                WriteCountResponse(data, target);
            },
            error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });
    }

    function GetCloseFiles(target, workerName) {
        jQuery.support.cors = true;
        $.ajax({
            url: baseUrlStatus + "Closed/" + workerName,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                WriteCountResponse(data, target);
            },
            error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });
    }

    function GetReopenFiles(target, workerName) {
        jQuery.support.cors = true;
        $.ajax({
            url: baseUrlStatus + "Reopened/" + workerName,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                WriteCountResponse(data, target);
            },
            error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });
    }

    function GetNoneFiles(target, workerName) {
        jQuery.support.cors = true;
        $.ajax({
            url: baseUrlStatus + "None/" + workerName,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                WriteCountResponse(data, target);
            },
            error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });
    }

    function GetTotalAssign(target, workerName) {
        jQuery.support.cors = true;
        $.ajax({
            url: 'http://a3.fredbcit.xyz/api/Clients/GetClientNumTotal/' + workerName,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                WriteCountResponse(data, target);
            },
            error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });
    }

    function WriteCountResponse(status, target) {
        var strResult = "<text>" + JSON.parse(status) + "</text>";
        $(target).html(strResult);
    }
}());