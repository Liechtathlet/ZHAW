open System
open System.Drawing
open System.Windows.Forms



//----------------------------------------------------
// Diesen Teil nicht beachten
//----------------------------------------------------

// Create a form to display the graphics
let width, height = 1000, 1000
let form = new Form(Width = width, Height = height)
let box = new PictureBox(BackColor = Color.White, Dock = DockStyle.Fill)
let image = new Bitmap(width, height)
let graphics = Graphics.FromImage(image)
let brush = new SolidBrush(Color.Black)
let gBrush = new SolidBrush(Color.Green)


box.Image <- image
form.Controls.Add(box)

// Compute the endpoint of a line
// starting at (x, y), going at a certain angle
// for a certain length.
let endpoint (x,y) angle length =
    x + length * cos angle,
    y + length * sin angle

let flip x = (float)height - x


// Utility function: draw a line of given width,
// starting from (x, y)
// going at a certain angle, for a certain length.
let drawLine (target : Graphics) (brush : Brush)
             ((x : float),(y : float))
             (angle : float) (length : float) (width : float) =
    let x_end, y_end = endpoint (x,y) angle length
    let origin = new PointF((single)x, (single)(y |> flip))
    let destination = new PointF((single)x_end, (single)(y_end |> flip))
    let pen = new Pen(brush, (single)width)
    target.DrawLine(pen, origin, destination)



//----------------------------------------------------
// Diese Funktion brauchen Sie
// zeichnet Linie der Dicke 'width' und
// Länge 'length'
// von (x,y) im Winkel 'angle' ausgehend
//----------------------------------------------------
let draw (x,y) angle length width =
    drawLine graphics brush (x,y) angle length width

let drawLeaf (x,y) angle length width =
    drawLine graphics gBrush (x,y) angle length width

let pi = Math.PI


//----------------------------------------------------
// hier "malen"
//----------------------------------------------------


let rnd = new System.Random()

// Zufallszahl zwischen lower und upper
let nextR lower upper =
    let r = rnd.NextDouble()
    r*(upper-lower) + lower

let rec myPicture (x,y) angle length width n depth=
  // Draw Trunk
  if n = depth then
    draw (x,y) angle length width
    myPicture (x,y) angle length (width/2) (n-1) depth

  // Draw Leaves
  elif n = 0 then
    drawLeaf (x,y) angle (length*0.5) (width*0.5)
    drawLeaf (x,y) (angle + 0.1) (length*0.6) (width*0.4)
    drawLeaf (x,y) (angle + 0.3) (length*0.4) (width*0.6)
    drawLeaf (x,y) (angle*0.1) (length*0.3) (width*0.3)
    drawLeaf (x,y) (angle*1.1) (length*0.7) (width*0.3)
    drawLeaf (x,y) (angle*2.) (length*0.6) (width*0.3)

  else
    let branchFactor = (1/(depth / n))*3

    // TODO: round up / down

    // Limit angles
    let maxPangle =
      match n with
        |
    // Level 1: n >= (depth * 0.75)): gegen oben
    // Level 2: n >= (depth * 0.65):  horizontal
    // Level 3: n >= (depth * 0.5): leicht gegen unten
    // Level 4: n > (depth * 0.5): egal

    // Generate branches, consider angles (no overlapp), generate length and width

    let pa1 = angle + 0.3 + (nextR 0.2 0.5)
    let pa2 = angle - 0.2 - (nextR 0.3 0.6)
    let pa3 = angle - 0.4 + (nextR 0.1 0.3)

    let a1 =
      match pa1 with
        | x when x >= (3.*(pi/4.)) -> (pi/2.0)
        | _ -> pa1

    let a2 =
      match pa2 with
        | x when x <= (pi/4.) -> (pi/2.0)
        | _ -> pa2

    let a3 =
      match pa3 with
        | x when x >= (3.*(pi/4.)) -> (pi/2.0)
        | _ -> pa3

    let (x',y') = endpoint (x,y) angle length
    myPicture (x',y') a1 (length*0.8) (width*0.8) (n-1)
    myPicture (x',y') a2 (length*0.5) (width*0.9) (n-1)
    myPicture (x',y') a3 (length*0.9) (width*0.7) (n-1)




myPicture (500.0,100.0) (pi/2.0) 210. 20. 10 10

form.ShowDialog()
//form.Close()
