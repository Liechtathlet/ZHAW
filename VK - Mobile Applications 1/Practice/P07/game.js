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

  this.activePlayer = 1;
  this.gameEnded = false;
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

  this.playerClicked = function(e){

    if(!this.gameEnded){

      var width = $("#gameArea").width();
      var height = $("#gameArea").height();

      var wStep = width / this.COLUMNS;
      var hStep = height / this.ROWS;

      var x = Math.floor((e.pageX-$("#gameArea").offset().left));
      var y = Math.floor((e.pageY-$("#gameArea").offset().top));

      var detCol = -1;
      var detRow = -1;

      for(var i = 0;i < this.COLUMNS;i++){
        if(x >= (i*wStep) && x <= ((i+1)*wStep)){
          detCol = i;
          break;
        }
      }

      /*for(var i = 0;i < this.ROWS;i++){
        if(y >= (i*hStep) && y <= ((i+1)*hStep)){
          detRow = i;
          break;
        }
      }*/
      //Looking for free rows
      for(var i = this.ROWS - 1;i >= 0;i--){
        if(this.cellStates[detCol][i] == 0){
          detRow = i;
          break;
        }
      }

      if(detRow != -1 && this.cellStates[detCol][detRow] == 0){
          this.cellStates[detCol][detRow] = this.activePlayer;
          this.drawBoard();

          if (this.hasGameEnded()){
            this.gameEnded = true;

            if(this.activePlayer == 1){
              alert("Spiel-Ende\n" +   $("#nameOfPlayerOneElement").text() + " hat gewonnen!\nFür eine neue Runde laden Sie bitte die Seite neu!");
            }else if (this.acivePlayer == 2){
              alert("Spiel-Ende\n" +   $("#nameOfPlayerTwoElement").text() + " hat gewonnen!\nFür eine neue Runde laden Sie bitte die Seite neu!");
            }

            console.log('Winner: ' + this.activePlayer);
          }else{
            //Calcualte next player
            if(this.activePlayer == 1){
              this.activePlayer = 2;
              $("#nameOfPlayer1").css("color","white");
              $("#nameOfPlayer2").css("color","green");
            }else if (this.activePlayer == 2){
              this.activePlayer = 1;
              $("#nameOfPlayer1").css("color","green");
              $("#nameOfPlayer2").css("color","white");
            }
        }
      }else if (detRow == -1){
        alert('Diese Spalte ist bereits voll. Bitte versuchen Sie eine andere!');
      }
    }
  }.bind(this),


  this.hasGameEnded = function() {
      var in1;
			var in2;
			var x,y,i,j;

			for (x=0;x < this.COLUMNS;x++) {

				in1 = 0;
				in2 = 0;

				for (y=0;y < this.ROWS;y++) {
					if (this.cellStates[x][y] == 1) {
						if (++in1 == 4)
							return true;

						in2 = 0;
					}
					else if (this.cellStates[x][y] == 2) {
						if (++in2 == 4)
							return true;

						in1 = 0;
					}else{
            in1 = 0;
            in2 = 0;
          }
				}
			}


			for (y=0;y < this.ROWS;y++) {

				in1 = 0;
				in2 = 0;

				for (x=0;x < this.COLUMNS;x++) {
					if (this.cellStates[x][y] == 1) {
						if (++in1 == 4)
							return true;
						in2 = 0;
					}
					else if (this.cellStates[x][y] == 2) {
						if (++in2 == 4)
							return true;

						in1 = 0;
					}else{
            in1 = 0;
            in2 = 0;
          }
				}
			}

			for (i=-this.COLUMNS;i < this.COLUMNS-3;i++) {

				in1 = 0;
				in2 = 0;

				for (j=0;j < this.ROWS;j++) {
					x = i + j;
					y = j;
					if (x >= 0 && y >= 0 &&  x < this.COLUMNS && y < this.ROWS) {
						if (this.cellStates[x][y] == 1) {
							if (++in1 == 4)
								return true;
							in2 = 0;
						}
						else if (this.cellStates[x][y] == 2) {
							if (++in2 == 4)
								return true;

							in1 = 0;
						}else{
              in1 = 0;
              in2 = 0;
            }
					}
				}
			}

			for (i=-this.COLUMNS;i < this.COLUMNS-3;i++) {

				in1 = 0;
				in2 = 0;

				for (j=0;j < this.ROWS;j++) {
					x = i - j;
					y = j;
					if (x >= 0 && y >= 0 &&  x < this.COLUMNS && y < this.ROWS) {
						if (this.cellStates[x][y] == 1) {
							if (++in1 == 4)
								return true;
							in2 = 0;
						}
						else if (this.cellStates[x][y] == 2) {
							if (++in2 == 4)
								return true;

							in1 = 0;
						}else{
              in1 = 0;
              in2 = 0;
            }
					}
				}
			}
  },
  this.init();

  this.drawBoard();

  $( "#playerOnePopup" ).popup();
  $( "#playerTwoPopup" ).popup();

  $("#PlayerOneSubmitButton").click( function() {
    $("#nameOfPlayerOneElement").text($("#PopupPlayerOneName").val());
    $( "#playerOnePopup" ).popup("close");

    setTimeout(function(){
         $("#playerTwoPopup").popup("open");
       }, 500);
  });

  $("#PlayerTwoSubmitButton").click( function() {
      $("#nameOfPlayerTwoElement").text($("#PopupPlayerTwoName").val());
      $( "#playerTwoPopup" ).popup("close");
  });

  $( "#playerOnePopup" ).popup("open");
  $( "#playerTwoPopup" ).popup("open");

  //Setup Listeners
  $("#gameArea").click(this.playerClicked);

  $("#nameOfPlayer1").css("color","green");
}
