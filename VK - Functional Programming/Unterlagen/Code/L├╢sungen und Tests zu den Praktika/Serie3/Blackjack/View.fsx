
#load "Model.fsx"
open Model


//----------------------------------------
// This module is about printing the state 
// of a Black Jack game to the console
//----------------------------------------

let printCard card =
   let pColor = function
      | Clubs -> '♧'
      | Hearts -> '♡'
      | Diamonds -> '♢'
      | Spades -> '♤'
   let pRanks = function
      | Num x -> sprintf "%i" x
      | King  -> "K"
      | Ace  -> "A"
      | Queen -> "Q"
      | Jack -> "J"
   sprintf "[%c%s]" (pColor card.color) (pRanks card.rank)

let printHand =
   List.fold (fun x y -> sprintf "%s %s" x (printCard y)) ""

let printGame game =
   let header = "$$$$$$$$$$$$> State-Of-The-Game <$$$$$$$$$$$$"
   sprintf "%s\n wallet: %i\n Corleones hand: %s \n Your hand: %s \n Bet: %i$\n\n" 
      <| header <| game.wallet
      <| printHand game.corleoneHand  
      <| printHand game.playerHand
      <| game.bet

