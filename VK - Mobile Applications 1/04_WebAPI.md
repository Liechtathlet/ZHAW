#Mobile Web-APIs
##URLs Beyond the Web (URIs)
  - Phone call and text mesage links
  - Deep Linking into Apps

<a href="tel:+41791111111">Order Pizza Now!</a>

  - tel:<Number>
  - sms:<Number>?body=...
  - Schema: http://www.iana.org/assignments/uri-schemes/uri-schemes.xhtml

**Deep Linking:**
  - iOS: Universal Linking
    - JSON file file im root der webseite (https)
  - Android M: App to App Link
  - Click link -> App available -> open in app, otherwise: open in browser

##Geolocation
  - navigator.geolocation.getCurrentPosition(success, fail)
  - Geofencing API (notifications on entering region), a Service Workers API (only Chrome)

##Device Orientation
  - Gyroscope
  - Accelerometer
  - Magnetometer

##Capturing Pictures, Audio, Video
  - Up till now: often plugins required
  - Currently: Several variants of "Media Capture API"
- WebRTC
- GetUserMedia

~~~
<input type="file" accept="image/*" capture="camera" />
~~~


##Other APIs
  - BatteryStatusAPI
  - Vibration API
  - Ambient Light API
  - Proximity API
  - Also not mobile:
    - Application Cache
    - Service Workers
    - Web Workers
    - Web Storage
    - IndexedDb
    - Multimedia
    - Page Visibility API
    - Fullscreen API
    - Clipboard API
    - ...

##Not only mobile
