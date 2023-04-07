namespace Fabulous.Avalonia

open Avalonia.Controls.Shapes
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabEllipse =
    inherit IFabShape

module Ellipse =
    let WidgetKey = Widgets.register<Ellipse>()

[<AutoOpen>]
module EllipseBuilders =
    type Fabulous.Avalonia.View with

        static member Ellipse() =
            WidgetBuilder<'msg, IFabEllipse>(Ellipse.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
