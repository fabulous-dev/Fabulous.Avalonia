namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabUserControl =
    inherit IFabContentControl

module UserControl =
    let WidgetKey = Widgets.register<UserControl> ()

[<AutoOpen>]
module UserControlBuilders =
    type Fabulous.Avalonia.View with

        static member inline UserControl(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabUserControl>(
                UserControl.WidgetKey,
                AttributesBundle(
                    StackList.empty (),
                    ValueSome [| ContentControl.Content.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
