namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabWindow =
    inherit IFabElement
    
module Window =
    let WidgetKey = Widgets.register<Window>()

[<AutoOpen>]
module WindowBuilders =
    type Fabulous.Avalonia.View with
        static member Window() =
            WidgetBuilder<'msg, IFabElement>(
                Window.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueNone,
                    ValueNone
                )
            )

