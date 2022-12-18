namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabWindow =
    inherit IFabElement

module Window =
    let WidgetKey = Widgets.register<Window>()

    let Content = Attributes.defineAvaloniaPropertyWidget Window.ContentProperty

[<AutoOpen>]
module WindowBuilders =
    type Fabulous.Avalonia.View with

        static member Window(content: WidgetBuilder<'msg, #IFabElement>) =
            WidgetBuilder<'msg, IFabWindow>(
                Window.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [| Window.Content.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
