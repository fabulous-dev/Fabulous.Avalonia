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
        Attributes.defineEvent<EffectiveViewportChangedEventArgs> "Layoutable_EffectiveViewportChanged" (fun target ->
            (target :?> Layoutable).EffectiveViewportChanged)

    let LayoutUpdated =
        Attributes.defineEventNoArg "Layoutable_LayoutUpdated" (fun target -> (target :?> Layoutable).LayoutUpdated)

type MvuLayoutableModifiers =
    /// <summary>Listens to the Layoutable EffectiveViewportChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the element's effective viewport changes.</param>
    [<Extension>]
    static member inline onEffectiveViewportChanged(this: WidgetBuilder<unit, #IFabMvuLayoutable>, fn: EffectiveViewportChangedEventArgs -> unit) =
        this.AddScalar(MvuLayoutable.EffectiveViewportChanged.WithValue(fn))

    /// <summary>Listens to the Layoutable LayoutUpdated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the element's layout is updated.</param>
    [<Extension>]
    static member inline onLayoutUpdated(this: WidgetBuilder<'msg, #IFabMvuLayoutable>, fn: 'msg) =
        this.AddScalar(MvuLayoutable.LayoutUpdated.WithValue(MsgValue fn))
