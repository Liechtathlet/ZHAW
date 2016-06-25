#load "View.fsx"
open Model
open View
open System




let show game = printfn "%s" <| printGame game

let rec restart message game =
    printfn "%s" message
    match Console.ReadLine() with
    | "y" when game.wallet > 0
       -> show game
          printfn "Please place your bet!"
          match (Console.ReadLine () |> Int32.TryParse) with
          | (true, x) when game.wallet >= x 
            -> {game with
                  winner = None
                  playerHand = []
                  corleoneHand = []
                  wallet = game.wallet - x
                  active = Human
                  bet = x}
          | _ 
            -> game |> restart "Invalid bet, retry? [y/_]"

    | _ -> {game with over = true}




let rec play game =
   
   match game.over, game.winner, game.active with
   | true, _, _ -> printfn "Corleone send his wishes to your family."
   
   | _, Some Corleone, _
      -> show game
         printfn "";printfn "Corleone wins"
         {game with bet = 0} |> restart "Wanna play another round?" |> play

   | _, Some Human, _ 
      -> show game
         printfn ""
         printfn "you win!"
         {game with 
            wallet = game.wallet + 2 * game.bet
            bet = 0} |> restart "Wanna play another round?" |> play

   | _ ,_ , Corleone 
      -> show game
         printfn "Corleone plays"
         Threading.Thread.Sleep(1000)
         game |> takeTurnCorleone |> play

   | _, _, Human 
      -> show game
         printfn "Your turn."
         printfn "Would you like a card? [y/_]"
         match Console.ReadLine() with
         | "y" 
            -> game |> takeCard Human |> play
         | _
            -> {game with active = Corleone} |> play 



// Top level


let folder = @"C:\Users\dando\Dropbox\ZHAW\teaching\Fachhochschule\2015\FUN\code\BJ\final\"

let message = IO.File.ReadAllText(folder+"greet.txt")
   
let initialGame = 
   { stack = (newStack (): Stack)
     playerHand = []
     corleoneHand = []
     active = Human
     winner = None
     wallet = 100
     bet = 0
     over = false }

//initialGame |> restart message |> play
