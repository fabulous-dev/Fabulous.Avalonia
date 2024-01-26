namespace Gallery

open System
open System.Diagnostics
open Avalonia.Animation
open Avalonia.Animation.Easings
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

// https://github.com/AvaloniaUI/Avalonia/discussions/7875
module TransitioningContentControlPage =
    type Model =
        { Images: string list
          SelectedImage: string
          Transition: IPageTransition
          Transitions: string list
          Duration: float option
          ClipToBounds: bool }

    type Msg =
        | NextImage
        | PrevImage
        | TransitionChanged of SelectionChangedEventArgs
        | DurationChanged of float option
        | ClipToBoundsChanged of bool

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | NoMsg -> Cmd.none

    let init () =
        { Images =
            [ "avares://Gallery/Assets/Icons/fabulous-icon.png"
              "avares://Gallery/Assets/Icons/fsharp-icon.png"
              "avares://Gallery/Assets/Icons/fabulous-icon.png" ]
          SelectedImage = "avares://Gallery/Assets/Icons/fabulous-icon.png"
          Transition = PageSlide(TimeSpan.FromSeconds(1.), PageSlide.SlideAxis.Horizontal)
          Transitions = [ "Slide"; "CrossFade"; "3D Rotation"; "Composite" ]
          Duration = Some 250.
          ClipToBounds = false },
        []

    let update msg model =
        match msg with
        | NextImage ->
            let index = model.Images |> List.findIndex(fun x -> x = model.SelectedImage)
            let nextIndex = (index + 1) % model.Images.Length

            { model with
                SelectedImage = model.Images[nextIndex] },
            []

        | PrevImage ->
            let index = model.Images |> List.findIndex(fun x -> x = model.SelectedImage)
            let prevIndex = (index - 1) % model.Images.Length
            let prevIndex = if prevIndex < 0 then model.Images.Length - 1 else prevIndex

            { model with
                SelectedImage = model.Images[prevIndex] },
            []

        | DurationChanged duration -> { model with Duration = duration }, []

        | ClipToBoundsChanged clipToBounds ->
            { model with
                ClipToBounds = clipToBounds },
            []

        | TransitionChanged selection ->
            let control = selection.Source :?> ComboBox
            let selectedItem = control.SelectedIndex
            let selection = control.Items[selectedItem] :?> string

            let transition =
                match selection, model.Duration with
                | "Slide", Some duration -> PageSlide(TimeSpan.FromSeconds(duration), PageSlide.SlideAxis.Horizontal) :> IPageTransition
                | "CrossFade", Some duration -> CrossFade(TimeSpan.FromSeconds(duration))
                | "3D Rotation", Some duration -> Rotate3DTransition(TimeSpan.FromSeconds(duration), PageSlide.SlideAxis.Horizontal)
                | "Composite", Some duration ->
                    let crossFade = CrossFade(TimeSpan.FromSeconds(1.))
                    crossFade.FadeInEasing <- BounceEaseIn()
                    crossFade.FadeOutEasing <- BounceEaseOut()

                    let compositePageTransition = CompositePageTransition()
                    compositePageTransition.PageTransitions.Add(Rotate3DTransition(TimeSpan.FromSeconds(duration), PageSlide.SlideAxis.Horizontal))
                    compositePageTransition.PageTransitions.Add(crossFade)
                    compositePageTransition

                | _ -> PageSlide(TimeSpan.FromSeconds(1.), PageSlide.SlideAxis.Horizontal)

            { model with Transition = transition }, []

    let program =
        Program.statefulWithCmdMsg init update mapCmdMsgToCmd
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component(program) {
            let! model = Mvu.State

            Dock(true) {
                TextBlock("The TransitioningContentControl control allows you to show a page transition whenever the Content changes.")
                    .classes([ "h2" ])
                    .dock(Dock.Top)

                ExperimentalAcrylicBorder(
                    (HStack(5.) {
                        HeaderedContentControl(
                            "Select a transition",
                            ComboBox(model.Transitions, (fun x -> TextBlock(x)))
                                .selectedIndex(0)
                                .onSelectionChanged(TransitionChanged)
                                .verticalAlignment(VerticalAlignment.Center)
                        )

                        HeaderedContentControl(
                            "Duration",
                            NumericUpDown(100., 1000., model.Duration, DurationChanged)
                                .increment(250.)
                                .verticalAlignment(VerticalAlignment.Center)
                        )

                        HeaderedContentControl(
                            "Clip to Bounds",
                            ToggleSwitch(model.ClipToBounds, ClipToBoundsChanged)
                                .verticalAlignment(VerticalAlignment.Center)
                        )
                    })
                        .margin(5.)
                        .isSharedSizeScope(true)
                        .centerHorizontal()
                )
                    .material(
                        ExperimentalAcrylicMaterial()
                            .backgroundSource(AcrylicBackgroundSource.Digger)
                            .tintColor(Colors.White)
                    )
                    .dock(Dock.Bottom)
                    .margin(10.)
                    .cornerRadius(5.)

                Button("<", PrevImage).dock(Dock.Left)

                Button(">", NextImage).dock(Dock.Right)

                Border(
                    TransitioningContentControl(Image(model.SelectedImage))
                        .pageTransition(model.Transition)
                        .size(200., 200.)
                )
                    .margin(5.)
                    .clipToBounds(model.ClipToBounds)
            }
        }
