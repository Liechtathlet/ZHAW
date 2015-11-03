# Native Apps
## Access Protection
  - Pin  Code
  - Fingerprint scanner
  - Security pattern
  - Iris scanner

## Theft Protection
  - iOS: Activation Lock / iCloudLock
  - Android: Factory Reset Protection
  - Windows: Reset Protection

## Certificates, Licenses, ...
  - Only signed Apps
  - App can only execute / access own files / settings
  - Most global device settings cannot be changed by an app
  - Sandboxing
  - Revoke installed applications possible
  - Jailbreaking on iOS popular

## Certificates
  - Each developer: Private Key, teams can share the same key
  - Each application has a unique App ID
  - Each device you use for running app has unique ID
  - Developer Certificate: Per developer, valid for one year
  - App ID: Defined in project settings, should follow a reverse URL scheme, must be unique

## Provisioning Profile
  - Generated by Xcode: Development provisioning Profile, valid for 90 days
  - Submission to app store: disribution profile required, valid for 1 year, 99$
  - Contains reference to developer and app id, development profiles have references to the testing devices.
  - Normally: 2 Profiles (development / distribution)
  - Recommendation: via Xcode schemes
  - Mix of XML and Binary data
  - Enterprise Provisioning Profile; company profile for in-house applications, sideloading (internal distribution), will run on all devices with enterprise profile, 299$

## Entitlements
Offizielle und private Entitlements (Erweiterungen), z.B. Maps, Keychan Sharing, etc...


## Attacks on iOS
  - Attacks on the Sandboxing
  - Attacks on developers by changing Xcode


## iOS Development
  - SDK
  - Xcode
  - Interface Builder
  - iOS Simulator
    - 5 Screen Sizes
    - Auto-Layout / Adaptive Layout
  - SWIFT