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
