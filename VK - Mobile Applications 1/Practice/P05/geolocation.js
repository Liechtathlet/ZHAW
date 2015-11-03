$( document ).ready(initialize);

function initialize() {

  if (navigator.geolocation){
    navigator.geolocation.getCurrentPosition(success, fail);
  }
}


function success(position){
  var mapCanvas = document.getElementById('map');
  var mapOptions = {
      center: new google.maps.LatLng(position.coords.latitude, position.coords.longitude),
      zoom: 16,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    }
    var map = new google.maps.Map(mapCanvas, mapOptions);
}

function fail(error){
  alert("We couldn't get your location: " + error.code);

  switch(error.code) {
        case error.PERMISSION_DENIED:
            alert("User denied the request for Geolocation.");
            break;
        case error.POSITION_UNAVAILABLE:
          alert("Location information is unavailable.");
            break;
        case error.TIMEOUT:
            alert("The request to get user location timed out.");
            break;
        case error.UNKNOWN_ERROR:
          alert("An unknown error occurred.");
            break;
  }
}
