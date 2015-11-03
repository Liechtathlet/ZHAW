# Komponententechnologien
## Web Components
  - Shadow DOM
    - Nicht erreichbar durch JS und CSS
    - Sichtbar auf Seite
    - Shadow Host
      - Visible to user
      - Entry point
    - Shadow Root
      - Hidden
      - Visible in Browser
    - Shadow Boundary
      - Separation CSS / JS from Shadow DOM
  - HTML Templates
    - Teil des Living Standards
  - Importing HTMl Templates
  - Custom Elements

  - Polymer (Google)
  - X-Tag (Mozilla)

### Shadow DOM
---
host.createShadowRoot();
document.importNode(externalNode,deep);
---

  - Pseudo-Classes: ::shadow, :host :host-context ::content
  - Schlechter Browser-Support


## React.js
  - At first it is a concept, not a framework
  - Virtual DOM

### Virtual DOM
  - Eigene Hierarchie im Speicher
  - Data changes tracked trough observer model
  - React builds tree representation of the DOM in memory
  - Calculates differences which should change
  - Server-Side-Rendering Possible
  - Component-Driven Development
  - JavaScript and JSX
  - Rendering auch ohne JSX möglich

## Main Concepts
  - Clear and simple flow of data (data passed down, events flo up)
  - Data passed down using properties
  - Properties should never change, state is mutable
  - State owned by component, can be passed down via properties
  - Functions to change state (passed down)
