namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia

type IFabMvuRun =
    inherit IFabMvuInline
    inherit IFabRun


[<AutoOpen>]
module MvuRunBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Run widget.</summary>
        /// <param name="text">The text to display.</param>
        static member Run(text: string) =
            WidgetBuilder<unit, IFabMvuRun>(Run.WidgetKey, Run.Text.WithValue(text))

type MvuRunModifiers =
    /// <summary>Link a ViewRef to access the direct Run control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuRun>, value: ViewRef<Run>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
