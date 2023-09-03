namespace Gallery.Pages

open Avalonia
open Avalonia.Controls
open Avalonia.Rendering.Composition
open Fabulous.Avalonia
open System.Threading

open type Fabulous.Avalonia.View


module CustomVisual =

    type Model = { Title: string }

    type Msg =
        | ButtonThreadSleep
        | ButtonStartCustomVisual
        | ButtonStopCustomVisual
        | CustomVisualHostVisualTreeAttached of VisualTreeAttachmentEventArgs

    let mutable _customVisual: CompositionCustomVisual = null

    let init () = { Title = "Custom" }

    let mutable _solidVisual: CompositionSolidColorVisual = null

    let updateSolidVisual (v: Visual) =

        if (_solidVisual = null) then
            ()
        else
            _solidVisual.Size <- Vector(v.Bounds.Width / float 3, v.Bounds.Height / float 3)
            _solidVisual.Offset <- Vector3D(v.Bounds.Width / float 3, v.Bounds.Height / float 3, 0)

    let updateVisual (v: Visual) =
        if _customVisual = null then
            ()
        else
            let h = min v.Bounds.Height (v.Bounds.Width / 3.0)
            _customVisual.Size <- Vector(v.Bounds.Width, h)
            _customVisual.Offset <- Vector3D(0.0, (v.Bounds.Height - h) / 2.0, 0.0)
            ()

    let update msg model =
        match msg with
        | ButtonThreadSleep ->
            Thread.Sleep(10000)
            model
        | ButtonStartCustomVisual ->
            _customVisual.SendHandlerMessage(CustomVisualHandler.StartMessage)
            model
        | ButtonStopCustomVisual ->
            _customVisual.SendHandlerMessage(CustomVisualHandler.StopMessage)
            model
        | CustomVisualHostVisualTreeAttached args ->
            let v = args.Parent :?> Control
            let compositor = ElementComposition.GetElementVisual(v).Compositor

            if
                compositor = null
                || (_customVisual <> null && _customVisual.Compositor = compositor)
            then
                ()
            else
                _customVisual <- compositor.CreateCustomVisual(CustomVisualHandler())
                ElementComposition.SetElementChildVisual(v, _customVisual)
                updateVisual v

            v.PropertyChanged.AddHandler(fun _ a ->
                if a.Property = Visual.BoundsProperty then
                    updateVisual v)

            model

    let view model =
        TabItem(
            model.Title,
            Dock() {
                (HStack() {
                    Button("Thread.Sleep(10000);", ButtonThreadSleep)
                    Button("Start", ButtonStartCustomVisual)
                    Button("Stop", ButtonStopCustomVisual)
                })
                    .dock(Dock.Top)

                Border()
                    .onAttachedToVisualTree(CustomVisualHostVisualTreeAttached)
            }
        )
