# Cocoa
## New Project Wizard
iOS Application, Single View App, Language: Swift, Devices: Universal

  - AppDelegate.swift: Lifecycle methods for App
  - ViewController.swift: Class for view controller
  - Main.storyboard: Contains view controllers
  - LaunchScreen.storyboard: appearance launch screen
  - Assets.xcassets: folder for resources
  - Info.plist: app configuration (key value)
  - Products: output folder

## Storyboard
  - Design GUI with graphical editor
  - Add controllers, views and transitions
  - Dependencies between storyboards

## COCOA UIVIEWCONTROLLER
  - Per Page: > 1 UIVIEWCONTROLLER
  - MVC
  - Implement logic
  - Override: viewDidLoad, viewWillAppear
  - States: Appearing - Appeared - Disappearing - Disappeared


## Autolayout
Layout for all gui elements, min- / max width / height, distances, define constraints / rules

## Selector
Similar to function pointer, string to identify the method to call, different instances of different classes with the same method -> use selector, depracated

## UIScrollview
Add scrolling to functionality, can be extended to support zooming, panning

## Delegate
Used to handle certain aspects of an object in another object, componentes offer other objects to register themselves as delegates, can have optional or required methods

## Autolayout Programmatically
Visual Format Language, multiple constraint using simple language, cannot be used to define all constraints

### Exercise Solution
---
H:|-20-[button1]-(>=10)-[button2]-|
H:|-20-[view]-20-|
V:|-[button1]-[view]-30-|
V:|-[button2]-[view]-30-|
---  

### CGContext
Execute graphical commands on views

## Gestures
  - Tapping
  - Pinching (Zooming)
  - Panning or dragging (Kreuz und quer)
  - Swiping (von L nach R, O nach U)
  - Rotating
  - Long press

## UI Stack View

## Key Value Storage I
Simple, can be synchronized with iCloud, sufficiant for many apps

## Core Data Storage
kind of "relational database",

## Localisation
Localization.strings or via Storyboard (duplication or strings file), current Locale: NSLocale.currentLocale().objectForKey(NSLocaleLanguageCode) as! NSLog(current)Lang);

## External Libraries
Paket Managers:
  - CocoaPods (for libraries)
  - Alcatraz (for XCode plugins/themes)

## Unit Tests
Unit and UI Tests (XCTestCase), AccessabilityLabels for acessing UI-Elements by name

## Seamless Linking
Web link to open a page in your app, gracefull fallback to web site, create service without need to track installed apps, create file apple-app-site-association, put it on your web-server (JSON-File), App-ID + supported paths.
