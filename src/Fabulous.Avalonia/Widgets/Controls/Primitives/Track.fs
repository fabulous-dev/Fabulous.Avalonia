namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

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

    let IgnoreThumbDrag =
        Attributes.defineAvaloniaPropertyWithEquality Track.IgnoreThumbDragProperty

[<AutoOpen>]
module TrackBuilders =
    type Fabulous.Avalonia.View with

        static member inline Track() =
            WidgetBuilder<'msg, IFabTrack>(Track.WidgetKey, AttributesBundle(StackList.empty (), ValueNone, ValueNone))
