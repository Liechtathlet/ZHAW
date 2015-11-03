$( document ).ready(run);

/************************** GAME **************************/
function Game(){
  this.BORDER = 5;   //the border on all four sides of the canvas.
  this.ROWS = 6;    //the number of rows on our board
  this.COLUMNS = 7;  //the number of columns on our board
  this.CIRCLERADIUS = 23;
  this.LINEWIDTH = 4;

  this.startNewGame = function(gameState){

  };
};

/************************** GAME-State **************************/
function GameState(game){
  this.cellStates = [];
  this.activePlayer = 1;
  this.gameEnded = false;

  this.init = function (){
    this.activePlayer = 1;
    this.gameEnded = false;

    var x = 0;
    var y = 0;

    for (x = 0; x < game.COLUMNS;x++){
      var tmpState = [];

      for (y = 0; y < game.ROWS;y++){
        tmpState.push(0);
      }

      this.cellStates.push(tmpState);
    }
  },

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
  };
};

/************************** Navigation **************************/
function Navigation(settings, board){

  this.setup = function(){
    $("#PopupSettings").popup();
    $("#PopupSettings" ).bind({
     popupafteropen: function(event, ui) {
       $("#settingsPlayer1Name").val(settings.nameOfPlayer1);
       $("#settingsPlayer2Name").val(settings.nameOfPlayer2);
     }.bind(this)
   });


    $("#PopupGameJoice").popup();

    $("#settingsSaveButton").click( function() {
      settings.nameOfPlayer1 = $("#settingsPlayer1Name").val();
      settings.nameOfPlayer2 = $("#settingsPlayer2Name").val();

      board.applySettings();
      $("#PopupSettings" ).popup("close");
    });

    /** Setup Event-Listeners **/
    /*$("#cgocnpRefresh").click(function(){
      this.loadRemoteGames();
    }.bind(this));

    $("#cgocnpNewGame").click(function(){
      var locPlayerName = $("#nameOfLocalPlayer").text();
      console.log("Creating Game for: " + locPlayerName);

      $.get( "http://clt-dsk-t-6217:8080/api/addGame?player1=" + locPlayerName, function( data ) {
          var id = data.id
          console.log( "Created new game: " + id);



          //setup polling
          $("#PopupGameJoice").popup("close");
        });
    }.bind(this));*/



    /*$( "#chooseGameOrCreateNewPopup" ).bind({
     popupafteropen: function(event, ui) {
       this.loadRemoteGames();
     }.bind(this)
   });*/
  }
}

/************************** BOARD **************************/
function Board(settings, state, game){

  this.applySettings = function(){
    $("#areaPlayer1").css("color","white");
    $("#descriptionOfPlayer1").text(settings.descriptionOfPlayer1);
    $("#nameOfPlayer1").text(settings.nameOfPlayer1);

    $("#areaPlayer2").css("color","white");
    $("#descriptionOfPlayer2").text(settings.descriptionOfPlayer2);
    $("#nameOfPlayer2").text(settings.nameOfPlayer2);
  },

  this.setup = function(){
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

$("#gameArea").click(this.playerClicked);


  },

  this.drawBoard = function (){

    var x = 0;
    var y = 0;

    for(x = 0; x < state.cellStates.length;x++){
      for(y = 0; y < state.cellStates[x].length;y++){

        this.drawCell($('#gameArea')[0],x,y,state.cellStates[x][y],game);
      }
    }
  },

  this.drawCell = function(canvas, x, y, state, game) {
    var xZero = game.BORDER;
    var yZero = game.BORDER;

    var realWidth = canvas.width - 2 * game.BORDER;
    var realHeight = canvas.height - 2 * game.BORDER;

  	var cellWidth = (realWidth / game.COLUMNS);
  	var cellHeight =  (realHeight / game.ROWS) ;

    var cellStartPosX = xZero + x*cellWidth;
    var cellStartPosY = yZero + y*cellHeight;

  	var ctx = canvas.getContext('2d');

  	ctx.lineWidth = game.LINEWIDTH;
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

      var xPosition = xZero + (x+1)*cellWidth - (cellWidth / 2);
      var yPosition = yZero + (y+1)*cellHeight - (cellHeight / 2);

  		path.arc(xPosition ,yPosition, game.CIRCLERADIUS,0,2*Math.PI);

  		ctx.fill(path);
  	}
  };
};

/************************** SETTINGS **************************/
function Settings(){
  var isOnlineGame = false;
  var isLocalGame = true;

  this.descriptionOfPlayer1 = 'Player 1';
  this.descriptionOfPlayer2 = 'Player 2';

  this.nameOfPlayer1 = 'Player 1';
  this.nameOfPlayer2 = 'Player 2';

  this.enableOnlinePlay = function(){
    this.isLocalGame = false;
    this.isOnlineGame = true;

    this.descriptionOfPlayer1 = 'Local Player';
    this.descriptionOfPlayer2 = 'Remote Player';
  },

  this.enableLocalPlay = function(){
    this.isLocalGame = true;
    this.isOnlineGame = false;

    this.descriptionOfPlayer1 = 'Player 1';
    this.descriptionOfPlayer2 = 'Player 2';
  };
};


/************************** RUN **************************/
function run (){
  console.log( 'Starting Connect4!' );

  var settings = new Settings();
  var game = new Game();
  var state = new GameState(game);
  var board = new Board(settings, state, game);
  var nav = new Navigation(settings, board);


  console.log('Loading default settings');
  //settings.enableOnlinePlay();
  settings.enableLocalPlay();
  board.applySettings();

  console.log('Setup navigation bar');
  nav.setup();

  console.log('Init game state');
  state.init();

  console.log('Start game');
  game.startNewGame();

  console.log('Init board');
  board.setup();
  board.drawBoard();


  this.loadRemoteGames = function(){
    $.get( "http://clt-dsk-t-6217:8080/api/games", function( data ) {
      console.log( "Loaded Games from server." );

      $("#providedGames").empty();

      $.each(data.games, function(k, v) {
        if(!v.joined){
          var item = $('<li><a onclick="joinGame(\''+v.id+'\');">Spieler: '+ v.player1 + '</a></li>');

          $('#providedGames').append(item);
        }
      });
    });
  },
  this.joinGame = function(id){
    var locPlayerName = $("#nameOfLocalPlayer").text();

    $.get( "http://clt-dsk-t-6217:8080/api/joinGame?id=" + id +"&player2=" + locPlayerName, function( data ) {
      console.log( "Joining remote game" );

      if(data.game.joined){
        $("#nameOfRemotePlayer").text(data.game.player1);

        //set style for PlayerOne
        //block till the move of PlayerTwo
      }else{
        alert("Couldn't join the game!");
      }
    });
  }
  //this.loadRemoteGames();
  //$("#chooseGameOrCreateNewPopup").popup("open");

    //Setup Listeners
  //

  //$("#nameOfPlayer1").css("color","green");
}
