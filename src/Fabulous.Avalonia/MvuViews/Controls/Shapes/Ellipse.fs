namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
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
            WidgetBuilder<unit, IFabMvuEllipse>(Ellipse.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type MvuEllipseModifiers =
    /// <summary>Link a ViewRef to access the direct Ellipse control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuEllipse>, value: ViewRef<Ellipse>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
