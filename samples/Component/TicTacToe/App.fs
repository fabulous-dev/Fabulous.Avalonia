namespace TicTacToe

open System
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent
open Avalonia.Platform

open type Fabulous.Avalonia.View

type Player =
    | X
    | O

    member p.Swap =
        match p with
        | X -> O
        | O -> X

    member p.Name =
        match p with
        | X -> "X"
        | O -> "O"

type GameCell =
    | Empty
    | Full of Player

    member x.CanPlay = (x = Empty)

type GameResult =
    | StillPlaying
    | Win of Player
    | Draw

type Pos = int * int

type Board = Map<Pos, GameCell>

type Row = GameCell list

module App =
    let theme = FluentTheme()

    let positions =
        [ for x in 0..2 do
              for y in 0..2 do
                  yield (x, y) ]

    let lines =
        [
          // rows
          for row in 0..2 do
              yield [ (row, 0); (row, 1); (row, 2) ]
          // columns
          for col in 0..2 do
              yield [ (0, col); (1, col); (2, col) ]
          // diagonals
          yield [ (0, 0); (1, 1); (2, 2) ]
          yield [ (0, 2); (1, 1); (2, 0) ] ]

    let getLine (board: Board) line = line |> List.map(fun p -> board[p])

    let anyMoreMoves board =
        board |> Map.exists(fun _ c -> c = Empty)

    let getLineWinner line =
        if
            line
            |> List.forall (function
                | Full X -> true
                | _ -> false)
        then
            Some X
        elif
            line
            |> List.forall (function
                | Full O -> true
                | _ -> false)
        then
            Some O
        else
            None

    let getGameResult board =
        match lines |> Seq.tryPick(getLine board >> getLineWinner) with
        | Some p -> Win p
        | _ -> if anyMoreMoves board then StillPlaying else Draw

    let getMessage board (player: Player) =
        match getGameResult board with
        | StillPlaying -> $"%s{player.Name}'s turn"
        | Win p -> $"%s{p.Name} wins!"
        | Draw -> "It is a draw!"

    let canPlay model cell =
        (cell = Empty) && (getGameResult model = StillPlaying)

    let content () =
        Component() {
            let! nextUp = Context.State(Player.X)
            let! board = Context.State(Map.ofList [ for p in positions -> p, Empty ])
            let! visualBoardSize = Context.State(0.)
            let! gameScore = Context.State(0, 0)

            (Grid(coldefs = [ Star ], rowdefs = [ Auto; Star; Auto ]) {
                TextBlock(getMessage board.Current nextUp.Current)
                    .textAlignment(TextAlignment.Center)
                    .fontSize(32.)
                    .margin(16., 50., 16., 16.)

                (Grid(coldefs = [ Star; Pixel(5.); Star; Pixel(5.); Star ], rowdefs = [ Star; Pixel(5.); Star; Pixel(5.); Star ]) {

                    Rectangle()
                        .fill(SolidColorBrush(ThemeAware.With(Colors.Black, Colors.White)))
                        .gridRow(1)
                        .gridColumnSpan(5)

                    Rectangle()
                        .fill(SolidColorBrush(ThemeAware.With(Colors.Black, Colors.White)))
                        .gridRow(3)
                        .gridColumnSpan(5)

                    Rectangle()
                        .fill(SolidColorBrush(ThemeAware.With(Colors.Black, Colors.White)))
                        .gridColumn(1)
                        .gridRowSpan(5)

                    Rectangle()
                        .fill(SolidColorBrush(ThemeAware.With(Colors.Black, Colors.White)))
                        .gridColumn(3)
                        .gridRowSpan(5)

                    for row, col as pos in positions do
                        if canPlay board.Current board.Current[pos] then
                            TextBlock("")
                                .gridRow(row * 2)
                                .gridColumn(col * 2)
                                .fontSize(70.)
                                .background(SolidColorBrush(Colors.Transparent))
                                .onTapped(fun _ ->
                                    board.Set(board.Current.Add(pos, Full nextUp.Current))
                                    nextUp.Set(nextUp.Current.Swap)

                                    // Make an announcement in the middle of the game.
                                    let result = getGameResult board.Current

                                    let x, y = gameScore.Current

                                    match result with
                                    | Win p -> gameScore.Set(if p = X then (x + 1, y) else (x, y + 1))
                                    | _ -> ())
                        else
                            match board.Current[pos] with
                            | Empty -> ()
                            | Full X ->
                                Border(
                                    TextBlock("X")
                                        .fontSize(visualBoardSize.Current / 3.)
                                        .center()
                                )
                                    .gridRow(row * 2)
                                    .gridColumn(col * 2)
                                    .background(SolidColorBrush(ThemeAware.With(Colors.White, Colors.Black)))
                            | Full O ->
                                Border(
                                    TextBlock("O")
                                        .fontSize(visualBoardSize.Current / 3.)
                                        .center()
                                )
                                    .gridRow(row * 2)
                                    .gridColumn(col * 2)
                                    .background(SolidColorBrush(ThemeAware.With(Colors.White, Colors.Black)))
                })
                    .size(visualBoardSize.Current, visualBoardSize.Current)
                    .gridRow(1)

                Button("Restart game", ())
                    .foreground(SolidColorBrush(Colors.Black))
                    .background(SolidColorBrush(Colors.LightBlue))
                    .fontSize(32.)
                    .centerHorizontal()
                    .margin(16., 16., 16., 50.)
                    .gridRow(2)
            })
                .onLoaded(fun _ ->
                    let app = FabApplication.Current
#if MOBILE
                    let desiredSize = app.MainView.Bounds

                    let size =
                        Math.Min(desiredSize.Width, desiredSize.Height)
                        / app.MainView.DesiredSize.AspectRatio

                    visualBoardSize.Set(size - 40.)
#else
                    let desiredSize = app.MainWindow.Screens.Primary

                    let size =
                        Math.Min(float desiredSize.Bounds.Width, float desiredSize.Bounds.Height)
                        / desiredSize.Scaling

                    visualBoardSize.Set(size - 40.)
#endif
                )
        }

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication(Window(content()))
#endif

    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
