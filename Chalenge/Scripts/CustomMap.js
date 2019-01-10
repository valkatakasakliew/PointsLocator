



let map = L.map('map').setView([48.148598, 17.107748], 5);

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

let myMarkers = L.featureGroup().addTo(map);

let myJSONcopy = JSON.parse(JSON.stringify(myJSON));

for (let i = 0; i < myJSONcopy.length; i++) {

    L.circleMarker(myJSONcopy[i].geometry.coordinates).addTo(myMarkers);
    myJSONcopy[i].added = true;
    break;


}

//filter();
//btnForm.onclick = () => filter();

function filter() {

    myMarkers.clearLayers();

    let myJSONcopy = JSON.parse(JSON.stringify(myJSON));

    //let categories = [];

    //if (cbAdults.checked) {
    //    categories.push('adults');
    //}
    //if (cbYouth.checked) {
    //    categories.push('youth');
    //}
    //if (cbSeniors.checked) {
    //    categories.push('seniors')
    //}
    //if (cbMen.checked) {
    //    categories.push('men');
    //}
    //if (cbWomen.checked) {
    //    categories.push('women');
    //}


    for (let i = 0; i < myJSONcopy.length; i++) {
       
        
           
                L.circleMarker([myJSONcopy[i].lat, myJSONcopy[i].lon]).addTo(myMarkers);
                myJSONcopy[i].added = true;
                break;
            
        
    }
}