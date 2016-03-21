// ***** Aufgabe 5)

//
// *** Basic Types ***
//
open System

type Color = Club | Diamond | Heart | Spade
type Card = Num of int | Jack | Queen | King | Ace
type CardValue = Single of int | Choice of int * int

type BaseCard = {card: Card; color: Color}

type Player = Player1 | Croupier

type GameState = {
  stack: BaseCard list
  playerHand: BaseCard list
  croupierHand: BaseCard list
  activePlayer: Player
  winnerPlayer: Player Option
  wallet: uint32
  bet: uint32
}

//
// *** Card / Deck creation operations ***
//
let createBaseDeckByColor color =
  [
    yield {BaseCard.card = Ace; BaseCard.color = color}
    yield {BaseCard.card = King; BaseCard.color = color}
    yield {BaseCard.card = Queen; BaseCard.color = color}
    yield {BaseCard.card = Jack; BaseCard.color = color}
    for i in 2 .. 10 do yield {BaseCard.card = (Num i); BaseCard.color = color}
]

let createDeck =
  List.append (createBaseDeckByColor Club) (createBaseDeckByColor Diamond)
  |> List.append (createBaseDeckByColor Heart)
  |> List.append (createBaseDeckByColor Spade)

let createDecks count =
  List.concat [for i in 0 .. count do yield createDeck]

// Fisher-Yates Shuffle-Algorithm
// Src: http://www.clear-lines.com/blog/post/Optimizing-some-old-F-code.aspx
let shuffleDeck list =
  let rand = new System.Random()

  let shuffle items (rng: Random) =
   let rec shuffleTo (indexes: int[]) upTo =
      match upTo with
      | 0 -> indexes
      | _ ->
         let fst = rng.Next(upTo)
         let temp = indexes.[fst]
         indexes.[fst] <- indexes.[upTo]
         indexes.[upTo] <- temp
         shuffleTo indexes (upTo - 1)
   let length = List.length items
   let indexes = [| 0 .. length - 1 |]
   let shuffled = shuffleTo indexes (length-1)
   List.permute (fun i -> shuffled.[i]) items

  shuffle list rand


//
// *** Game Interactive Functions ***
//

// Get Bet for Player
let rec giGetBetForPlayer() =
  printfn "Player1 | Amount to bet: "

  let betAmount = System.Console.ReadLine()
  let convBetAmount =
    try Some <| uint32 betAmount
      with _ -> None

  match convBetAmount with
    | None ->
        printfn "Invalid input"
        giGetBetForPlayer()
    | Some x -> x

// Get "WantsAnotherCard" for Player
let rec giPlayerWantsAnotherCard (player:Player) =
  printfn "Hit / Sty?  [h/s]"

  match System.Console.ReadLine().ToLower() with
    | "h" -> true
    | "s" -> false
    | _ -> giPlayerWantsAnotherCard player

// Print wallet state
let giOutputWallet state =
  printfn "Player1 | wallet amaount: %i" state.wallet

  //
  // *** Game Logic Functions ***
  //
  // Create initial state
let glCreateInitialState =
  {
    stack = (shuffleDeck (createDecks 6))
    playerHand = []
    croupierHand = []
    activePlayer = Croupier
    winnerPlayer = None
    wallet = 100u
    bet = 0u
  }

// Give out a card to a Player
let glGiveOutCardToPlayer state =
  let outCard = state.stack.[0]
  let newStack = List.tail state.stack

  let newState =
    match state.activePlayer with
      | Player1 -> {state with stack = newStack; playerHand = (outCard :: state.playerHand)}
      | Croupier -> {state with stack = newStack; croupierHand = (outCard :: state.croupierHand)}

  newState

// set active player
let glSetActivePlayer state player =
  {state with GameState.activePlayer = player}

// give out a card to all players
let giveOutCardToAllPlayers state =
  let newState = (glGiveOutCardToPlayer <| (glSetActivePlayer state Croupier))
  newState = (glGiveOutCardToPlayer <| (glSetActivePlayer newState Player1))
  (glSetActivePlayer newState Croupier)

// Receive bet for Player
let rec glReceiveBet state =
  giOutputWallet state
  let bet = giGetBetForPlayer()

  if (bet > state.wallet) then
    printfn "Your bet amount is too large for your wallet!"
    glReceiveBet state
  else
    let newState = {state with GameState.wallet = (state.wallet - bet); GameState.bet = bet}
    newState



giveOutCardToAllPlayers glCreateInitialState

let playBlackJack() =

  // 0: Create initial game state
  let gameState = glCreateInitialState

  // 1: Get Bet for Player1
  gameState = (glReceiveBet gameState)

  // 2: Give out one card to all players
  gameState = (giveOutCardToAllPlayers gameState)

  // 3: Give out next card to all players (except groupier)

  // 4: Ask every player for more cards
    //Check: Value more than 21 --> out, loses bet, game finished

  //let rec innerPlay() =

    // Croupier: zweite Karte

    // Croupier: Wert >= 17: stay

    // Croupier: Wert <= 16: Nochmals eine Karte

    // Berechnung Differenz 21 zu Croupier

    // Berechnung Differenz 21 zu Spieler

    // Vergleich differenzen

  //  match System.Console.ReadLine().ToLower() with
  //    | "h" -> playBlackJack ()
  //    | _ -> printfn "Game Ends!";;

  //  printfn "Noch eine runde?  [y/n]"

  //  match System.Console.ReadLine().ToLower() with
  //    | "y" -> playBlackJack ()
  //    | _ -> printfn "Game Ends!";;

//playBlackJack ()



// 5: Alle Spieler bedient: Croupier zieht seine 2. Karte, >= 17 Punkte: stay, <= 16: hit
//Croupier: Ass stets als 11 Punkte (ausswer wenn resultat mehr als 21, dann mit 1 Punkt)
// Croupier Punkte > 21: Alle verbleibenden Spieler haben gewonnen
// Sonst: Spieler gewinnen, deren Kartenwert näher an 21 ist, als der Wert vom Croupier, Gewinn: 1:1
// Unentschieden: Croupier und Spieler gleich viele Punkte, gewinnt nichts / verliert nichts

//Werte: Ass: 11 oder 1
//2 - 10: entsprechend den Augen
//Bilder: (Bube, Dame, König): 10

//TODO: negative Bet
