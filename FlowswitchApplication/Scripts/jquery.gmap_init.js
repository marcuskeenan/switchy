

$(function () {
    $("#map").gMap({
        markers: [{
            latitude: 37.4156546,
            longitude: -122.2097863,
            html: 'The is SLAC',
            icon: {
                image: '/Images/gmap_pin_mint.png',
                iconsize: [26, 46],
                iconanchor: [12, 46],
                infowindowanchor: [12, 0]
            }
        }],
        zoom: 15
    });


});
