#CSS, JavaScript - Update
##Flexbox
  - FlexContainer: display: flex (auf parent element)
  - FlexContainer: display inline-flex
  - FlexItem (Unterhalb FlexContainer):
  - vh: View-Height
  - flex-direction: row | column | row-reverse | col-reverse
  - order: Reihenfolge der Container
  - justify-content: flex-start | flex-end | justify-content
  - align-items: stretch | center | flex-start | baseline
  - flex-grow, flex-shrink, flex-basis --> flex: x y z (Bsp. Wenn weniger platz, dann x mal so stark verkleinern)
  - flex-wrap

##ECMASCRIPT 6 / 2015
  - Features: Modules, Classes, Maps, Sets, Promises, Generators
  - Only additional Features
    - Block level scope (var -> function level scope, let -> block level scope)
    - const ITEMS = 30; (Konstanten) (Block Level Scope)
    - Destructuring Assignments (a,b = b,a, mehrere Return-Werte)
    - Functions
      - Default parameters
      - REST Parameters ( function(year,...names))
      - Destructured Parameters
      - Arrow Functions (var um = (num1, num2) => {num1 + num2})
    - Symbols ("Enums") (let sym = Symbol())
    - Objects let obj = { myMethod() {...}}
    - Class declarations (class Point extends GeometryObject with constructor + methods)
    - Modules (Import, Export Default)
    - Template strings
    - Collections: Maps, Sets
