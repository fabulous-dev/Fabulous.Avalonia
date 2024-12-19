namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabGestureRecognizer =
    inherit IFabStyledElement

module GestureRecognizer =
    let IsHoldingEnabled =
        Attributes.defineAvaloniaPropertyWithEquality Gestures.IsHoldingEnabledProperty

    let IsHoldWithMouseEnabled =
        Attributes.defineAvaloniaPropertyWithEquality Gestures.IsHoldWithMouseEnabledProperty

type GestureRecognizerModifiers =
    [<Extension>]
    static member inline isHoldingEnabled(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(GestureRecognizer.IsHoldingEnabled.WithValue(value))

    [<Extension>]
    static member inline isHoldWithMouseEnabled(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(GestureRecognizer.IsHoldWithMouseEnabled.WithValue(value))

type GestureRecognizerBuilderExtensions =

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabGestureRecognizer and 'msg: equality>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabGestureRecognizer>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabGestureRecognizer and 'msg: equality>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabGestureRecognizer>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
