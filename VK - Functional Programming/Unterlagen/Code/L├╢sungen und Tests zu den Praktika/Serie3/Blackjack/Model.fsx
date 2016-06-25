open System

//=========================================================
// Basic Types
//=========================================================

type Color = Clubs | Diamonds | Hearts | Spades

type Rank = Num of int | King | Ace | Queen | Jack

type Card = {color: Color; rank: Rank}

// Aces value either 1 or 11 i.e. 'Choice'
// all other cards have a single numerical value i.e 'Single'
type CardValue = Single of int | Choice

type Hand = Card list

type Stack = Card list

type Player = Corleone | Human

type GameState =
   {
    stack: Stack
    playerHand: Hand
    corleoneHand: Hand
    active: Player
    winner: Player Option
    wallet: int
    bet: int
    over: bool
   }

//=========================================================
// Preparing the game
//=========================================================

// shuffle a stack of cards 
let shuffle xs =
   let rnd = Random()
   xs |> List.map (fun x -> (rnd.Next(), x))
      |> List.sortBy fst
      |> List.map snd

// Create a shuffled stack of six decks
let newStack () =
   let colors = [Clubs; Diamonds; Hearts; Spades]
   let ranks = [King; Ace; Queen; Jack] @ [for i in 2..10 do yield Num i]
   let deck = [
               for c in colors do
                  for r in ranks do
                     yield {rank = r; color = c}
              ]
   [for i in 1..6 do yield! deck]
   |> shuffle



//=========================================================
// Functions concerning values of cards and hands
//=========================================================



let cardValue card =
   match card.rank with
   | Num x -> Single x
   | Ace -> Choice
   | _ -> Single 10


let handValues =
   
   let add card intVal =
      match cardValue card with
      | Single x -> [intVal + x]
      | Choice   -> [intVal + 1; intVal + 11]

   let rec sum = function
      | [] -> [0]
      | c::cards
           -> let vals = sum cards
              List.collect (add c) vals
   
   sum >> List.distinct


let handValue hand = 
    if hand = [] then Some 0
    else hand 
        |> handValues
        |> List.filter (fun x -> x < 22)
        |> function 
            | [] -> None 
            | xs -> Some <| List.max xs 
            
            
            
//=========================================================
// Basic game mechanics
//=========================================================

// Player 'player' takes a new card from the stack
let takeCard player game =
    let newCard = game.stack.[0]
    let newStack = List.tail game.stack
    let newGame = {game with stack = newStack}
    match player with
    | Corleone -> let newHand = newCard::(game.corleoneHand)
                  {newGame with 
                     winner = if handValue newHand = None then Some Human else None
                     corleoneHand = newHand }
    | Human    -> let newHand = newCard::(game.playerHand)
                  {newGame with
                     winner = if handValue newHand = None then Some Corleone else None
                     playerHand = newHand }



// A turn of Corleone consists of:
// take card if handValue < 17 or game is not won
// otherwise end turn
let takeTurnCorleone game =
   let ch = game.corleoneHand 
   let ph = game.playerHand
   
   match handValue ch, handValue ph with
   | Some x, Some y when x < 17 || x < y 
       -> game |> takeCard Corleone

   | _ -> {game with winner = Some Corleone}
    