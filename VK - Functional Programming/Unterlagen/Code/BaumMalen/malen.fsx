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

let pi = Math.PI


//----------------------------------------------------
// hier "malen"
//----------------------------------------------------


let rnd = new System.Random()

// Zufallszahl zwischen lower und upper
let nextR lower upper = 
    let r = rnd.NextDouble()
    r*(upper-lower) + lower

let rec myPicture (x,y) angle length width n value =
         draw (x,y) angle length width
 



myPicture (500.0,100.0) (pi/2.0) 110. 14. 16 (plusminus())

form.ShowDialog()
