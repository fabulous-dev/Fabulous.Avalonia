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

type ComponentEllipseModifiers =
    /// <summary>Link a ViewRef to access the direct Ellipse control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentEllipse>, value: ViewRef<Ellipse>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
