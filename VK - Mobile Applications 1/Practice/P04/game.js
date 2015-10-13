$( document ).ready(run);

//
// Function: run
// Called on document ready
function run (){
  console.log( 'Starting Connect4!' );

  this.cellStates = [];

  this.BORDER = 5,   //the border on all four sides of the canvas.
  this.ROWS = 6,     //the number of rows on our board
  this.COLUMNS = 7,  //the number of columns on our board
  this.CIRCLERADIUS = 23,
  this.LINEWIDTH = 4,

  //
  // Function: init
  //
  this.init = function (){

    var x = 0;
    var y = 0;

    for (x = 0; x < this.COLUMNS;x++){
      var tmpState = [];

      for (y = 0; y < this.ROWS;y++){
        tmpState.push(0);
      }

      this.cellStates.push(tmpState);
    }

    //Manual set three points in array
    this.cellStates[0][4] = 2;
    this.cellStates[4][2] = 2;
    this.cellStates[3][5] = 2;
  },

  //
  // Function: drawBoard
  //
  this.drawBoard = function (){

    var x = 0;
    var y = 0;

    for(x = 0; x < this.cellStates.length;x++){
      for(y = 0; y < this.cellStates[x].length;y++){

        this.drawCell($('#gameArea')[0],x,y,this.cellStates[x][y]);
      }
    }
  },

  this.drawCell = function(canvas, x, y, state) {
    var xZero = this.BORDER;
    var yZero = this.BORDER;

    var realWidth = canvas.width - 2 * this.BORDER;
    var realHeight = canvas.height - 2 * this.BORDER;

  	var cellWidth = (realWidth / this.COLUMNS);
  	var cellHeight =  (realHeight / this.ROWS) ;

    var cellStartPosX = xZero + x*cellWidth;
    var cellStartPosY = yZero + y*cellHeight;

  	var ctx = canvas.getContext('2d');

  	ctx.lineWidth = this.LINEWIDTH;
  	ctx.strokeStyle = "#086788";
  	ctx.strokeRect (cellStartPosX,	cellStartPosY,
  					cellWidth, cellHeight);

  	if (state == 1 || state == 2) {
  		if (state == 1) {
  			ctx.fillStyle = "#DD1C1A"; //red
  	  	}
  	  	else {
  			ctx.fillStyle = "#f6f600"; //yellow
  	  	}
  		var path = new Path2D();

    //  var xPosition = cellStartPosX + (x+1)*this.LINEWIDTH + ((cellWidth - this.CIRCLERADIUS ) / 2);
    //  var yPosition = cellStartPosY + (y+1)*this.LINEWIDTH + ((cellHeight - this.CIRCLERADIUS ) / 2);

      var xPosition = xZero + (x+1)*cellWidth - (cellWidth / 2);
      var yPosition = yZero + (y+1)*cellHeight - (cellHeight / 2);

  		path.arc(xPosition ,yPosition, this.CIRCLERADIUS,0,2*Math.PI);

  		ctx.fill(path);
  	}
  },

  this.init();

  this.drawBoard();
}
