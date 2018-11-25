function ToastrMessage(title, message, type, closeButton, position, ShowEasing) {
    if (type == null) {
        type = "info";
    }

    if (position == null) {
        position = "toast-bottom-right";
    }

    if (ShowEasing == null) {
        ShowEasing = "swing";
    }

    if (closeButton == null) {
        closeButton = true;
    }
    
    toastr.options = {
        "closeButton": closeButton,
        "debug": false,
        "newestOnTop": true,
        "progressBar": false,
        "positionClass": position,
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": ShowEasing,
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    if (title == null || title == "") {
        toastr[type](message);
    } else {
        toastr[type](message, title);
    }
}