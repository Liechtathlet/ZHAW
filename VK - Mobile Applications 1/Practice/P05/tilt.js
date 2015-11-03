$( document ).ready(initialize);

function initialize() {

  if (window.DeviceOrientationEvent) {
    console.log("DeviceOrientation is supported");

    // Listen for the event and handle DeviceOrientationEvent object
    window.addEventListener('deviceorientation', function(eventData) {
      // gamma is the left-to-right tilt in degrees, where right is positive
      var tiltLR = eventData.gamma;

      // beta is the front-to-back tilt in degrees, where front is positive
      var tiltFB = eventData.beta;

      // alpha is the compass direction the device is facing in degrees
      var dir = eventData.alpha

      // call our orientation event handler
      deviceOrientationHandler(tiltLR, tiltFB, dir);
    }, false);
  } else {
  alert('Device orientation not supported!');
  }
}

function deviceOrientationHandler(tiltLR, tiltFB,dir){
document.getElementById("tiltLR").innerHTML = Math.round(tiltLR);
document.getElementById("tiltFB").innerHTML = Math.round(tiltFB);
document.getElementById("dir").innerHTML = Math.round(dir);
}
