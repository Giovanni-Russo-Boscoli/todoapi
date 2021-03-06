﻿
$(document).ready(function () {
    $.noConflict();
    GetTaskList();
});

function GetTaskList() {
    $.ajax({
        type: "GET",
        url: '/Todo/GetListTaskItem',
        data: {},
        success: function (data) {
            //alert(JSON.stringify(data));
            LoadDataTable(data);
        },
        error: function (xhr, status, error) {
            ToastrMessage("", "Something went wrong to load Tasks list!");
        }
    });
}

function LoadDataTable(dataObj) {

    var datatableVariable = $('#TaskListDataTable').DataTable({
        "language": {
            "zeroRecords": "No task was created",
            "infoEmpty": "No task was created",
        },
        "order": [[2, "asc"]],
        "bPaginate": true,
        "bLengthChange": false, //SHOW X ENTRIES
        "bFilter": true, //SEARCH
        "bInfo": true, //Showing 1 to 2 of 2 entries
        "bAutoWidth": false,
        data: dataObj,

        "columnDefs": [
            {
                "targets": [0],
                "visible": true,
                "data": null,
                "orderable": false
            },
            {
                "targets": [1],
                "visible": true,
                "data": null,
                "sWidth": "5%",
                "data": "status",
                "render": function (data, type, full, meta) {
                    var is_checked = full.status ? "checked" : "";
                    return "<td>" +
                        "<input type='checkbox' onchange='CheckTask(this," + full.id + ");' " + is_checked + "/>" +
                        "</td> "
                },
                "orderable": false
            },
            {
                "targets": [2],
                "visible": true,
                "data": "creationDate",
                "className": "clsNoWrap",
                "sWidth": "5%"
            },
            {
                "targets": [3],
                "visible": true,
                "data": "description",
                "render": function (data, type, full, meta) {
                   
                    return "<td>" +
                        "<label class=" + full.id + "_description" + ">" + full.description + "</label>" +
                        "</td> "
                },
            },
            {
                "targets": [4],
                "visible": true,
                "data": "modificationDate",
                "className": "clsNoWrap",
                "sWidth": "5%"
            },
            {
                "targets": [5],
                "visible": true,
                "data": null,
                "sWidth": "5%",
                "render": function (data, type, full, meta) {
                    var is_disabled = full.status ? "disabled" : "";
                    return "<td>" +
                        "<button class='btn btn-default' title='Edit Task' onclick='EditTask(" + full.id +");'" + is_disabled + ">" +
                        "<span class='glyphicon glyphicon-pencil'></span>" +
                        "</button>" +
                        "</td> "
                },
                "orderable": false
            },
            {
                "targets": [6],
                "visible": true,
                "data": null,
                "sWidth": "5%",
                "render": function (data, type, full, meta) {
                    return "<td>" +
                        "<button class='btn btn-default' title='Delete Task' onclick='DeleteTask(" + full.id + ");'>" +
                        "<span class='glyphicon glyphicon-trash text-danger'></span>" +
                        "</button>" +
                        "</td> "
                },
                "orderable": false
            }
        ],
        "createdRow": function (row, data, index) {
            //alert(JSON.stringify(data));
            if (data.status) {
                //$(row).css('background-color', '#C5E3BF');
                $(row).addClass('taskDone');
            }
        }
    });

    CreateIdentityColumn(datatableVariable);
}

function CreateIdentityColumn(table) {
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
}

function RefreshTable(tableId, urlData) {
    $.getJSON(urlData, null, function (json) {
        table = $(tableId).dataTable();
        oSettings = table.fnSettings();

        table.fnClearTable(this);
        for (var i = 0; i < json.length; i++) {
            table.oApi._fnAddData(oSettings, json[i]);
        }

        oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
        table.fnDraw();
    });
}

function AddTask() {
    clearDescription();
    editTitleHeaderModal('New Task');
    editTextBtnTask('Add Task');
    editEventBtnTask("AddTaskAjax(txtDescription);");
}

function AddTaskAjax(objTxtDescription) {
    if (!objTxtDescription.checkValidity()) {
        ToastrMessage("", "Description is required!", "warning");
        inpObj.focus();
    } else {
        $.ajax({
            type: "POST",
            url: '/Todo/AddNewTask',
            data: { idUser: 1, idTask: 1, description: $(objTxtDescription).val() },
            success: function (data) {
                if (data) {
                    ToastrMessage("", "Task added!", "success");
                    $('#AddEditTaskModal').modal('hide');
                    RefreshTable("#TaskListDataTable", "/Todo/GetListTaskItem");
                } else {
                    ToastrMessage("", "Something went wrong", "error");
                }
            },
            error: function (xhr, status, error) { alert(error); }
        });
    }
}

function EditTask(taskId) {
    var oldDescription = $("." + taskId + "_description").text();
    ConfirmCustom("Would you like do edit the task?", function () {
        $('#AddEditTaskModal').modal('show');
        editTitleHeaderModal("Editing task");
        $("#txtDescription").val(oldDescription);
        editTextBtnTask("Edit Task");
        editEventBtnTask("EditTaskAjax(" + taskId + ");");
    });
}

function EditTaskAjax(_taskid) {
    var oldDescription = $("." + _taskid + "_description").text();
    if (oldDescription == $("#txtDescription").val()) {
        ToastrMessage("", "Nothing has changed", "warning");
        return false;
    }
    $.ajax({
        type: "PUT",
        url: '/todo/EditTask',
        data: { idtask: _taskid, newDescription: $("#txtDescription").val() },
        success: function (data) {
            if (data) {
                ToastrMessage("", "task edited successfully", "success");
                RefreshTable("#TaskListDataTable", "/Todo/GetListTaskItem");
                $('#AddEditTaskModal').modal('hide');
            } else {
                ToastrMessage("", "something went wrong, was not possible to edit the task", "error");
            }
        },
        error: function (xhr, status, error) { alert(error); }
    });
}

function DeleteTask(taskId) {
    ConfirmCustom("Would you like to Delete?", function () {
        $.ajax({
            type: "DELETE",
            url: '/Todo/DeleteTask',
            data: { idTask: taskId },
            success: function (data) {
                if (data) {
                    RefreshTable("#TaskListDataTable", "/Todo/GetListTaskItem");
                    ToastrMessage("", "Task deleted!", "error")
                } else {
                    ToastrMessage("", "Something went wrong, was not possible to delete the task", "error");
                }
            },
            error: function (xhr, status, error) { alert(error); }
        });
    });
}

function ConfirmCustom(message, callback) {
    if (message == null || message == "") {
        message = "Would you like to proceed?";
    }
    if (confirm(message)) {
        callback();     
    }
}

function editTitleHeaderModal(_text) {
    $('.titleHeaderModal').text(_text);
}

function editTextBtnTask(_text) {
    $('.btnTaskEvent').text(_text);
}

function editEventBtnTask(_event) {
    $('.btnTaskEvent').attr("onclick", _event);
}

function clearDescription() {
    $("#txtDescription").val("");
}

function CheckTask(obj, _idTask) {
    var _bool = $(obj).prop("checked");
    var partial = $(obj).prop("checked") ? "check" : "uncheck";
    var answer = confirm("Would you like to " + partial + " this task as done?");
    if (answer) {
        $.ajax({
            type: "PUT",
            url: '/Todo/MarkAsDone',
            data: { idtask: _idTask, done: $(obj).prop("checked") },
            success: function (data) {
                if (data) {
                    ToastrMessage("", "task marked as done", "success");
                    RefreshTable("#TaskListDataTable", "/Todo/GetListTaskItem");
                } else {
                    ToastrMessage("", "something went wrong, was not possible to edit the task", "error");
                }
            },
            error: function (xhr, status, error) { alert(error); }
        });
    } else {
        //prevent checkbox's click  (change) if user cancel confirm window
        $(obj).prop("checked", !_bool);
    }
    //return ConfirmCustom("Would you like to " + partial + " this task as done?", function () {
    //    $.ajax({
    //        type: "PUT",
    //        url: '/Todo/MarkAsDone',
    //        data: { idtask: _idTask, done: $(obj).prop("checked") },
    //        success: function (data) {
    //            if (data) {
    //                ToastrMessage("", "task marked as done", "success");
    //                RefreshTable("#TaskListDataTable", "/Todo/GetListTaskItem");
    //            } else {
    //                ToastrMessage("", "something went wrong, was not possible to edit the task", "error");
    //            }
    //        },
    //        error: function (xhr, status, error) { alert(error); }
    //    });
    //});
}