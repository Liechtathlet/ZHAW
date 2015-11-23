$( document ).ready(run);

/************************** GAME **************************/
function Game(){
  this.BORDER = 5;   //the border on all four sides of the canvas.
  this.ROWS = 6;    //the number of rows on our board
  this.COLUMNS = 7;  //the number of columns on our board
  this.CIRCLERADIUS = 23;
  this.LINEWIDTH = 4;

};

/************************** GAME-State **************************/
function GameState(game, settings){
  this.cellStates = [];
  this.activePlayer = 1;
  this.gameEnded = false;

  this.startNewGame = function (){
    this.cellStates = [];
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
  this.nextMove = function(col, row, remote){

    if(settings.isLocalGame || (settings.player1startedGame && this.activePlayer == 1) || (!settings.player1startedGame && this.activePlayer == 1) || remote){
      //Looking for free rows
      var detRow = -1;
      for(var i = game.ROWS - 1;i >= 0;i--){
        if(this.cellStates[col][i] == 0){
          detRow = i;
          break;
        }
      }

      if(detRow != -1 && this.cellStates[col][detRow] == 0){
          this.cellStates[col][detRow] = this.activePlayer;

          return true;

      }else if (detRow == -1){
        alert('This column is full, please choose another one!');
        return false;
      }

    }else{
      return false;
    }
  },
  this.checkAfterMove = function(){
    if (this.hasGameEnded()){
      this.gameEnded = true;

      if(this.activePlayer == 1){
        alert("Game-End\n" +   settings.nameOfPlayer1 + " wins!");
      }else if (this.activePlayer == 2){
        alert("Game-End\n" +   settings.nameOfPlayer2 + " wins!");
      }

      console.log('Winner: ' + this.activePlayer);
    }else{
      //Calcualte next player
      if(this.activePlayer == 1){
        this.activePlayer = 2;
      }else if (this.activePlayer == 2){
        this.activePlayer = 1;
      }
  }
},
  this.hasGameEnded = function() {
      var in1;
      var in2;
      var x,y,i,j;

      for (x=0;x < game.COLUMNS;x++) {

        in1 = 0;
        in2 = 0;

        for (y=0;y < game.ROWS;y++) {
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


      for (y=0;y < game.ROWS;y++) {

        in1 = 0;
        in2 = 0;

        for (x=0;x < game.COLUMNS;x++) {
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

      for (i=-game.COLUMNS;i < game.COLUMNS-3;i++) {

        in1 = 0;
        in2 = 0;

        for (j=0;j < game.ROWS;j++) {
          x = i + j;
          y = j;
          if (x >= 0 && y >= 0 &&  x < game.COLUMNS && y < game.ROWS) {
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

      for (i=-game.COLUMNS;i < game.COLUMNS-3;i++) {

        in1 = 0;
        in2 = 0;

        for (j=0;j < game.ROWS;j++) {
          x = i - j;
          y = j;
          if (x >= 0 && y >= 0 &&  x < game.COLUMNS && y < game.ROWS) {
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
function Navigation(settings, board, remote){

  this.setup = function(){

    $("#PopupSettings").popup();
    $("#PopupSettings" ).bind({
     popupafteropen: function(event, ui) {
       $("#gameListRefreshButton").removeClass("ui-disabled");
       $("#gameListnewGameButton").removeClass("ui-disabled");

       $("#settingsPlayer1Name").val(settings.nameOfPlayer1);
       $("#settingsPlayer2Name").val(settings.nameOfPlayer2);
     }.bind(this)
   });

   $("#settingsOnlineGame").slider();

   $("#settingsSaveButton").click( function() {
     settings.nameOfPlayer1 = $("#settingsPlayer1Name").val();
     settings.nameOfPlayer2 = $("#settingsPlayer2Name").val();

     if(($("#settingsOnlineGame").val() ==0 && settings.isLocalGame)|| ($("#settingsOnlineGame").val() ==1 && settings.isOnlineGame))
     {
       //okay, no change in behaviour necessary
     }else{
       if($("#settingsOnlineGame").val() == 1){
         settings.enableOnlinePlay();
         board.prepareGame();

       }else if ($("#settingsOnlineGame").val() == 0){
         settings.enableLocalPlay();
         board.prepareGame();
       }
     }
     board.applySettings();
     $("#PopupSettings" ).popup("close");
   });

   $("#PopupGameJoice").popup();

   $("#navButtonShowGames").click(function(e){
     $("#PopupGameJoice").popup("open");
   });

    $("#PopupGameJoice" ).bind({
     popupafteropen: function(event, ui) {
       remote.loadRemoteGames();
     }.bind(this)
    });

    /** Setup Event-Listeners **/
    $("#gameListRefreshButton").click(function(){
      remote.loadRemoteGames();
    });

    $("#gameListnewGameButton").click(function(){
      remote.addGame();
    });

  }
}

/************************** BOARD **************************/
function Board(settings, state, game, remote){

  this.applySettings = function(){
    $("#areaPlayer1").css("color","white");
    $("#descriptionOfPlayer1").text(settings.descriptionOfPlayer1);
    $("#nameOfPlayer1").text(settings.nameOfPlayer1);

    $("#areaPlayer2").css("color","white");
    $("#descriptionOfPlayer2").text(settings.descriptionOfPlayer2);
    $("#nameOfPlayer2").text(settings.nameOfPlayer2);

    if(settings.isLocalGame){
      $("#navButtonShowGames").addClass('ui-disabled');
    }

    if(settings.isOnlineGame){
      $("#navButtonShowGames").removeClass('ui-disabled');
    }
  },

  this.applyGameState = function(){

      if(state.activePlayer == 1){
        $("#areaPlayer2").css("color","white");
        $("#areaPlayer1").css("color","green");
      }else if (state.activePlayer == 2){
        $("#areaPlayer1").css("color","white");
        $("#areaPlayer2").css("color","green");
      }
  },
  this.prepareGame = function(){
    console.log("Preparing new game...");
    state.startNewGame();

    if(settings.isLocalGame){
      console.log("Setup local game");
      this.prepareForLocal();
    }

    if(settings.isOnlineGame){
      console.log("Setup online game");
      this.prepareForOnline();
    }
  },
  this.prepareForLocal = function(){
    this.applyGameState();
    this.drawBoard();
  },
  this.prepareForOnline = function(){

    if(settings.player1startedGame){
      state.activePlayer = 1;
    }else{
      state.activePlayer = 2;
    }
    console.log("Online-Prepare: " + state.activePlayer);
    this.applyGameState();
    this.drawBoard();

  },
  this.setup = function(){

    $("#gameArea").click(function(e){

      if(!state.gameEnded){
        var width = $("#gameArea").width();
        var height = $("#gameArea").height();

        var wStep = width / game.COLUMNS;
        var hStep = height / game.ROWS;

        var x = Math.floor((e.pageX-$("#gameArea").offset().left));
        var y = Math.floor((e.pageY-$("#gameArea").offset().top));

        var detCol = -1;
        var detRow = -1;

        for(var i = 0;i < game.COLUMNS;i++){
          if(x >= (i*wStep) && x <= ((i+1)*wStep)){
            detCol = i;
            break;
          }
        }

        for(var i = 0;i < game.ROWS;i++){
          if(y >= (i*hStep) && y <= ((i+1)*hStep)){
            detRow = i;
            break;
          }
        }

        if(state.nextMove(detCol,detRow)){
          this.drawBoard();
          state.checkAfterMove();
          this.applyGameState();

          if(settings.isOnlineGame){
            remote.sendMove(detCol);
            remote.getLatestMove();
          }
        }
      }
    }.bind(this));


    $("#navButtonNewGame").click(function(e){
      console.log('Start new game');
      state.startNewGame();

      this.prepareGame();
    }.bind(this));
  },
  this.remoteMove = function(col){
    state.nextMove(col,-1,true);
    this.drawBoard();
    state.checkAfterMove();
    this.applyGameState();
  }
  this.drawBoard = function (){

    var ctx = $('#gameArea')[0].getContext('2d');
    ctx.clearRect(0, 0, $('#gameArea')[0].width, $('#gameArea')[0].height);

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
  this.isOnlineGame = false;
  this.isLocalGame = true;

  this.descriptionOfPlayer1 = 'Player 1';
  this.descriptionOfPlayer2 = 'Player 2';

  this.nameOfPlayer1 = 'Player 1';
  this.nameOfPlayer2 = 'Player 2';

  this.gameId = null;
  this.moveCount = 0;
  this.player1startedGame = false;

  this.enableOnlinePlay = function(){
    this.isLocalGame = false;
    this.isOnlineGame = true;

    this.descriptionOfPlayer1 = 'Local Player';
    this.descriptionOfPlayer2 = 'Remote Player';

    this.gameId = null;
    this.player1startedGame = false;
    this.moveCount = 0;
  },

  this.enableLocalPlay = function(){
    this.isLocalGame = true;
    this.isOnlineGame = false;

    this.descriptionOfPlayer1 = 'Player 1';
    this.descriptionOfPlayer2 = 'Player 2';

    this.gameId = null;
    this.player1startedGame = false;
    this.moveCount = 0;
  };
};

/************************** SETTINGS **************************/
function RemoteService(settings){
  this.board = null;
  var self = this;

  this.setBoard = function (board){
    this.board = board;
  },

  this.loadRemoteGames = function(){
    $.get( "http://clt-dsk-t-6217:8080/api/games", function( data ) {
      console.log( "Loaded Games from server." );

      $("#providedGames .gameLink").unbind();
      $("#providedGames").empty();

      $.each(data.games, function(k, v) {
        if(!v.joined){
          var item = $('<li><a class="gameLink" data-id="'+v.id+'">Spieler: '+ v.player1 + '</a></li>');

          $('#providedGames').append(item);
        }
      });

      $("#providedGames .gameLink").on("click",function(e,ui){
        this.joinGame($(event.target).attr("data-id"));
      }.bind(this));
    }.bind(this));
  },

  this.joinGame = function(id){
    var locPlayerName = settings.nameOfPlayer1;

    $.get( "http://clt-dsk-t-6217:8080/api/joinGame?id=" + id +"&player2=" + locPlayerName, function( data ) {
      console.log( "Joining remote game" );

      console.log(data);
      if(data.game.joined){
        console.log("Successfully joined game");
        settings.nameOfPlayer2 = data.game.player1;
        settings.gameId = id;

        this.board.applySettings();
        this.board.prepareForOnline();

        $("#PopupGameJoice").popup("close");

        this.getLatestMove();
      }else{
        alert("Couldn't join the game!");
      }
    }.bind(this));
  }.bind(this),

  this.addGame = function(){
    var locPlayerName = settings.nameOfPlayer1;
    console.log("Creating Game for: " + locPlayerName);

    $("#gameListRefreshButton").addClass("ui-disabled");
    $("#gameListnewGameButton").addClass("ui-disabled");

    $.get( "http://clt-dsk-t-6217:8080/api/addGame?player1=" + locPlayerName, function( data ) {
        var id = data.id
        console.log( "Created new game: " + id);

        settings.gameId = id;


        //setup polling
        this.pollGameState = function(){
          $.get( "http://clt-dsk-t-6217:8080/api/game?id=" + id, function( data ) {

            console.log("Polling...");
            console.log(data);

            if(data.game.joined && data.game.player2.length > 0){
              settings.player1startedGame = true;
              settings.nameOfPlayer2 = data.game.player2;
              settings.gameId = id;

              self.board.applySettings();
              self.board.prepareForOnline();

              $("#PopupGameJoice").popup("close");
            }else{
                setTimeout(this.pollGameState,900);
            }
          }.bind(this))
        }.bind(this);

        this.pollGameState();

      });

  },

  this.sendMove = function(col){
    settings.moveCount++;

    $.get( "http://clt-dsk-t-6217:8080/api/nextMove?id=" + settings.gameId +"&move=" + col, function( data ) {
      console.log( "Move sent..." );
      console.log(data);
    });
  }

  this.getLatestMove = function(){

    $.get( "http://clt-dsk-t-6217:8080/api/game?id=" + settings.gameId, function( data ) {
      console.log("Waiting for moves...");

      if(settings.moveCount < data.game.moves.length){
        var col = parseInt(data.game.moves.slice(-1));

        this.board.remoteMove(col);
        settings.moveCount++;

      }else{
        if(!settings.gameEnded){
          setTimeout(this.getLatestMove,900);
        }
      }

    }.bind(this));
  }.bind(this)
}

/************************** RUN **************************/
function run (){
  console.log( 'Starting Connect4!' );

  var settings = new Settings();
  var game = new Game();
  var state = new GameState(game,settings);
  var remote = new RemoteService(settings);
  var board = new Board(settings, state, game,remote);
  var nav = new Navigation(settings, board,remote);

  remote.setBoard(board);

  console.log('Loading default settings');
  //settings.enableOnlinePlay();
  settings.enableLocalPlay();
  board.applySettings();

  console.log('Setup navigation bar');
  nav.setup();

  console.log('Setup board');
  board.setup();

  board.prepareGame();
}
