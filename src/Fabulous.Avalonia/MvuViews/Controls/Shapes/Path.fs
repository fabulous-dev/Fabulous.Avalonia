namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuPath =
    inherit IFabMvuShape
    inherit IFabPath

[<AutoOpen>]
module MvuPathBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Path widget.</summary>
        /// <param name="content">The content of the Path.</param>
        static member Path(content: WidgetBuilder<unit, #IFabMvuGeometry>) =
            WidgetBuilder<unit, IFabMvuPath>(
                Path.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Path.DataWidget.WithValue(content.Compile()) |], ValueNone)
            )

        /// <summary>Creates a Path widget.</summary>
        /// <param name="data">The content of the Path.</param>
        static member Path(data: string) =
            WidgetBuilder<'msg, IFabMvuPath>(Path.WidgetKey, Path.DataString.WithValue(Geometry.Parse(data)))

type MvuPathModifiers =
    /// <summary>Link a ViewRef to access the direct Path control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuPath>, value: ViewRef<Path>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
