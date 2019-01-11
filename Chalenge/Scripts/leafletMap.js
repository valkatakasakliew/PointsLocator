// See post: http://asmaloney.com/2015/06/code/clustering-markers-on-leaflet-maps

var map = L.map('map', {
    center: [48.148598, 17.107748],
    minZoom: 10,
    maxZoom: 16,
    zoom: 13
});

L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a>',
    subdomains: ['a', 'b', 'c']
}).addTo(map);

var myURL = jQuery('script[src$="leafletMap.js"]').attr('src').replace('leafletMap.js', '');

var myIcon = L.icon({
    iconUrl: myURL + 'images/pin24.png',
    iconRetinaUrl: myURL + 'images/pin48.png',
    iconSize: [29, 24],
    iconAnchor: [9, 21],
    popupAnchor: [0, -14]
});


var markerClusters = L.markerClusterGroup({ maxClusterRadius: 20 });

for (var i = 0; i < markers.length; ++i) {
    var popup = generatePopUp(markers[i]);

    var m = L.marker([markers[i].CellLat, markers[i].CellLong], { icon: myIcon })
        .bindPopup(popup);
    m.SumM = markers[i].SumM;
    m.SumF = markers[i].SumF;
    m.SumUnknown = markers[i].SumUnknown;
    m.SumToEighteen = markers[i].SumToEighteen;
    m.SumNineteenTwentyFive = markers[i].SumNineteenTwentyFive;
    m.SumTwentySixThirtyFive = markers[i].SumTwentySixThirtyFive;
    m.SumThirtySixFourtyFive = markers[i].SumThirtySixFourtyFive;
    m.SumFourtySixSixtyFive = markers[i].SumFourtySixSixtyFive;
    m.SumOverSixstySix = markers[i].SumOverSixstySix;
    markerClusters.addLayer(m);
}

map.addLayer(markerClusters);


var shownLayer, polygon;

function generatePopUp(marker) {
    return '<table><tr><th rowspan=3>Gender</th><th rowspan=6>Age</th></tr>' +
        '<tr><td>M</td><td>F</td><td>?</td><td>1-18</td><td>19-25</td><td>26-35</td><td>36-45</td><td>46-65</td><td>65+</td>' +
        '</tr><tr>' +
        '<td>' + marker.SumM + '</td>' +
        '<td>' + marker.SumF + '</td>' +
        '<td>' + marker.SumUnknown + '</td>' +
        '<td>' + marker.SumToEighteen + '</td>' +
        '<td>' + marker.SumNineteenTwentyFive + '</td>' +
        '<td>' + marker.SumTwentySixThirtyFive + '</td>' +
        '<td>' + marker.SumThirtySixFourtyFive + '</td>' +
        '<td>' + marker.SumFourtySixSixtyFive + '</td>' +
        '<td>' + marker.SumOverSixstySix + '</td>' +
        '</tr></table>'
}

function removePolygon() {
    if (shownLayer) {
        shownLayer.setOpacity(1);
        shownLayer = null;
    }
    if (polygon) {
        map.removeLayer(polygon);
        polygon = null;
    }
};

markerClusters.on('clustermouseover', function (a) {
    removePolygon();
    a.layer.setOpacity(0.2);
    shownLayer = a.layer;
    polygon = L.polygon(a.layer.getConvexHull());
    map.addLayer(polygon);
});
markerClusters.on('clustermouseout', removePolygon);
map.on('zoomend', removePolygon);


