namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuEllipse =
    inherit IFabMvuShape
    inherit IFabEllipse

[<AutoOpen>]
module MvuEllipseBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Ellipse widget.</summary>
        static member Ellipse() =
            WidgetBuilder<'msg, IFabMvuEllipse>(Ellipse.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
