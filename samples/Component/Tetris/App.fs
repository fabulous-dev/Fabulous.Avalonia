namespace Tetris

open System
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Layout
open Avalonia.Threading
open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View
open type Fabulous.Context


[<AutoOpen>]
module EmptyBorderBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a empty Border widget.</summary>
        static member EmptyBorder() =
            WidgetBuilder<'msg, IFabBorder>(Border.WidgetKey)

// Credits to https://github.com/RyushiAok/Tetris for the original code
type Board =
    { width: int
      height: int
      board: TetrisBoard }

module Board =
    let init =
        { width = 16
          height = 24
          board = TetrisBoard.init }

module App =
    let theme = FluentTheme()

    type Model =
        { Tetrimino: Tetrimino
          hold: Tetrimino option
          grid: Board
          lastUpdated: DateTime
          isOver: bool
          score: int }

    // type Msg =
    //     | Empty
    //     | Update
    //     | NewGame
    //     | Left
    //     | Right
    //     | Down
    //     | RotL
    //     | RotR
    //     | Hold
    //
    // let init () =
    //     { Tetrimino = Tetrimino.generate true
    //       hold = None
    //       grid = Board.init
    //       lastUpdated = DateTime.Now
    //       isOver = false
    //       score = 0 },
    //     Cmd.none
    //
    //
    // let update msg model =
    //     match msg with
    //     | Update ->
    //         if model.isOver || (DateTime.Now - model.lastUpdated).TotalMilliseconds < 500.0 then
    //             model, Cmd.none
    //         else
    //             let nxt = model.Tetrimino |> Tetrimino.moveDown model.grid.board
    //
    //             if model.Tetrimino <> nxt then
    //                 { model with
    //                     Tetrimino = nxt
    //                     lastUpdated = DateTime.Now },
    //                 Cmd.none
    //             else
    //                 nxt
    //                 |> Tetrimino.isHighLimitOver
    //                 |> function
    //                     | true ->
    //                         let existsOtherBlock = nxt |> Tetrimino.existsOtherBlock model.grid.board
    //
    //                         let res = model.grid.board |> TetrisBoard.setTetrimino nxt
    //
    //                         { model with
    //                             isOver = true
    //                             grid =
    //                                 { model.grid with
    //                                     board = if existsOtherBlock then model.grid.board else res.newBoard } },
    //                         Cmd.none
    //                     | false ->
    //                         let newMino = Tetrimino.generate false
    //
    //                         let res = model.grid.board |> TetrisBoard.setTetrimino nxt
    //
    //                         { model with
    //                             grid = { model.grid with board = res.newBoard }
    //                             Tetrimino = newMino
    //                             lastUpdated = DateTime.Now
    //                             isOver = newMino |> Tetrimino.existsOtherBlock res.newBoard
    //                             score = model.score + res.eraced },
    //                         Cmd.none
    //     | RotL ->
    //         { model with
    //             Tetrimino = model.Tetrimino |> Tetrimino.rotateLeft model.grid.board
    //             lastUpdated =
    //                 if
    //                     model.Tetrimino.shape = Shape.O
    //                     || model.Tetrimino |> Tetrimino.rotateLeft model.grid.board = model.Tetrimino
    //                     || model.Tetrimino
    //                        |> Tetrimino.rotateLeft model.grid.board
    //                        |> fun mino -> { mino with y = mino.y + 1 }
    //                        |> Tetrimino.existsOtherBlock model.grid.board
    //                        |> not
    //                 then
    //                     model.lastUpdated
    //                 else
    //                     DateTime.Now },
    //         Cmd.none
    //     | RotR ->
    //         { model with
    //             Tetrimino = model.Tetrimino |> Tetrimino.rotateRight model.grid.board
    //             lastUpdated =
    //                 if
    //                     model.Tetrimino.shape = Shape.O
    //                     || model.Tetrimino |> Tetrimino.rotateRight model.grid.board = model.Tetrimino
    //                     || model.Tetrimino
    //                        |> Tetrimino.rotateRight model.grid.board
    //                        |> fun mino -> { mino with y = mino.y + 1 }
    //                        |> Tetrimino.existsOtherBlock model.grid.board
    //                        |> not
    //                 then
    //                     model.lastUpdated
    //                 else
    //                     DateTime.Now },
    //         Cmd.none
    //     | Left ->
    //         { model with
    //             Tetrimino = model.Tetrimino |> Tetrimino.moveLeft model.grid.board
    //             lastUpdated =
    //                 if
    //                     model.Tetrimino.shape = Shape.O
    //                     || model.Tetrimino |> Tetrimino.moveDown model.grid.board <> model.Tetrimino
    //                     || model.Tetrimino |> Tetrimino.moveLeft model.grid.board = model.Tetrimino
    //                 then
    //                     model.lastUpdated
    //                 else
    //                     DateTime.Now },
    //         Cmd.none
    //     | Right ->
    //         { model with
    //             Tetrimino = model.Tetrimino |> Tetrimino.moveRight model.grid.board
    //             lastUpdated =
    //                 if
    //                     model.Tetrimino.shape = Shape.O
    //                     || model.Tetrimino |> Tetrimino.moveDown model.grid.board <> model.Tetrimino
    //                     || model.Tetrimino |> Tetrimino.moveRight model.grid.board = model.Tetrimino
    //                 then
    //                     model.lastUpdated
    //                 else
    //                     DateTime.Now },
    //         Cmd.none
    //     | Down ->
    //         { model with
    //             Tetrimino = model.Tetrimino |> Tetrimino.moveDown model.grid.board },
    //         Cmd.none
    //     | Hold ->
    //         if model.hold.IsSome then
    //             { model with
    //                 Tetrimino = model.hold.Value
    //                 hold = Some(Tetrimino.initMino model.Tetrimino.shape) },
    //             Cmd.none
    //         else
    //             { model with
    //                 Tetrimino = Tetrimino.generate false
    //                 hold = Some(Tetrimino.initMino model.Tetrimino.shape) },
    //             Cmd.none
    //     | NewGame -> init()
    //     | _ -> model, Cmd.none

    let shapeToColor shape =
        match shape with
        | Shape.I -> "#00ffff"
        | Shape.O -> "#ffd700"
        | Shape.J -> "#1e90ff"
        | Shape.L -> "#ffa500"
        | Shape.S -> "#00FF00"
        | Shape.Z -> "#ff0000"
        | Shape.T -> "#800080"

    let boardView grid tetrimino isOver =
        let w, h = grid.width, grid.height

        let toColor tetrimino isOver =
            let cells = grid.board

            let minoPos =
                tetrimino.pos |> Array.map(fun (x, y) -> (x + tetrimino.x, y + tetrimino.y))

            let minoShape = tetrimino.shape

            [| for y in 3 .. (Array2D.length1 cells) - 1 - 1 do
                   for x in 2 .. (Array2D.length2 cells) - 1 - 2 do
                       if not isOver && minoPos |> Array.contains(x, y) then
                           yield shapeToColor minoShape
                       else
                           match cells[y, x] with
                           | Cell.Empty -> yield "#222222"
                           | Cell.Guard -> yield "#AAAAAA"
                           | Cell.Mino shape -> yield shapeToColor shape |]

        (UniformGrid(cols = (w - 4), rows = (h - 4)) {
            let colors = toColor tetrimino isOver

            for color in colors do
                AnyView(Border(View.EmptyBorder().background(color)).padding(0.8))
        })
            .width(280.)
            .height(480.)

    let holdView hold isOver =
        (HStack() {
            (UniformGrid(cols = 4, rows = 4) {
                let state =
                    hold
                    |> Option.map(fun mino ->
                        { mino with
                            pos = mino.pos |> Array.map(fun (a, b) -> (a + 1, b + 1)) })
                    |> Option.map(fun mino ->
                        [| for y in 0..3 do
                               for x in 0..3 do
                                   if not isOver && mino.pos |> Array.contains(x, y) then
                                       yield shapeToColor mino.shape
                                   else
                                       yield "#222222" |])

                match state with
                | None -> ()
                | Some colors ->
                    for color in colors do
                        Border(View.EmptyBorder().background(color)).padding(1.5)
            })
                .height(70.0)
                .width(70.0)
                .canvasLeft(360.0)
                .canvasTop(0.0)
                .background("#222222")

        })
            .dock(Dock.Top)
            .canvasTop(0.0)

    let menuView score =
        (HStack() {
            TextBlock(sprintf "Score: %d " score)
                .fontSize(16.0)
                .horizontalAlignment(HorizontalAlignment.Center)
                .width(350.0)
        })
            .dock(Dock.Top)
            .canvasTop(0.0)

    let howToPlayView () =
        (HStack() {
            TextBlock("[A] LEFT \n[D] RIGHT \n[SHIFT] ROT L \n[SPACE] ROT R \n[E] HOLD")
                .fontSize(12.0)
                .horizontalAlignment(HorizontalAlignment.Center)
                .width(350.0)
        })
            .dock(Dock.Bottom)

    let content () =
        Component("Tetris") {
            let! isOver = State(false)
            let! score = State(0)
            let! grid = State(Board.init)
            let! tetrimino = State(Tetrimino.generate true)
            let! hold = State(Some(Tetrimino.initMino tetrimino.Current.shape))
            let! lastUpdated = State(DateTime.Now)

            let timer =
                DispatcherTimer(
                    TimeSpan.FromMilliseconds(10.),
                    DispatcherPriority.Default,
                    (fun _ _ ->
                        if isOver.Current || (DateTime.Now - lastUpdated.Current).TotalMilliseconds < 500.0 then
                            ()
                        else
                            let nxt = tetrimino.Current |> Tetrimino.moveDown grid.Current.board

                            if tetrimino.Current <> nxt then
                                lastUpdated.Set(DateTime.Now)
                                tetrimino.Set(nxt)
                            else
                                let isHighLimitOver = nxt |> Tetrimino.isHighLimitOver

                                if isHighLimitOver then
                                    let existsOtherBlock = nxt |> Tetrimino.existsOtherBlock grid.Current.board

                                    let res = grid.Current.board |> TetrisBoard.setTetrimino nxt

                                    isOver.Set(true)

                                    grid.Set(
                                        { grid.Current with
                                            board =
                                                if existsOtherBlock then
                                                    grid.Current.board
                                                else
                                                    res.newBoard }
                                    )

                                else
                                    let newMino = Tetrimino.generate false

                                    let res = grid.Current.board |> TetrisBoard.setTetrimino nxt

                                    grid.Set(
                                        { grid.Current with
                                            board = res.newBoard }
                                    )

                                    tetrimino.Set(newMino)
                                    lastUpdated.Set(DateTime.Now)
                                    isOver.Set(newMino |> Tetrimino.existsOtherBlock res.newBoard)
                                    score.Set(score.Current + res.eraced))
                )


            (if isOver.Current then
                 timer.Stop()

                 AnyView(
                     VStack() {
                         TextBlock("Game Over").fontSize(16.0).margin(4.0)

                         Button(
                             "New Game",
                             fun _ ->
                                 tetrimino.Set(Tetrimino.generate true)
                                 hold.Set(None)
                                 grid.Set(Board.init)
                                 lastUpdated.Set(DateTime.Now)
                                 score.Set(0)
                         )
                             .fontSize(16.0)
                             .margin(4.0)
                     }
                 )
             else

                 AnyView(
                     (Dock(lastChildFill = true) {
                         menuView score.Current

                         Border(boardView grid.Current tetrimino.Current isOver.Current)
                             .dock(Dock.Left)
                             .borderThickness(20.0, 0.0, 0.0, 0.0)

                         Border(howToPlayView())
                             .dock(Dock.Right)
                             .borderThickness(30.0, 0.0, 0.0, 0.0)

                         Border(holdView hold.Current isOver.Current)
                             .dock(Dock.Right)
                             .borderThickness(20.0, 0.0, 0.0, 250.0)
                     })
                         .background("#222222")
                 ))
                .onLoaded(fun _ -> timer.Start())
        }

    let view () =

#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication(
            Window(content())
                .onKeyDown(fun e ->
                    match e.Key with
                    | Key.RightShift
                    | Key.LeftShift -> printfn "Left Shift"
                    | Key.Space -> printfn "Space"
                    | Key.S -> printfn "S"
                    | Key.A -> printfn "A"
                    | Key.D -> printfn "D"
                    | Key.E -> printfn "E"
                    | _ -> printfn "Other")
        )
#endif
    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
