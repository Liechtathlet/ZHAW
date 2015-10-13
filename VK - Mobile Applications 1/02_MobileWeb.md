##Mobile Web
**Varianten:**
  - Native Apps
  - Mobile Apps
  - Hybrid Apps

Webapps
  - Dynamic, interactive
  - Rather SPA implementation
  - Client side logic

Websites
  - Rather static content
  - Multiple links / pages
  - Server side logic

Herausforderungen:
  - Platform integration of native apps cannot be reached
  - More or less dependent on connectivity
  - lack of developer tools compared to native app development
  - Monetization of mobile sites can prove tricky

###Browsers and Rendering Engines
  - WetKit (Safari)
  - Blink (Chromium)
  - Trident (Internet Explorer), EdgeHTML (Edge)


##Mobile First
  -  Content First

##Mobile Web
  - Forms
    - type="number" (Choose the correct type)
    - type="email"
    - type="tel"
    - type="date"

##Response Webdesign
  - Client Side Adaptation
    - Responsive Web Design
  - Server-Side Adaptation
    - Device Database
  - Hybrid Adaptation
    - RESS (Responsive web design with server side components)

  - Viewport
      - <meta name="viewport" content="width:320">
      - <meta name="viewport" content="width:device-width">
      - content: width, initial-scale, minimum-scale, maximum-scale, user-scalable
  - Fixed Layout
  - Fluid Layout (Angaben in Prozent)
  - CSS3 Media Queries
    - <link rel="stylesheet" media="screen and (max-width:400px)" href="small.css"/>
    - @import url(small.css) screen and (max-width: 400px)
    - @media screen and (max-width:400px):
    - tv, portrait, landscape, ....

##Responsive Webdesign
      - Ethan Marcotte: Fluid Grids, Responsive Web Design

##What is a Pixel
    CSS 2.1: Absolute Unit, pt: 1/72 of 1in, px: 1px = 0.75px
    Tatsächliche Grösse: Browser + OS (Spez. Auflösung), Druck: physikalische Grösse

    ##Referenz Pixel
    Grösse Pixel bei 96dpi und 1 Armlänge Abstand

##CSS Pixel
      - Screen Size: 1px
      - Units (cm) based on px
      - Opera on HTC Desire: 1 CSS Pixel = 1.5 Screen Pixel
      - iPhone with Retina: 1 CSS Pixel = 2 Screen Pixel
