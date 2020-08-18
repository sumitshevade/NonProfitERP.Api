    $("#contactForm").hide();

    $("#addContact").click(function () {
        console.log("sdfsd");
        $("#contactForm").toggle();
    });

    $("#cancelContact").click(function () {
        $("#contactForm").toggle();
    });

    $("#saveContact").click(function () {
        $("#contactForm").toggle();
    });

    // START: Header detail master page
    
    $("#detailForm").hide();

    $("#addDetail").click(function () {
        $("#detailForm").toggle();
    });

    $("#cancelDetail").click(function () {
        $("#detailForm").toggle();
    });

    $("#saveDetail").click(function () {
        $("#detailForm").toggle();
    });
    
    // END: Header detail master page