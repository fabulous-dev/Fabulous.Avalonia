namespace Gallery

open Fabulous.Avalonia
open Controls

open Fabulous

open Fabulous.Avalonia.Mvu
open type Fabulous.Avalonia.Mvu.View
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuCompositionPage =
    inherit IFabMvuControl

module CompositionPageControl =
    let WidgetKey = Widgets.register<CompositionPage>()

[<AutoOpen>]
module CompositionPageControlBuilders =

    type Fabulous.Avalonia.Mvu.View with

        static member CompositionPageControl() =
            WidgetBuilder<'msg, IFabMvuCompositionPage>(CompositionPageControl.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

module CompositionPage =
    let view () = View.CompositionPageControl()
