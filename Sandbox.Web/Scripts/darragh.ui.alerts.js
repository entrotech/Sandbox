if (!darragh.ui.alerts) {
    darragh.ui.alerts = {}
}

darragh.ui.alerts.confirmDelete = function (name, id, onDeleteConfirmed) {
    sweetAlert({
        title: "Are you sure?",
        text: "You will not be able to recover this " + name + "!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        onDeleteConfirmed(id);
        // add to your ajax delete success method "sweetAlert("Deleted!", "The X has been deleted.", "success");"
    });
} // confirmDelete

darragh.ui.alerts.error = function (message) {
    sweetAlert({
        title: "Error",
        text: message,
        type: "error",
        showCancelButton: false,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "OK",
        closeOnConfirm: true
    });
} 