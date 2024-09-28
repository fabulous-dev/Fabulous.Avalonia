namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Layout
open Fabulous
open Fabulous.Avalonia

type IFabMvuLayoutable =
    inherit IFabMvuVisual
    inherit IFabLayoutable

module MvuLayoutable =
    let EffectiveViewportChanged =
        MvuAttributes.defineEvent<EffectiveViewportChangedEventArgs> "Layoutable_EffectiveViewportChanged" (fun target ->
            (target :?> Layoutable).EffectiveViewportChanged)

    let LayoutUpdated =
        MvuAttributes.defineEventNoArg "Layoutable_LayoutUpdated" (fun target -> (target :?> Layoutable).LayoutUpdated)

type MvuLayoutableModifiers =
    /// <summary>Listens to the Layoutable EffectiveViewportChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the element's effective viewport changes.</param>
    [<Extension>]
    static member inline onEffectiveViewportChanged(this: WidgetBuilder<unit, #IFabMvuLayoutable>, fn: EffectiveViewportChangedEventArgs -> unit) =
        this.AddScalar(MvuLayoutable.EffectiveViewportChanged.WithValue(fn))

    /// <summary>Listens to the Layoutable LayoutUpdated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the element's layout is updated.</param>
    [<Extension>]
    static member inline onLayoutUpdated(this: WidgetBuilder<unit, #IFabMvuLayoutable>, msg: unit -> unit) =
        this.AddScalar(MvuLayoutable.LayoutUpdated.WithValue(msg))
