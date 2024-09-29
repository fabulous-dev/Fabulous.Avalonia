namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuPathIcon =
    inherit IFabMvuIconElement
    inherit IFabPathIcon

[<AutoOpen>]
module MvuPathIconBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a PathIcon widget.</summary>
        /// <param name="content">The content of the PathIcon.</param>
        static member PathIcon(content: WidgetBuilder<unit, #IFabMvuGeometry>) =
            WidgetBuilder<unit, IFabMvuPathIcon>(
                PathIcon.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| PathIcon.DataWidget.WithValue(content.Compile()) |], ValueNone)
            )

        /// <summary>Creates a PathIcon widget.</summary>
        /// <param name="path">The path of the PathIcon.</param>
        static member PathIcon(path: string) =
            WidgetBuilder<unit, IFabMvuPathIcon>(PathIcon.WidgetKey, PathIcon.DataString.WithValue(Geometry.Parse(path)))
