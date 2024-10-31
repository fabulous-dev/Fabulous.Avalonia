namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous
open Fabulous.Avalonia

type IFabComponentRun =
    inherit IFabComponentInline
    inherit IFabRun


[<AutoOpen>]
module ComponentRunBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Run widget.</summary>
        /// <param name="text">The text to display.</param>
        static member Run(text: string) =
            WidgetBuilder<unit, IFabComponentRun>(Run.WidgetKey, Run.Text.WithValue(text))
