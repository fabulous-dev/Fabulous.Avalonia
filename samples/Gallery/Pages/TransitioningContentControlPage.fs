namespace Gallery

open System
open System.Collections.Generic
open System.Diagnostics
open System.Threading
open System.Threading.Tasks
open Avalonia
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Media.Imaging
open Avalonia.Styling
open Avalonia.VisualTree
open Fabulous.Avalonia
open Fabulous

type PageTransition(displayTitle: string) =
    let _transition: IPageTransition = null

    member val Transition = _transition with get, set

    member val DisplayTitle = displayTitle

    override this.ToString() = this.DisplayTitle

type CustomTransition(duration) =

    let mutable _duration: TimeSpan = Unchecked.defaultof<_>
    member val Duration = _duration with get, set

    member this.GetVisualParent(from: Visual, to': Visual) =
        let p1 = from.GetVisualParent()
        let p2 = to'.GetVisualParent()

        if p1 <> null && p2 <> null && p1 <> p2 then
            raise(ArgumentException("Controls for PageSlide must have same parent."))

        if p1 = null then
            raise(InvalidOperationException("Cannot determine visual parent."))
        else
            p1

    interface IPageTransition with
        member this.Start(from: Visual, to': Visual, forward: bool, cancellationToken: CancellationToken) =
            task {
                if cancellationToken.IsCancellationRequested then
                    ()
                else
                    let tasks = List<Task>()
                    let parent = this.GetVisualParent(from, to')
                    let scaleProperty = ScaleTransform.ScaleYProperty

                    if from <> null then
                        let animation = Animation()
                        let keyFrame = KeyFrame()
                        keyFrame.Setters.AddRange [ Setter(Property = scaleProperty, Value = 1.) ]
                        keyFrame.Cue <- Cue(0.)
                        let keyFrame' = KeyFrame()
                        keyFrame'.Setters.AddRange [ Setter(Property = scaleProperty, Value = 0.) ]
                        keyFrame'.Cue <- Cue(1.)
                        animation.Children.AddRange([ keyFrame; keyFrame' ])
                        animation.Duration <- this.Duration
                        tasks.Add(animation.RunAsync(from, cancellationToken))

                    if to' <> null then
                        let animation = Animation()
                        let keyFrame = KeyFrame()
                        keyFrame.Setters.AddRange [ Setter(Property = scaleProperty, Value = 0.) ]
                        keyFrame.Cue <- Cue(0.)
                        let keyFrame' = KeyFrame()
                        keyFrame'.Setters.AddRange [ Setter(Property = scaleProperty, Value = 1.) ]
                        keyFrame'.Cue <- Cue(1.)
                        animation.Children.AddRange([ keyFrame; keyFrame' ])
                        animation.Duration <- this.Duration
                        tasks.Add(animation.RunAsync(to', cancellationToken))

                    do! Task.WhenAll(tasks)

                    if from <> null && not cancellationToken.IsCancellationRequested then
                        from.IsVisible <- false
            }

open type Fabulous.Avalonia.View

module TransitioningContentControlPage =
    type Model =
        { Images: Bitmap list
          SelectedImage: Bitmap
          PageTransitions: PageTransition list
          SelectedTransition: PageTransition
          Duration: float option
          ClipToBounds: bool }

    type Msg =
        | NextImage
        | PrevImage
        | TransitionChanged of SelectionChangedEventArgs
        | DurationChanged of float option
        | ClipToBoundsChanged of bool
        | TransitionsUpdated of PageTransition list

    type CmdMsg = SettingUpTransitions of PageTransition list * int

    let updateTransitions (pageTransitions: PageTransition list) duration =
        let transitions =
            pageTransitions
            |> List.mapi(fun index value ->
                match index with
                | 1 -> value.Transition <- CrossFade(TimeSpan.FromMilliseconds(duration))
                | 2 -> value.Transition <- PageSlide(TimeSpan.FromMilliseconds(duration), PageSlide.SlideAxis.Horizontal) :> IPageTransition
                | 3 -> value.Transition <- PageSlide(TimeSpan.FromMilliseconds(duration), PageSlide.SlideAxis.Vertical) :> IPageTransition
                | 4 ->
                    let compositeTransition = CompositePageTransition()
                    compositeTransition.PageTransitions.Add(pageTransitions[1].Transition)
                    compositeTransition.PageTransitions.Add(pageTransitions[2].Transition)
                    compositeTransition.PageTransitions.Add(pageTransitions[3].Transition)
                    value.Transition <- compositeTransition :> IPageTransition
                | 5 -> value.Transition <- CustomTransition(TimeSpan.FromMilliseconds(duration)) :> IPageTransition
                | _ -> value.Transition <- null

                value)

        TransitionsUpdated transitions


    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | SettingUpTransitions(pageTransitions, i) -> Cmd.ofMsg(updateTransitions pageTransitions i)

    let pageTransitions =
        [ PageTransition("None")
          PageTransition("CrossFade")
          PageTransition("Slide horizontally")
          PageTransition("Slide vertically")
          PageTransition("Composite")
          PageTransition("Custom") ]

    let init () =
        let images = [ "fabulous-icon.png"; "fsharp-icon.png"; "fabulous-icon.png" ]

        let images =
            images
            |> List.map(fun image ->
                let path = $"avares://Gallery/Assets/Icons/{image}"
                ImageSource.fromString path)

        { Images = images
          SelectedImage = images[0]
          SelectedTransition = pageTransitions[0]
          PageTransitions = pageTransitions
          Duration = Some 250.
          ClipToBounds = false },
        [ SettingUpTransitions(pageTransitions, 500) ]

    let update msg model =
        match msg with
        | NextImage ->
            let index = model.Images |> List.findIndex(fun x -> x = model.SelectedImage)
            let index = (index + 1) % model.Images.Length

            { model with
                SelectedImage = model.Images[index] },
            []

        | PrevImage ->
            let index = model.Images |> List.findIndex(fun x -> x = model.SelectedImage)
            let index = (index - 1) % model.Images.Length
            let index = if index < 0 then model.Images.Length - 1 else index

            { model with
                SelectedImage = model.Images[index] },
            []

        | DurationChanged duration ->
            let duration = duration |> Option.defaultValue 500
            { model with Duration = Some duration }, [ SettingUpTransitions(model.PageTransitions, int duration) ]

        | ClipToBoundsChanged clipToBounds ->
            { model with
                ClipToBounds = clipToBounds },
            []

        | TransitionChanged selection ->
            let control = selection.Source :?> ComboBox
            let selectedItem = control.SelectedIndex
            let selection = control.Items[selectedItem] :?> string

            let selectedTransition =
                model.PageTransitions |> List.tryFind(fun x -> x.DisplayTitle = selection)

            match selectedTransition with
            | None -> model, []
            | Some value ->
                { model with
                    SelectedTransition = selectedTransition.Value },
                []

        | TransitionsUpdated pageTransitions ->
            { model with
                PageTransitions = pageTransitions },
            []

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
                            ComboBox(model.PageTransitions |> List.map(_.DisplayTitle), (fun x -> TextBlock(x)))
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
                            .tintColor(Colors.Blue)
                    )
                    .dock(Dock.Bottom)
                    .margin(10.)
                    .cornerRadius(5.)

                Button("<", PrevImage).dock(Dock.Left)

                Button(">", NextImage).dock(Dock.Right)

                Border(
                    TransitioningContentControl(Image(model.SelectedImage))
                        .pageTransition(model.SelectedTransition.Transition)
                        .size(200., 200.)
                )
                    .margin(5.)
                    .clipToBounds(model.ClipToBounds)
            }
        }
