
$(document).ready(function () {

    var modal = $(".DetailsModal");

    var x = $(".close");


    // Show the modal
    $(".DetailsSpan").on('click', function () {

        modal.css("display", "block");

    });

    // Handle the <span> element that closes the modal
    x.on('click', function () {

        modal.css("display", "none");

    });


    //// When the user clicks anywhere outside of the modal, close it
    //$(window).click(function (e) {

    //    if (e.target == modal) {
            
    //        modal.css("display", "none");
    //    }

    //});


});
