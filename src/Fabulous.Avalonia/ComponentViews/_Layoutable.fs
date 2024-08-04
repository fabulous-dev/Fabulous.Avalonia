namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Layout
open Fabulous
open Fabulous.Avalonia

type IFabComponentLayoutable =
    inherit IFabComponentVisual
    inherit IFabLayoutable

module ComponentLayoutable =
    let EffectiveViewportChanged =
        ComponentAttributes.defineEvent<EffectiveViewportChangedEventArgs> "Layoutable_EffectiveViewportChanged" (fun target ->
            (target :?> Layoutable).EffectiveViewportChanged)

    let LayoutUpdated =
        ComponentAttributes.defineEventNoArg "Layoutable_LayoutUpdated" (fun target -> (target :?> Layoutable).LayoutUpdated)

type ComponentLayoutableModifiers =
    /// <summary>Listens to the Layoutable EffectiveViewportChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the element's effective viewport changes.</param>
    [<Extension>]
    static member inline onEffectiveViewportChanged(this: WidgetBuilder<unit, #IFabComponentLayoutable>, fn: EffectiveViewportChangedEventArgs -> unit) =
        this.AddScalar(ComponentLayoutable.EffectiveViewportChanged.WithValue(fn))

    /// <summary>Listens to the Layoutable LayoutUpdated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the element's layout is updated.</param>
    [<Extension>]
    static member inline onLayoutUpdated(this: WidgetBuilder<unit, #IFabComponentLayoutable>, msg: unit -> unit) =
        this.AddScalar(ComponentLayoutable.LayoutUpdated.WithValue(msg))
