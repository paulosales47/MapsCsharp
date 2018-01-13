// This example creates circles on the map, representing populations in North
// America.

var cidade = {}

function initMap() {
    // Create the map.
    var brasil = new google.maps.LatLng(-14.2350, -51.9253);
    var map = new google.maps.Map(document.getElementById('map'), {
        center: brasil,
        zoom: 6
    });

    $.ajax({
        type: "POST",
        url: "/Home/ListaPibJson",
        contentType: 'application/json',
        success: function (data) {

            console.log(data);
            
            for (var item in data) {

                   cidade =  {
                       center: { lat: data[item].coordenadaX, lng: data[item].coordenadaY },
                       pib: data[item].valor
                    }

                   var cityCircle = new google.maps.Circle({
                       strokeColor: '#FF0000',
                       strokeOpacity: 0.8,
                       strokeWeight: 2,
                       fillColor: '#FF0000',
                       fillOpacity: 0.35,
                       map: map,
                       center: cidade.center,
                       radius: Math.sqrt(cidade.pib) * 10
                   });

                   //var rectangle = new google.maps.Rectangle({
                   //    strokeColor: '#FF0000',
                   //    strokeOpacity: 0.8,
                   //    strokeWeight: 2,
                   //    fillColor: '#FF0000',
                   //    fillOpacity: 0.35,
                   //    map: map,
                   //    bounds: {
                   //        north: cidade.center.lat,
                   //        south: cidade.center.lat - 1,
                   //        east: cidade.center.lng,
                   //        west: cidade.center.lng - 1
                   //    }
                   //});



            }


        },
        error: function (data) {

        }
    });
}