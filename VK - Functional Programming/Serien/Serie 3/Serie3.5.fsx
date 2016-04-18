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

let glPlayForCroupier state =
  // Wenn 21: fertig

  // Wenn >= 17: stay, evaluate

  // Wenn < 17: next card


let glPlayForPlayer state player =
  let newState = (glSetActivePlayer state player)

  // Calculate card value
  // 21 --> BlackJack

  // > 21 --> verloren

  // < 21 --> more cards?

  if (giPlayerWantsAnotherCard) then
    newState = (glGiveOutCardToPlayer player)
    //Check: Value more than 21 --> out, loses bet, game finished

    newState
  else
    newState

let glEvaluateWinner state =
  // Spieler > 21: Out / Over, Spieler hat verloren
  // Croupier > 21: Spieler haben gewonnen
  // Spieler Wert näher an 21: gewonnen, sonst Croupier
  // Untentschieden: kein Gewinn / Verlust


let glCalculateValueOfDeck deck =
  let result = List.fold (fun tot x ->
    let v = x.card
    match v with
      | Ace -> tot+1
      | Jack -> tot+10
      | Queen -> tot+10
      | King -> tot+10
      | :? System.Int32 -> tot+v
    ) 0 deck

    let result2 = List.fold (fun tot x ->
      let v = x.card
      match v with
        | Ace -> tot+11
        | Jack -> tot+10
        | Queen -> tot+10
        | King -> tot+10
        | :? System.Int32 -> tot+v
      ) 0 deck

      if (result = 21 || result2 = 21) then
        21
      else
        let diff1 = 21 - result
        let diff2 = 21 - result2

        if (diff1 < diff2) then
          result
        else
          result2

      if (result < 21 && result2 < 21) then
        if (result < result2) then
          result2
        else
          result
      else
        if (result = 21 || result2 = 21) then
          21
        else
          if (result < result2 ) then
            result2

// give out a card to all players
let giveOutCardToAllPlayers state =
  let newState = (glGiveOutCardToPlayer <| (glSetActivePlayer state Croupier))
  newState = (glGiveOutCardToPlayer <| (glSetActivePlayer newState Player1))
  (glSetActivePlayer newState Croupier)

let giveOutCardToPlayers state =
  let newState = (glGiveOutCardToPlayer <| (glSetActivePlayer state Player))

let giveOutCardToCroupier state =
  let newState = (glGiveOutCardToPlayer <| (glSetActivePlayer state Croupier))

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
  gameState = (giveOutCardToPlayers gameState)

  // 4: Ask every player for more cards
  gameState = (glPlayForPlayer gameState Player)

  // 5: 2. card for croupier
  //TODO: eigentlich am Anfang, einfach verdeckt
  gameState = (giveOutCardToCroupier gameState)

  gameState = (glPlayForCroupier gameState)

  //Evaluate, calculate difference and winner
  gameState = (glEvaluateWinner gameState)
  // Rules:
  //https://www.pagat.com/de/banking/blackjack.html
  //https://de.wikipedia.org/wiki/Black_Jack


//TODO: negative Bet
