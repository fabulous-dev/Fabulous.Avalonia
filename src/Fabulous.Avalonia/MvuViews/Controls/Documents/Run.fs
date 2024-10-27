namespace Fabulous.Avalonia.Mvu

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
            WidgetBuilder<'msg, IFabMvuRun>(Run.WidgetKey, Run.Text.WithValue(text))
