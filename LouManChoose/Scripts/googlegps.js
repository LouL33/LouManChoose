
let button = () => {
     navigator.geolocation.getCurrentPosition(function (position) {
           var _data = {
            latitude: position.coords.latitude,
            longitude: position.coords.longitude
        };

        $.ajax({
            url: "/home/Redbutton",
            contentType: "application/json",
            data: JSON.stringify(_data),
            type: "POST",
            dataType: "html",
            success: (newHtml) => {
                
                // TODO: populate the modal with new html
                $('#myModal').html(newHtml)
                $('#myModal').modal('show')
                // TODO: open model using javascript

            },
            error: (jqxHR, textStatus, errorThrown) => {


            }

        });
    })
}

// angel was here
let Favorite = () => {
         // grab resturrantId from the html for that current selected resturant
        var _data = {
            id: $("#locationId").val()
        }
        // POST with AJAX back to your new controller
        $.ajax({
            url: "api/ActualFavController", 
            contentType: "application/json",
            data: JSON.stringify(_data),
            type: "POST",
            dataType: "json",
            success: (newHtml) => {
                $(".star").toggleClass("glyphicon-star glyphicon-star-empty");
            }
        });
} 

