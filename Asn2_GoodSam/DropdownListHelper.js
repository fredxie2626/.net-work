var baseUrlWorker = 'http://a3.fredbcit.xyz/api/AssignedWorkersAPI/';
var baseUrlStatus = 'http://a3.fredbcit.xyz/api/StatusOfFilesAPI/';

function GetWorkers(target) {
    jQuery.support.cors = true;
    $.ajax({
        url: baseUrlWorker,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            WriteResponseWorker(data, target);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function WriteResponseWorker(people, target) {
    var strResult = "<Select id='workerOptions' onchange='run1()'>";
    strResult += "<option value=''>Select...</option>";
    $.each(people, function (index, person) {
        strResult += "<option>";
        strResult += person.AssignedWorkerName;
        strResult += "</option>";
    });
    strResult += "</Select>\n";
    $(target).html(strResult);
}

function GetStatus(target) {
    jQuery.support.cors = true;
    $.ajax({
        url: baseUrlStatus,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            WriteResponseStatus(data, target);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function WriteResponseStatus(status, target) {
    var strResult = "<Select id='statusOptions' onchange='run2()'>";
    strResult += "<option value=''>Select...</option>";
    $.each(status, function (index, stat) {
        strResult += "<option>";
        strResult += stat.StatusOfFileName;
        strResult += "</option>";
    });
    strResult += "</Select>\n";
    $(target).html(strResult);
}

function run1() {
    var e = document.getElementById("workerOptions");
    var strUser = e.options[e.selectedIndex].text;
    document.getElementById("display_worker").innerHTML = strUser;
}

function run2() {
    var e = document.getElementById("statusOptions");
    var strUser = e.options[e.selectedIndex].text;
    document.getElementById("display_status").innerHTML = strUser;
}

function replaceContentInContainer(target1, source1, target2, source2) {
    document.getElementById(target1).innerHTML = document.getElementById(source1).innerHTML;
    document.getElementById(target2).innerHTML = document.getElementById(source2).innerHTML;
    document.getElementById("submit").style.visibility = "hidden";
}