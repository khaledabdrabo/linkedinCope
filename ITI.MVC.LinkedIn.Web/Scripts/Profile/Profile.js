$("#LanguageName").autocomplete({
    source: function (request, response) {
        $.ajax({
            url: "/Profile/RetriveLanguages",
            type: "POST",
            dataType: "json",
            data: { Prefix: $("#LanguageName").val() },
            success: function (data) {
                response($.map(data, function (item) {
                    return { label: item.Name, value: item.Name };
                }));
            },
            error: function (xhr, status, error) {
                alert(error);
                console.log(error, status, xhr);
            }

        }).then(data => console.log(data));
    }
});
function SucessCourse() {
    $("#CoursesModal").modal("hide");
    document.getElementById("form0").reset();
}


function sucessEditCourse(data) {
    $("#CoursesModal").modal('hide');
    $("#Courses-Acc-Container").load(" #Courses-Acc");
    if (data.success) {
        alert(data.responseText);
    }
    else {
        alert(data.responseText);
    }
}
function beginEdit(id) {
    $("#"+id).remove();
}


function SucessProject() {
    $('#Projects-Modal').modal("hide");
    document.getElementById("form0").reset();
}
function SucessAward() {
    $('#AwardModal').modal("hide");
    document.getElementById("form0").reset();
}
function SucessTestScore() {
    $('#testScoreModal').modal("hide");
    document.getElementById("form0").reset();
}
function SucessUserLanguage() {
    $('#LanguageModal').modal("hide");
    document.getElementById("form0").reset();
}
$("#course-button").click(addCourse);
$("#project-btn").click(addProject);
$("#User-langauge-btn").click(addUserLanguage);
$("#award-btn").click(addUserAwards);
$("#testScore-add-button").click(addTestScore);

function addCourse() {
    var ajaxCallURL = '/Profile/AddCourse/';
    var options = {
        "backdrop": "static",
        keyboard: true
    };
    $.ajax({
        type: "GET",
        url: ajaxCallURL,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $('#course-body').html(data);
            $('#CoursesModal').modal(options);
            $('#CoursesModal').modal('show');
        },
        error: function () {
            alert("Content load failed.");
        }
    });

}

function EditCourse(id) {
    var ajaxCallURL = '/Profile/EditCourse/'+id;
    var options = {
        "backdrop": "static",
        keyboard: true
    };
    $.ajax({
        type: "GET",
        url: ajaxCallURL,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $('#course-body').html(data);
            $('#CoursesModal').modal(options);
            $('#CoursesModal').modal('show');
        },
        error: function () {
            alert("Content load failed.");
        }
    });

}

function addProject() {
    var ajaxCallURL = '/Profile/AddProject/';
    var options = {
        "backdrop": "static",
        keyboard: true
    };
    $.ajax({
        type: "GET",
        url: ajaxCallURL,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $('#project-body').html(data);
            $('#Projects-Modal').modal(options);
            $('#Projects-Modal').modal('show');
        },
        error: function () {
            alert("Content load failed.");
        }
    });

}
function SucessEditUserLanguage(data){
    $("#LanguageModal").modal('hide');
    $("#language-read-container").load(" #language-read");
    if (data.success) {
        alert(data.responseText);
    }
    else {
        alert(data.responseText);
    }
}
function SucessEditAward(data) {
    $("#AwardModal").modal('hide');
    $("#awards-read-container").load(" #awards-read");
    if (data.success) {
        alert(data.responseText);
    }
    else {
        alert(data.responseText);
    }
}
function SucessEditTestScore(data) {
    $('#testScoreModal').modal("hide");
    $("#TestScore-read-Container").load(" #TestScore-read");
    if (data.success) {
        alert(data.responseText);
    }
    else {
        alert(data.responseText);
    }
}
function OnProjectEditSuccess(data) {
    $("#Projects-Modal").modal('hide');
    $("#project-read-container").load(" #projects-read");
    if (data.success) {
        alert(data.responseText);
    }
    else {
        alert(data.responseText);
    }
}
function EditProject(id) {
    var ajaxCallURL = '/Profile/EditProject/'+ id ;
    var options = {
        "backdrop": "static",
        keyboard: true
    };
    $.ajax({
        type: "GET",
        url: ajaxCallURL,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $('#project-body').html(data);
            $('#Projects-Modal').modal(options);
            $('#Projects-Modal').modal('show');
        },
        error: function () {
            alert("Content load failed.");
        }
    });

}

function addUserLanguage() {
    var ajaxCallURL = '/Profile/AddLanguage/';
    var options = {
        "backdrop": "static",
        keyboard: true
    };
    $.ajax({
        type: "GET",
        url: ajaxCallURL,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $('#userlanguage-body').html(data);
            $('#LanguageModal').modal(options);
            $('#LanguageModal').modal('show');
        },
        error: function () {
            alert("Content load failed.");
        }
    });

}

function EditUserLanguage(id) {
    var ajaxCallURL = '/Profile/EditLanguage/' + id;
    var options = {
        "backdrop": "static",
        keyboard: true
    };
    $.ajax({
        type: "GET",
        url: ajaxCallURL,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $('#userlanguage-body').html(data);
            $('#LanguageModal').modal(options);
            $('#LanguageModal').modal('show');
        },
        error: function () {
            alert("Content load failed.");
        }
    });

}


function addUserAwards() {
    var ajaxCallURL = '/Profile/AddAward/';
    var options = {
        "backdrop": "static",
        keyboard: true
    };
    $.ajax({
        type: "GET",
        url: ajaxCallURL,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $('#awards-body').html(data);
            $('#AwardModal').modal(options);
            $('#AwardModal').modal('show');
        },
        error: function () {
            alert("Content load failed.");
        }
    });

}
function EditUserAwards(id) {
    var ajaxCallURL = '/Profile/EditAward/'+id;
    var options = {
        "backdrop": "static",
        keyboard: true
    };
    $.ajax({
        type: "GET",
        url: ajaxCallURL,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $('#awards-body').html(data);
            $('#AwardModal').modal(options);
            $('#AwardModal').modal('show');
        },
        error: function () {
            alert("Content load failed.");
        }
    });

}

function addTestScore() {
    var ajaxCallURL = '/Profile/AddTest/';
    var options = {
        "backdrop": "static",
        keyboard: true
    };
    $.ajax({
        type: "GET",
        url: ajaxCallURL,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $('#testScore-body').html(data);
            $('#testScoreModal').modal(options);
            $('#testScoreModal').modal('show');
        },
        error: function () {
            alert("Content load failed.");
        }
    });

}
function EditTestScore(id) {
    var ajaxCallURL = '/Profile/EditTest/' + id;
    var options = {
        "backdrop": "static",
        keyboard: true
    };
    $.ajax({
        type: "GET",
        url: ajaxCallURL,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $('#testScore-body').html(data);
            $('#testScoreModal').modal(options);
            $('#testScoreModal').modal('show');
        },
        error: function () {
            alert("Content load failed.");
        }
    });

}