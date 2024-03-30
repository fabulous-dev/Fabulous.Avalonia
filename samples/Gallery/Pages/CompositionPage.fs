namespace Gallery

open Fabulous.Avalonia
open Controls

open Fabulous

open type Fabulous.Avalonia.View
open Fabulous.StackAllocatedCollections.StackList

type IFabCompositionPage =
    inherit IFabControl

module CompositionPageControl =
    let WidgetKey = Widgets.register<CompositionPage>()

[<AutoOpen>]
module CompositionPageControlBuilders =

    type Fabulous.Avalonia.View with

        static member CompositionPageControl<'msg>() =
            WidgetBuilder<'msg, IFabCompositionPage>(CompositionPageControl.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

module CompositionPage =
    let view () = View.CompositionPageControl()
