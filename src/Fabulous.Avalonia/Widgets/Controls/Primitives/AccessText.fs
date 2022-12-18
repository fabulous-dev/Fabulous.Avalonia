namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Fabulous

type IFabAccessText =
    inherit IFabTextBlock

module AccessText =
    let WidgetKey = Widgets.register<AccessText>()

    let ShowAccessKey =
        Attributes.defineAvaloniaPropertyWithEquality AccessText.ShowAccessKeyProperty

[<AutoOpen>]
module AccessTextBuilders =
    type Fabulous.Avalonia.View with

        static member inline AccessText(text: string, showAccessKey: bool) =
            WidgetBuilder<'msg, IFabAccessText>(
                AccessText.WidgetKey,
                TextBlock.Text.WithValue(text),
                AccessText.ShowAccessKey.WithValue(showAccessKey)
            )
