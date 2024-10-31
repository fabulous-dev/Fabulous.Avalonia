namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentEllipse =
    inherit IFabComponentShape
    inherit IFabEllipse

[<AutoOpen>]
module ComponentEllipseBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Ellipse widget.</summary>
        static member Ellipse() =
            WidgetBuilder<unit, IFabComponentEllipse>(Ellipse.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
