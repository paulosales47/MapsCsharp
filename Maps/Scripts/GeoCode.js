$(document).ready(function () {
    
    $.ajax({
        type: "GET",
        url: "https://maps.googleapis.com/maps/api/geocode/json?address=Sao+Jose+dos+Campos&key=AIzaSyAL-LUW50Zfmbw5_NMaiWY4oxpjz2-0Ni8&language=pt-BR&region=pt-BR",
        //contentType: 'application/json',
        success: function (data) {

            console.log(data);

        },
        error: function (data) {

        }
    });

});