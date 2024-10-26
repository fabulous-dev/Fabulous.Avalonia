namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentPath =
    inherit IFabComponentShape
    inherit IFabPath

[<AutoOpen>]
module ComponentPathBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Path widget.</summary>
        /// <param name="content">The content of the Path.</param>
        static member Path(content: WidgetBuilder<unit, #IFabComponentGeometry>) =
            WidgetBuilder<unit, IFabComponentPath>(
                Path.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Path.DataWidget.WithValue(content.Compile()) |], ValueNone)
            )

        /// <summary>Creates a Path widget.</summary>
        /// <param name="data">The content of the Path.</param>
        static member Path(data: string) =
            WidgetBuilder<'msg, IFabComponentPath>(Path.WidgetKey, Path.DataString.WithValue(Geometry.Parse(data)))

type ComponentPathModifiers =
    /// <summary>Link a ViewRef to access the direct Path control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentPath>, value: ViewRef<Path>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
