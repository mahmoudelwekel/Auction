



$(document).ajaxStart(function () {
    $('#loadingDiv').show();
});

$(document).ajaxStop(function () {
    $('#loadingDiv').hide();
});




$(document).ready(function () {
     

    //var table = $('#example,.TableFilter').DataTable({
    //    stateSave: true,
    //    info: false, 
    //    responsive: {
    //        details: true
    //    },
    //    "lengthChange": false
    //});
    
    $(".imgfull").click(function () {
        document.getElementById("modalimage").src = this.src;

        $('#ImageManifier').modal('show');
    });

});

