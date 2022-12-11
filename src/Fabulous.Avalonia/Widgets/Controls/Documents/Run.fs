namespace Fabulous.Avalonia

open Avalonia.Controls.Documents
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabRun =
    inherit IFabInline
    
module Run =
    let WidgetKey = Widgets.register<Run> ()
    
    let Text = Attributes.defineAvaloniaPropertyWithEquality Run.TextProperty
    
[<AutoOpen>]
module RunBuilders =
    type Fabulous.Avalonia.View with
        static member Run(text: string) =
            WidgetBuilder<'msg, IFabRun>(
                Run.WidgetKey,
                AttributesBundle(StackList.one (Run.Text.WithValue(text)), ValueNone, ValueNone)
            )
