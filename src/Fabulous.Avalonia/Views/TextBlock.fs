namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous

type IFabTextBlock = inherit IFabControl

module TextBlock =
    let WidgetKey = Widgets.register<TextBlock>()
    
    let Text = Attributes.defineDirectWithEquality TextBlock.TextProperty
    
[<AutoOpen>]
module TextBlockBuilders =
    type Fabulous.Avalonia.View with
        static member inline TextBlock<'msg>(text: string) =
            WidgetBuilder<'msg, IFabTextBlock>(
                TextBlock.WidgetKey,
                TextBlock.Text.WithValue(text)
            )

