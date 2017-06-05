
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