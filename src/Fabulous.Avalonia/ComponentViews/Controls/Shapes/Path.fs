namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
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
            WidgetBuilder<unit, IFabComponentPath>(Path.WidgetKey, Path.DataString.WithValue(Geometry.Parse(data)))
