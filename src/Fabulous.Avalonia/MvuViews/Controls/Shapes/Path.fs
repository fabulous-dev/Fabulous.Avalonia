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
        static member Path(content: WidgetBuilder<'msg, #IFabMvuGeometry>) =
            WidgetBuilder<'msg, IFabMvuPath>(
                Path.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Path.DataWidget.WithValue(content.Compile()) |], ValueNone)
            )

        /// <summary>Creates a Path widget.</summary>
        /// <param name="data">The content of the Path.</param>
        static member Path(data: string) =
            WidgetBuilder<'msg, IFabMvuPath>(Path.WidgetKey, Path.DataString.WithValue(Geometry.Parse(data)))
