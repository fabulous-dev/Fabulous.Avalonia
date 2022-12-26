namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Avalonia.Layout

type IFabTrack =
    inherit IFabControl

module Track =
    let WidgetKey = Widgets.register<Track> ()

    let Minimum = Attributes.defineAvaloniaPropertyWithEquality Track.MinimumProperty

    let Maximum = Attributes.defineAvaloniaPropertyWithEquality Track.MaximumProperty

    let Value = Attributes.defineAvaloniaPropertyWithEquality Track.ValueProperty

    let ViewPortSize =
        Attributes.defineAvaloniaPropertyWithEquality Track.ViewportSizeProperty

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality Track.OrientationProperty

    let Thumb = Attributes.defineAvaloniaPropertyWidget Track.ThumbProperty

    let IncreaseButton =
        Attributes.defineAvaloniaPropertyWidget Track.IncreaseButtonProperty

    let DecreaseButton =
        Attributes.defineAvaloniaPropertyWidget Track.DecreaseButtonProperty

    let IsDirectionReversed =
        Attributes.defineAvaloniaPropertyWithEquality Track.IsDirectionReversedProperty

    let IgnoreThumbDrag =
        Attributes.defineAvaloniaPropertyWithEquality Track.IgnoreThumbDragProperty

    let ValueChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "Track_ValueChanged" Track.ValueProperty

[<AutoOpen>]
module TrackBuilders =
    type Fabulous.Avalonia.View with

        static member inline Track(content: WidgetBuilder<'msg, IFabThumb>) =
            WidgetBuilder<'msg, IFabTrack>(
                Track.WidgetKey,
                AttributesBundle(
                    StackList.three(Track.Minimum.WithValue 0.0, Track.Maximum.WithValue 100.0, Track.Value.WithValue 50.),
                    ValueSome [| Track.Thumb.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type TrackModifiers =

    [<Extension>]
    static member inline minimum(this: WidgetBuilder<'msg, #IFabTrack>, value: float) =
        this.AddScalar(Track.Minimum.WithValue(value))

    [<Extension>]
    static member inline maximum(this: WidgetBuilder<'msg, #IFabTrack>, value: float) =
        this.AddScalar(Track.Maximum.WithValue(value))
        
    [<Extension>]
    static member inline value(this: WidgetBuilder<'msg, #IFabTrack>, value: float) =
        this.AddScalar(Track.Value.WithValue(value))

    [<Extension>]
    static member inline viewPortSize(this: WidgetBuilder<'msg, #IFabTrack>, value: float) =
        this.AddScalar(Track.ViewPortSize.WithValue(value))

    [<Extension>]
    static member inline orientation(this: WidgetBuilder<'msg, #IFabTrack>, value: Orientation) =
        this.AddScalar(Track.Orientation.WithValue(value))

    [<Extension>]
    static member inline thumb(this: WidgetBuilder<'msg, #IFabTrack>, content: WidgetBuilder<'msg, IFabThumb>) =
        this.AddWidget(Track.Thumb.WithValue(content.Compile()))

    [<Extension>]
    static member inline isDirectionReversed(this: WidgetBuilder<'msg, #IFabTrack>, value: bool) =
        this.AddScalar(Track.IsDirectionReversed.WithValue(value))

    [<Extension>]
    static member inline ignoreThumbDrag(this: WidgetBuilder<'msg, #IFabTrack>, value: bool) =
        this.AddScalar(Track.IgnoreThumbDrag.WithValue(value))

    [<Extension>]
    static member inline onValueChanged
        (
            this: WidgetBuilder<'msg, #IFabTrack>,
            value: float,
            onValueChanged: float -> 'msg
        ) =
        this.AddScalar(Track.ValueChanged.WithValue(ValueEventData.create value (fun _ -> onValueChanged value |> box)))
