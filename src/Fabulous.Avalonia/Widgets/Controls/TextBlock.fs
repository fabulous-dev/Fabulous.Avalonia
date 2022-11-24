namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous

type IFabTextBlock = inherit IFabControl

module TextBlock =
    let WidgetKey = Widgets.register<TextBlock>()
    
    let Text = Attributes.defineAvaloniaPropertyWithEquality TextBlock.TextProperty
    let TextAlignment = Attributes.defineAvaloniaPropertyWithEquality TextBlock.TextAlignmentProperty
    
[<AutoOpen>]
module TextBlockBuilders =
    type Fabulous.Avalonia.View with
        static member inline TextBlock<'msg>(text: string) =
            WidgetBuilder<'msg, IFabTextBlock>(
                TextBlock.WidgetKey,
                TextBlock.Text.WithValue(text)
            )

[<Extension>]
type TextBlockModifiers =
    [<Extension>]
    static member inline textAlignment(this: WidgetBuilder<'msg, #IFabTextBlock>, value: TextAlignment) =
        this.AddScalar(TextBlock.TextAlignment.WithValue(value))
        
[<Extension>]
type TextBlockExtraModifiers =
    [<Extension>]
    static member inline centerText(this: WidgetBuilder<'msg, #IFabTextBlock>) =
        this.AddScalar(TextBlock.TextAlignment.WithValue(TextAlignment.Center))
