namespace Fabulous.Avalonia

open Avalonia.Controls.Documents
open Fabulous

type IFabRun =
    inherit IFabInline

module Run =
    let WidgetKey = Widgets.register<Run>()

    let Text = Attributes.defineAvaloniaPropertyWithEquality Run.TextProperty

[<AutoOpen>]
module RunBuilders =
    type Fabulous.Avalonia.View with

        static member Run(text: string) =
            WidgetBuilder<'msg, IFabRun>(Run.WidgetKey, Run.Text.WithValue(text))
